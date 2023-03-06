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
        public virtual ActionResult GetByCountryId([FromQuery] PaginationDTO pagination)
        {

            var queryable = _context.States
                                    .Include(x => x.Cities)
                                    .Include(x => x.Country)
                                    .Where(x => x.CountryId == pagination.Id)
                                    .AsQueryable();
        


            return Ok( queryable.ContaintAll(pagination,new State())
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToList());


        }


        [HttpGet("totalPages")]
        public ActionResult GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.States
                .Where(x => x.Country!.Id == pagination.Id)
                .AsQueryable();

            double count =  queryable.ContaintAll(pagination, new State()).Count();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }


    }
}

