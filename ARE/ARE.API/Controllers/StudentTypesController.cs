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
    [Route("/api/studentTypes")]
    public class StudentTypesController : GenericController<StudentType>
    {
        private readonly DataContext _context;

        public StudentTypesController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public virtual ActionResult GetAllAsync([FromQuery] PaginationDTO pagination)
        {

            var queryable = _context.StudentTypes
                                    .AsQueryable();


            return Ok( queryable.ContaintAll(pagination, new StudentType())
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToList());

        }

        [HttpGet("totalPages")]
        public  ActionResult GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.StudentTypes.AsQueryable();

            double count = queryable.ContaintAll(pagination, new StudentType()).Count();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }
    }
}

