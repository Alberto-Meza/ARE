﻿using ARE.API.Data;
using ARE.API.Helpers;
using ARE.Shared.DTOs;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/employeeTypes")]
    public class EmployeeTypesControllers : GenericController<EmployeeType>
    {
        private readonly DataContext _context;
        public EmployeeTypesControllers(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public virtual ActionResult GetAllAsync([FromQuery] PaginationDTO pagination)
        {

            var queryable = _context.EmployeeTypes
                                    .AsQueryable();


            return Ok(queryable.ContaintAll(pagination, new EmployeeType())
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToList());

        }

        [HttpGet("totalPages")]
        public ActionResult GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.EmployeeTypes.AsQueryable();

            double count = queryable.ContaintAll(pagination, new EmployeeType()).Count();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }
    }
}

