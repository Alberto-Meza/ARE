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
    [Route("/api/states")]
    public class StatesController : GenericController<State>
    {
        private readonly DataContext _context;
        public StatesController(DataContext context) : base(context)
        {
            _context = context;
		}


        [HttpGet("ByCountryId")]
        public virtual async Task<ActionResult> GetByCountryId([FromQuery] PaginationDTO pagination)
        {

            var queryable = _context.States
                                    .Include(x => x.Cities)
                                    .Where(x => x.CountryId == pagination.Id)
                                    .AsQueryable();

            return Ok(await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync());




            /*var entity =  _context.States
                                        .Include(x => x.Country)
                                        .Include(x => x.Cities)
                                       .Where(x => x.CountryId == id).ToList();
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);*/
        }


        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.States
                .Where(x => x.Country!.Id == pagination.Id)
                .AsQueryable();

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }


    }
}

