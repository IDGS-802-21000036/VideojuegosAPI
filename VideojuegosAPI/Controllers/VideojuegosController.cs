using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideojuegosAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideojuegosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideojuegosController : ControllerBase
    {

        // Variable de conexion con BD
        private readonly BdVideojuegosContext _bd;

        // Constructor
        public VideojuegosController(BdVideojuegosContext bd)
        {
            _bd = bd;
        }

        // GET: api/<VideojuegosController>
        [HttpGet]
        public async Task<IActionResult> Get(string nombre = null)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return Ok(await _bd.Videojuegos.ToListAsync());
            }
            else {
                return Ok(await _bd.Videojuegos.Where(v =>
                    v.Nombre.Contains(nombre)
                    ).ToListAsync());
            }
            
        }

        // POST api/<VideojuegosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Videojuego videojuego)
        {
            if (videojuego != null)
            {
                if (videojuego.Nombre == null || videojuego.Desarrollador == null || videojuego.Anio == 0 || videojuego.Precio < 0 || videojuego.Imagen == null || videojuego.CategoriaId == 0)
                {
                    return BadRequest();
                }
                _bd.Videojuegos.Add(videojuego);
                await _bd.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = videojuego.Id }, videojuego);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<VideojuegosController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Videojuego videojuego)
        {
            if (videojuego == null || videojuego.Id != id)
            {
                return BadRequest();
            }

            Videojuego vj = _bd.Videojuegos.Find(id);
            if (vj != null)
            {
                vj.Nombre = videojuego.Nombre;
                vj.Desarrollador = videojuego.Desarrollador;
                vj.Anio = videojuego.Anio;
                vj.Precio = videojuego.Precio;
                vj.Imagen = videojuego.Imagen;
                vj.CategoriaId = videojuego.CategoriaId;
                _bd.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        // DELETE api/<VideojuegosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Videojuego vj = _bd.Videojuegos.Find(id);
            if (vj != null)
            {
                _bd.Videojuegos.Remove(vj);
                await _bd.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
