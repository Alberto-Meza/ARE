using System.Reflection;
using ARE.API.Data;
using ARE.API.Helpers;
using ARE.Shared.DTOs;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/countries")]
    public class CountriesController : GenericController<Country>
    {
       
        private readonly DataContext _context;

        public CountriesController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public virtual ActionResult GetAllAsync([FromQuery] PaginationDTO pagination)
        {

            var queryable = _context.Countries
                                    .Include(x => x.States)
                                    .AsQueryable();
            
            return Ok( queryable.ContaintAll(pagination, new Country())
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToList());

        }

        [HttpGet("totalPages")]
        public ActionResult GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Countries.AsQueryable();

            double count = queryable.ContaintAll(pagination, new Country()).ToList().Count();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

    }
}

