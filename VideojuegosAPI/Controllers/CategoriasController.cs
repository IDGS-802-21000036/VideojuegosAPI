using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideojuegosAPI.Models;

namespace VideojuegosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly BdVideojuegosContext _bd;

        public CategoriasController(BdVideojuegosContext bd)
        {
            _bd = bd;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bd.Categorias.ToListAsync());
        }

    }
}
