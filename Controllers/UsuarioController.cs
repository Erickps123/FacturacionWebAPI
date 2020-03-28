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
    public class UsuarioController : ControllerBase
    {
        private readonly APIContext _context;

        public UsuarioController(APIContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<usuarios>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<usuarios>> GetUsuario(int id)
        {
            var Usuarios = await _context.Usuarios.FindAsync(id);

            if (Usuarios == null)
            {
                return NotFound();
            }
            return Usuarios;
        }


        [HttpPost]
        public async Task<ActionResult<usuarios>> PostUsuario(usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, usuarios usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(Usuario);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
