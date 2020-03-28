using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacturacionWebApi.Data;
using FacturacionWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturacionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        private readonly APIContext _context;

        public AlmacenController(APIContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<almacenes>>> GetAlmacen()
        {
            return await _context.Almacenes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<almacenes>> GetAlmacen(int id)
        {
            var Almacenes = await _context.Almacenes.FindAsync(id);

            if (Almacenes == null)
            {
                return NotFound();
            }
            return Almacenes;
        }


        [HttpPost]
        public async Task<ActionResult<almacenes>> PostAlmacen(almacenes almacen)
        {
            _context.Almacenes.Add(almacen);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlmacen), new { id = almacen.Id }, almacen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlmacen(int id, almacenes almacen)
        {
            if (id != almacen.Id)
            {
                return BadRequest();
            }
            _context.Entry(almacen).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlmacen(int id)
        {
            var Almacen = await _context.Almacenes.FindAsync(id);
            if (Almacen == null)
            {
                return NotFound();
            }

            _context.Almacenes.Remove(Almacen);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
