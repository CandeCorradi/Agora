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
    public class TiposInscripcionesController : ControllerBase
    {
        private readonly AgoraContext _context;

        public TiposInscripcionesController(AgoraContext context)
        {
            _context = context;
        }

        // GET: api/TipoInscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoInscripcion>>> GetTipoInscripciones()
        {
            return await _context.TipoInscripciones.ToListAsync();
        }

        // GET: api/TipoInscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoInscripcion>> GetTipoInscripcion(int id)
        {
            var tipoInscripcion = await _context.TipoInscripciones.FindAsync(id);

            if (tipoInscripcion == null)
            {
                return NotFound();
            }

            return tipoInscripcion;
        }

        // PUT: api/TipoInscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoInscripcion(int id, TipoInscripcion tipoInscripcion)
        {
            if (id != tipoInscripcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoInscripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoInscripcionExists(id))
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

        // POST: api/TipoInscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoInscripcion>> PostTipoInscripcion(TipoInscripcion tipoInscripcion)
        {
            _context.TipoInscripciones.Add(tipoInscripcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoInscripcion", new { id = tipoInscripcion.Id }, tipoInscripcion);
        }

        // DELETE: api/TipoInscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoInscripcion(int id)
        {
            var tipoInscripcion = await _context.TipoInscripciones.FindAsync(id);
            if (tipoInscripcion == null)
            {
                return NotFound();
            }

            _context.TipoInscripciones.Remove(tipoInscripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoInscripcionExists(int id)
        {
            return _context.TipoInscripciones.Any(e => e.Id == id);
        }
       

        // DELETE: api/TipoInscripciones/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreTipoInscripciones(int id)
        {
            var tipoInscripciones = await _context.TipoInscripciones
                                             .IgnoreQueryFilters()
                                             .FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (tipoInscripciones == null)
            {
                return NotFound();
            }

            tipoInscripciones.IsDeleted = false; // Restore the soft-deleted record
            _context.TipoInscripciones.Update(tipoInscripciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("deleteds/")]
        public async Task<ActionResult<IEnumerable<TipoInscripcion>>> GetTipoInscripcionesDeleteds()
        {
            return await _context.TipoInscripciones.IgnoreQueryFilters().Where(c => c.IsDeleted).ToListAsync();
        }
    }
}
