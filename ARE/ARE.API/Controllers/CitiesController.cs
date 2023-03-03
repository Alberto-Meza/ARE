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
    [Route("/api/cities")]
    public class CitiesController : GenericController<City>
    {
        private readonly DataContext _context;
        public CitiesController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet("ByStateId")]
        public virtual async Task<ActionResult> GetByStateId([FromQuery] PaginationDTO pagination)
        {

            var queryable = _context.Cities
                                    .Where(x => x.StateId == pagination.Id)
                                    .AsQueryable();

            return Ok(await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync());


            /*
            var entity = _context.Cities.Where(x => x.StateId == pagination.Id).ToList();
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);*/
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Cities
                .Where(x => x.StateId == pagination.Id)
                .AsQueryable();

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }
    }
}

