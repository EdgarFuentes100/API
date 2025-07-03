using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TipoProductoController : Controller
    {
        private readonly AppDBContext _context;
        public TipoProductoController(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }

        /// Obtiene todos los tipos de productos
        [HttpGet("ListaDeTipoProducto")]
        public async Task<ActionResult<List<TipoProducto>>> getTipoProducto()
        {
            try
            {
                var tipo = _context.TipoProducto.ToList();
                return Ok(tipo);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, "Error al obtener los tipos productos.");
            }
        }

        /// Obtiene un tipo de producto por id
        [HttpGet("ObtenerTipoPorId/{id}")]
        public async Task<ActionResult<TipoProducto>> GetTipoPorId(int id)
        {
            try
            {
                var tipo = await _context.TipoProducto.FindAsync(id);
                if (tipo == null)
                    return NotFound();

                return tipo;
            }
            catch (System.Exception e)
            {
                return StatusCode(500, "Error al obtener el producto.");
            }
        }

        /// Obtiene todos los tipos de productos
        [HttpGet("CrearTipoProducto")]
        public async Task<ActionResult<TipoProducto>> PostTipo(TipoProducto tipoProducto)
        {
            try
            {
                var tipo = _context.TipoProducto.Add(tipoProducto);
                await _context.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(GetTipoPorId), new { id = tipoProducto.Id });
            }
            catch (System.Exception e)
            {
                return StatusCode(500, "Error al crear tipo producto.");
            }
        }
    }
}
