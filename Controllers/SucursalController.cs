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
    public class SucursalController : ControllerBase
    {
        private readonly APIContext _context;

        public SucursalController(APIContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<sucursales>>> GetSucursal()
        {
            return await _context.Sucursales.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<sucursales>> GetSucursal(int id)
        {
            var Sucursales = await _context.Sucursales.FindAsync(id);

            if (Sucursales == null)
            {
                return NotFound();
            }
            return Sucursales;
        }


        [HttpPost]
        public async Task<ActionResult<sucursales>> PostSucursales(sucursales sucursal)
        {
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSucursal), new { id = sucursal.Id }, sucursal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursal(int id, sucursales sucursales)
        {
            if (id != sucursales.Id)
            {
                return BadRequest();
            }
            _context.Entry(sucursales).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            var Sucursal = await _context.Sucursales.FindAsync(id);
            if (Sucursal == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(Sucursal);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
