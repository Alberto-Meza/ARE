using System;
using ARE.API.Data;
using ARE.API.Helpers;
using ARE.Shared.DTOs;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentsController : GenericController<Student>
    {
        private readonly DataContext _context;
        private readonly IFileStorage _fileStorage;
        private readonly string _container;

        public StudentsController(DataContext context, IFileStorage fileStorage) : base(context)
        {
            _context = context;
            _fileStorage = fileStorage;
            _container = "students";
        }

        public override async Task<ActionResult> GetAsync(int id)
        {

            var entity = await _context.Students
                                    .Include(x => x.City)
                                    .ThenInclude(x=>x.State)
                                    .ThenInclude(x=>x.Country)
                                    .Include(x=>x.StudentTypeRelationships)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);

        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult> CreateStudent([FromBody] StudentDTO entity)
        {
            Student student = entity.ToStudent();

            foreach (var studentTypeId in entity.StudentTypeIds!)
            {
                student.StudentTypeRelationships!.Add(
                    new StudentTypeRelationship { StudentType = await _context.StudentTypes.FirstOrDefaultAsync(x => x.Id == studentTypeId)});
            }


            if (!string.IsNullOrEmpty(entity.PhotoPath))
            {
                var photoUser = Convert.FromBase64String(entity.PhotoPath);
                student.PhotoPath = await _fileStorage.SaveFileAsync(photoUser, ".jpg", _container);
            }
            await base.PostAsync(student);
            return Ok(entity);
        }

        public override async Task<ActionResult> PutAsync([FromBody] Student entity)
        {
            /*var currentStudent = await _context.Students.FirstOrDefaultAsync(x=> x.Id == entity.Id);
            if (currentStudent == null)
            {
                return NotFound();
            }*/

            //TODO: REVISAR LOGICA PARA AGREGAR O MODIFICAR FOTO
            /*if (!string.IsNullOrEmpty(entity.PhotoPath))
            {
                var photoStudent = Convert.FromBase64String(entity.PhotoPath);
                entity.PhotoPath = !string.IsNullOrEmpty(entity.PhotoPath) ? await _fileStorage.EditFileAsync(photoStudent, ".jpg", _container, entity.PhotoPath) : await _fileStorage.SaveFileAsync(photoStudent, ".jpg", _container);
            }
            else
            {
                entity.PhotoPath = _context.Students.FirstOrDefault(x => x.Id == entity.Id).PhotoPath;

            }

            return await base.PutAsync(entity);
            */


            
            try
            {
                var currentStudent = await _context.Students.FirstOrDefaultAsync(x => x.Id == entity.Id);
                
                if (currentStudent == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrEmpty(entity.PhotoPath))
                {
                    var photoUser = Convert.FromBase64String(entity.PhotoPath);
                    entity.PhotoPath = !string.IsNullOrEmpty(currentStudent.PhotoPath) ? await _fileStorage.EditFileAsync(photoUser, ".jpg", _container, currentStudent.PhotoPath) : await _fileStorage.SaveFileAsync(photoUser, ".jpg", _container);
                }

                currentStudent.Name = entity.Name;
                currentStudent.LastName1 = entity.LastName1;
                currentStudent.LastName2 = entity.LastName2;
                currentStudent.Gender = entity.Gender;
                currentStudent.BirthDate = entity.BirthDate;
                currentStudent.BirthPlace = entity.BirthPlace;
                currentStudent.Asthma = entity.Asthma;
                currentStudent.Convulsions = entity.Convulsions;
                currentStudent.OtherConditions = entity.OtherConditions;
                currentStudent.Allergies = entity.Allergies;
                currentStudent.Diseases = entity.Diseases;
                currentStudent.Medicines = entity.Medicines;
                currentStudent.Observation = entity.Observation;
                currentStudent.FirstDateAppointment = entity.FirstDateAppointment;
                currentStudent.Folio = entity.Folio;
                currentStudent.Fingerprint1 = entity.Fingerprint1;
                currentStudent.Fingerprint2 = entity.Fingerprint2;
                currentStudent.IsActive = entity.IsActive;
                currentStudent.Street = entity.Street;
                currentStudent.Number = entity.Number;
                currentStudent.Suburb = entity.Suburb;
                currentStudent.ZipCode = entity.ZipCode;
                currentStudent.BloodTypeId = entity.BloodTypeId;
                currentStudent.CivilStatusId = entity.CivilStatusId;
                currentStudent.SchoolGradeId = entity.SchoolGradeId;
                currentStudent.CityId = entity.CityId;
                currentStudent.PhotoPath = !string.IsNullOrEmpty(entity.PhotoPath) && entity.PhotoPath != currentStudent.PhotoPath ? entity.PhotoPath : currentStudent.PhotoPath;


                return Ok(await base.PutAsync(currentStudent));
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetAll")]
        public virtual async Task<ActionResult> GetAllAsync([FromQuery] PaginationDTO pagination)
        {

            var queryable = _context.Students
                                    .Include(x => x.City)
                                    .AsQueryable();


            return Ok(await queryable.ContaintAll(pagination, new Student())
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync());

        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Students.AsQueryable();

            double count = await queryable.ContaintAll(pagination, new Student()).CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }
    }
}

