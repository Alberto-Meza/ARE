using System;
using ARE.API.Data;
using ARE.Shared.DTOs;
using ARE.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Controllers
{
    [ApiController]
    [Route("/api/assistances")]
    public class AssistancesController : ControllerBase
    {
        private readonly DataContext _context;

        public AssistancesController(DataContext context) 
        {
            _context = context;
        }


        [HttpPost("Check")]
        public ActionResult Check([FromBody] Assistance model)
        {
            /*var entity = _context.Assistances.FirstOrDefaultAsync(x => x.StudentId == model.StudentId && x.EntryDate.Value.Date == model.EntryDate.Value.Date);

            if (entity.Result == null) { //CHECADA ENTRADA




                Assistance Check = new Assistance() { StudentId = model.StudentId, EntryDate = model.EntryDate };
                _context.Add(Check);
            }
            else if (entity.Result != null && model.EntryDate > entity.Result.EntryDate.Value.AddMinutes(30))
            { //CHECADA SALIDA
                entity.Result.ExitDate = model.EntryDate;
                _context.Update(entity.Result);
            }


            await _context.SaveChangesAsync();
            return Ok(entity.Result);
            */
            return Ok(new Business(_context).CheckAlumno(model));

        }

    }
}

