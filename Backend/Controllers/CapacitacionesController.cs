using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContext;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitacionesController : ControllerBase
    {
        private readonly AgoraContext _context;

        public CapacitacionesController(AgoraContext context)
        {
            _context = context;
        }

        // GET: api/Capacitaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capacitacion>>> GetCapacitaciones()
        {
            return await _context.Capacitaciones.ToListAsync();
        }

        // GET: api/Capacitaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capacitacion>> GetCapacitacion(int id)
        {
            var capacitacion = await _context.Capacitaciones.FindAsync(id);

            if (capacitacion == null)
            {
                return NotFound();
            }

            return capacitacion;
        }

        // PUT: api/Capacitaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacitacion(int id, Capacitacion capacitacion)
        {
            if (id != capacitacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(capacitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacitacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Capacitaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Capacitacion>> PostCapacitacion(Capacitacion capacitacion)
        {
            _context.Capacitaciones.Add(capacitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapacitacion", new { id = capacitacion.Id }, capacitacion);
        }

        // DELETE: api/Capacitaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCapacitacion(int id)
        {
            var capacitacion = await _context.Capacitaciones.FindAsync(id);
            if (capacitacion == null)
            {
                return NotFound();
            }

            capacitacion.IsDeleted = true; // Soft delete
            _context.Capacitaciones.Update(capacitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CapacitacionExists(int id)
        {
            return _context.Capacitaciones.Any(e => e.Id == id);
        }
        // DELETE: api/Capacitaciones/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCapacitacion(int id)
        {
            var capacitacion = await _context.Capacitaciones
                                             .IgnoreQueryFilters()
                                             .FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (capacitacion == null)
            {
                return NotFound();
            }

            capacitacion.IsDeleted = false; // Restore the soft-deleted record
            _context.Capacitaciones.Update(capacitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("deleteds/")]
        public async Task<ActionResult<IEnumerable<Capacitacion>>> GetCapacitacionesDeleteds()
        {
            return await _context.Capacitaciones.IgnoreQueryFilters().Where(c=>c.IsDeleted).ToListAsync();
        }
        
    }
}
