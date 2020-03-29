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
    public class FacturaController : ControllerBase
    {
        private readonly APIContext _context;

        public FacturaController(APIContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<facturas>>> GetFactura()
        {
            return await _context.Facturas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<facturas>> GetFactura(int id)
        {
            var Facturas = await _context.Facturas.FindAsync(id);

            if (Facturas == null)
            {
                return NotFound();
            }
            return Facturas;
        }


        [HttpPost]
        public async Task<ActionResult<facturas>> PostFactura(facturas facturas)
        {
            _context.Facturas.Add(facturas);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFactura), new { id = facturas.Id }, facturas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, facturas facturas)
        {
            if (id != facturas.Id)
            {
                return BadRequest();
            }
            _context.Entry(facturas).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var Facturas = await _context.Facturas.FindAsync(id);
            if (Facturas == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(Facturas);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
