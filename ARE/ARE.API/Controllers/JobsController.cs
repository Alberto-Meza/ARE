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
    [Route("/api/jobs")]
    public class JobsController : GenericController<Job>
    {
        private readonly DataContext _context;

        public JobsController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public virtual ActionResult GetAllAsync([FromQuery] PaginationDTO pagination)
        {

            var queryable = _context.Jobs
                                    .Include(x=>x.Department)
                                    .AsQueryable();


            return Ok(queryable.ContaintAll(pagination, new Job())
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToList());

        }

        [HttpGet("totalPages")]
        public ActionResult GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Jobs.AsQueryable();

            double count = queryable.ContaintAll(pagination, new Job()).Count();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }
    }
}

