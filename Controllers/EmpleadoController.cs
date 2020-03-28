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
    public class EmpleadoController : ControllerBase
    {
        private readonly APIContext _context;

        public EmpleadoController(APIContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<empleados>>> GetEmpleado()
        {
            return await _context.Empleados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<empleados>> GetEmpleado(int id)
        {
            var Empleados = await _context.Empleados.FindAsync(id);

            if (Empleados == null)
            {
                return NotFound();
            }
            return Empleados;
        }


        [HttpPost]
        public async Task<ActionResult<empleados>> PostEmpleado(empleados empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id }, empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, empleados empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }
            _context.Entry(empleado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var Empleado = await _context.Empleados.FindAsync(id);
            if (Empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(Empleado);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
