using System;
using ARE.API.Data;
using ARE.Shared.DTOs;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/pendingAssistances")]
    public class PendingAssistancesController:ControllerBase
    {
        private readonly DataContext _context;

        public PendingAssistancesController(DataContext context)
		{
            _context = context;
        }


        [HttpGet("GetPendingAssitances")]
        public async Task<ActionResult> GetPendingAssitances(int StudentID)
        {
            
            if (!_context.Students.Any(x => x.Id == StudentID))
            {
                return NotFound();
            }

            return Ok(await _context.PendingAssistances
                                    .Include(x=> x.Assistance)
                                    .Include(x=>x.SubTypeOfCharge)
                                    .Where(x => x.Assistance.StudentId == StudentID).ToListAsync());
        }
    }
}

