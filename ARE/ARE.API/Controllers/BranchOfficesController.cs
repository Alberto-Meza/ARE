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
    [Route("/api/branchOffices")]
    public class BranchOfficesController : GenericController<BranchOffice>
    {
        private readonly DataContext _context;
        public BranchOfficesController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public virtual async Task<ActionResult> GetAllAsync([FromQuery] PaginationDTO pagination)
        {

            var queryable = _context.BranchOffices
                                    .Include(x => x.City)
                                    .AsQueryable();


            return Ok(await queryable.ContaintAll(pagination, new BranchOffice())
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync());

        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Countries.AsQueryable();

            double count = await queryable.ContaintAll(pagination, new BranchOffice()).CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }
    }
}

