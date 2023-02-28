using ARE.API.Data;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Controllers
{
    public class GenericRepository<T> : ControllerBase, IGenericRepository<T> where T : class,IEntity
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<ActionResult> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public virtual async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Set<T>().ToListAsync());
        }

        [HttpGet("{id:int}")]
        public virtual async Task<ActionResult> GetAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<ActionResult> PostAsync(T entity)
        {
            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return Ok(entity);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con esa configuracón.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpPut]
        public virtual async Task<ActionResult> PutAsync(T entity)
        {
            try
            {

                _context.Update(entity);
                await _context.SaveChangesAsync();
                return Ok(entity);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con esa configuracón.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


        /*[HttpGet]
        public virtual IActionResult GetExpresionAsync(Func<T,bool> predicate)
        {
            return Ok(_context.Set<T>().AsNoTracking().Where(predicate).ToList());
        }*/



    }
}

