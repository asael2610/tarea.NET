using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;


namespace ApiEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly Conexiones _context;

        public ClientesController(Conexiones context)
        {
            _context = context;
        }

   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetClientes()
        {
          if (_context.Estudiante == null)
          {
              return NotFound();
          }
            return await _context.Estudiante.ToListAsync();
        }

  
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetClientes(int id)
        {
          if (_context.Estudiante == null)
          {
              return NotFound();
          }
            var clientes = await _context.Estudiante.FindAsync(id);

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiantes)
        {
            if (id != estudiantes.id_estudiante)
            {
                return BadRequest();
            }

            _context.Entry(estudiantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
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

    
   
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostClientes(Estudiante estudiantes)
        {
          if (_context.Estudiante == null)
          {
              return Problem("Entity set 'Conexiones.Clientes'  is null.");
          }
            _context.Estudiante.Add(estudiantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientes", new { id = estudiantes.id_estudiante }, estudiantes);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            if (_context.Estudiante == null)
            {
                return NotFound();
            }
            var estudiantes = await _context.Estudiante.FindAsync(id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            _context.Estudiante.Remove(estudiantes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientesExists(int id)
        {
            return (_context.Estudiante?.Any(e => e.id_estudiante == id)).GetValueOrDefault();
        }
    }
}