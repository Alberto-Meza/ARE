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
    [Route("/api/subTypeOfCharges")]
    public class SubTypeOfChargesController : GenericController<SubTypeOfCharge>
    {
        private readonly DataContext _context;

        public SubTypeOfChargesController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpPost("GetAll")]
        public virtual ActionResult GetAllAsync([FromBody] PagFiltersDTO pagFiltersDTO)
        {

            var queryable = _context.SubTypeOfCharges
                                    .Include(x=>x.TypeOfCharge)
                                    .AsQueryable();


            return Ok(queryable.ContaintAll(pagFiltersDTO.Pagination, new SubTypeOfCharge()).WhereCondition(pagFiltersDTO.Filters, new SubTypeOfCharge())
                .OrderBy(x => x.Name)
                .Paginate(pagFiltersDTO.Pagination)
                .ToList());

        }

        [HttpPost("totalPages")]
        public ActionResult GetPages([FromBody] PagFiltersDTO pagFiltersDTO)
        {
            var queryable = _context.SubTypeOfCharges.AsQueryable();

            double count = queryable.ContaintAll(pagFiltersDTO.Pagination, new SubTypeOfCharge()).WhereCondition(pagFiltersDTO.Filters, new SubTypeOfCharge()).Count();
            double totalPages = Math.Ceiling(count / pagFiltersDTO.Pagination.RecordsNumber);
            return Ok(totalPages);
        }


    }
}

