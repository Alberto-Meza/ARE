using ARE.API.Data;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : GenericController<Country>
    {
        /* private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            
                return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }*/

        private readonly DataContext _context;

        public CountriesController(DataContext context) : base(context)
        {
            _context = context;
        }

        /*[HttpGet("All")]
        public virtual async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _context.Countries.Include(x=>x.States).ToListAsync());
        }
        */

        public override  async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Countries.Include(x => x.States).ToListAsync());
        }
        public override async Task<ActionResult> GetAsync(int id)
         {
             var entity = await _context.Countries
                                        .Include(x=>x.States!)
                                        .ThenInclude(x=>x.Cities)
                                        .FirstOrDefaultAsync(x => x.Id == id);
             if (entity == null)
             {
                 return NotFound();
             }

             return Ok(entity);
         }
    }
}

