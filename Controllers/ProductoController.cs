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
    public class ProductoController : ControllerBase
    {
        private readonly APIContext _context;

        public ProductoController(APIContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<productos>>> GetProducto()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<productos>> GetProducto(int id)
        {
            var Productos = await _context.Productos.FindAsync(id);

            if (Productos == null)
            {
                return NotFound();
            }
            return Productos;
        }


        [HttpPost]
        public async Task<ActionResult<productos>> PostEmpleado(productos productos)
        {
            _context.Productos.Add(productos);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = productos.Id }, productos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, productos productos)
        {
            if (id != productos.Id)
            {
                return BadRequest();
            }
            _context.Entry(productos).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var Producto = await _context.Productos.FindAsync(id);
            if (Producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(Producto);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
