using System;
using ARE.API.Data;
using ARE.API.Helpers;
using ARE.Shared.DTOs;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/students")]
    public class StudentsController : GenericController<Student>
    {
        private readonly DataContext _context;
        public StudentsController(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResult> GetAsync(int id)
        {

            var entity = await _context.Students
                                    .Include(x => x.City)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);

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

