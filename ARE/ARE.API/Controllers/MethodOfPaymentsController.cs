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
    [Route("/api/methodOfPayments")]
    public class MethodOfPaymentsController : GenericController<MethodOfPayment>
    {
        private readonly DataContext _context;

        public MethodOfPaymentsController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpPost("GetAll")]
        public virtual ActionResult GetAllAsync([FromBody] PagFiltersDTO pagFiltersDTO)
        {

            var queryable = _context.MethodOfPayments
                                    .AsQueryable();


            return Ok(queryable.ContaintAll(pagFiltersDTO.Pagination, new MethodOfPayment()).WhereCondition(pagFiltersDTO.Filters, new MethodOfPayment())
                .OrderBy(x => x.Name)
                .Paginate(pagFiltersDTO.Pagination)
                .ToList());

        }

        [HttpPost("totalPages")]
        public ActionResult GetPages([FromBody] PagFiltersDTO pagFiltersDTO)
        {
            var queryable = _context.MethodOfPayments.AsQueryable();

            double count = queryable.ContaintAll(pagFiltersDTO.Pagination, new MethodOfPayment()).WhereCondition(pagFiltersDTO.Filters, new MethodOfPayment()).Count();
            double totalPages = Math.Ceiling(count / pagFiltersDTO.Pagination.RecordsNumber);
            return Ok(totalPages);
        }
    }
}

