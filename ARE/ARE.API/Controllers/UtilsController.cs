using System;
using ARE.API.Data;
using ARE.Shared.DTOs;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/utils")]
    public class UtilsController : ControllerBase
    {
        private readonly DataContext _context;

        public UtilsController(DataContext context)
        {
            _context = context;
        }



        [HttpGet("GetCombo")]
        public virtual ActionResult GetAsync(string name)
        {
            return Ok(new Business(_context).GetCombo(name));
        }

        [HttpPost("GetComboByFilter")]
        public virtual ActionResult GetAsync(string name, [FromBody] List<FilterDTO> Filters)
        {
            return Ok(new Business(_context).GetComboByFilter(name, Filters));
        }

    }
}

