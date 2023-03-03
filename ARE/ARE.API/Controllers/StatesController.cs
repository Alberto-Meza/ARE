using System;
using ARE.API.Data;
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

        /*public override async Task<ActionResult> GetAsync(int id)
        {
            var entity = await _context.States
                                        .Include(x => x.Country)
                                        .Include(x => x.Cities)
                                       .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }*/

        [HttpGet("ByID/{id:int}")]
        public virtual async Task<ActionResult> GetAllAsync(int id)
        {
            var entity = await _context.States
                                        .Include(x => x.Country)
                                        .Include(x => x.Cities)
                                       .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
        
        /* public override async Task<ActionResult> GetAsync()
         {
             return Ok(await _context.States
                                     .Include(x => x.Country)
                                     .Include(x=>x.Cities)
                                     .ToListAsync());
         }

         
        */

    }
}

