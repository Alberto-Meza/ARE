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
    [Route("/api/paymentPeriods")]
    public class PaymentPeriodsController : GenericController<PaymentPeriod>
    {
		
        private readonly DataContext _context;

        public PaymentPeriodsController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpPost("GetAll")]
        public virtual ActionResult GetAllAsync([FromBody] PagFiltersDTO pagFiltersDTO)
        {

            var queryable = _context.PaymentPeriods
                                    .AsQueryable();


            return Ok(queryable.ContaintAll(pagFiltersDTO.Pagination, new PaymentPeriod()).WhereCondition(pagFiltersDTO.Filters, new PaymentPeriod())
                .OrderBy(x => x.Name)
                .Paginate(pagFiltersDTO.Pagination)
                .ToList());

        }

        [HttpPost("totalPages")]
        public ActionResult GetPages([FromBody] PagFiltersDTO pagFiltersDTO)
        {
            var queryable = _context.PaymentPeriods.AsQueryable();

            double count = queryable.ContaintAll(pagFiltersDTO.Pagination, new PaymentPeriod()).WhereCondition(pagFiltersDTO.Filters, new PaymentPeriod()).Count();
            double totalPages = Math.Ceiling(count / pagFiltersDTO.Pagination.RecordsNumber);
            return Ok(totalPages);
        }



    }
}

