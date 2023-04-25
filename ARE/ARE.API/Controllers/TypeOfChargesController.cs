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
    [Route("/api/typeOfCharges")]
    public class TypeOfChargesController : GenericController<TypeOfCharge>
    {
        private readonly DataContext _context;

        public TypeOfChargesController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public virtual ActionResult GetAllAsync([FromQuery] PaginationDTO pagination)
        {

            var queryable = _context.TypeOfCharges
                                    .Include(x=>x.SubTypeOfCharges)
                                    .AsQueryable();


            return Ok(queryable.ContaintAll(pagination, new TypeOfCharge())
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToList());

        }

        [HttpGet("totalPages")]
        public ActionResult GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.TypeOfCharges.AsQueryable();

            double count = queryable.ContaintAll(pagination, new TypeOfCharge()).Count();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }
    }
}

