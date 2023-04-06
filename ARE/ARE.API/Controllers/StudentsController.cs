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
                                    .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);

        }

        public override async Task<ActionResult> PostAsync([FromBody] Student entity)
        {
            if (!string.IsNullOrEmpty(entity.PhotoPath))
            {
                var photoUser = Convert.FromBase64String(entity.PhotoPath);
                entity.PhotoPath = await _fileStorage.SaveFileAsync(photoUser, ".jpg", _container);
            }

            return await base.PostAsync(entity);
        }

        public override async Task<ActionResult> PutAsync([FromBody] Student entity)
        {
            /*var currentStudent = await _context.Students.FirstOrDefaultAsync(x=> x.Id == entity.Id);
            if (currentStudent == null)
            {
                return NotFound();
            }*/

            //TODO: REVISAR LOGICA PARA AGREGAR O MODIFICAR FOTO
            if (!string.IsNullOrEmpty(entity.PhotoPath))
            {
                var photoStudent = Convert.FromBase64String(entity.PhotoPath);
                entity.PhotoPath = !string.IsNullOrEmpty(entity.PhotoPath) ? await _fileStorage.EditFileAsync(photoStudent, ".jpg", _container, entity.PhotoPath) : await _fileStorage.SaveFileAsync(photoStudent, ".jpg", _container);
            }

            return await base.PutAsync(entity);
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

