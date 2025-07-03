using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Context;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ProductsController(AppDBContext context)
        {
            _context = context;
        }

        /// Obtiene todos los productos con su tipo asociado.
        [HttpGet("ListaDeProductos")]
        public async Task<ActionResult<List<Products>>> GetProductos()
        {
            try
            {
                var productos = await _context.Products
                                             .Include(p => p.TipoProducto)
                                             .ToListAsync();
                return Ok(productos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Error al obtener los productos.");
            }
        }

        /// Obtiene un producto por su ID.
        [HttpGet("ObtenerProductoPorId/{id}")]
        public async Task<ActionResult<Products>> productoId(int id)
        {
            try
            {
                var producto = await _context.Products
                                             .Include(p => p.TipoProducto)
                                             .FirstOrDefaultAsync(p => p.Id == id);

                if (producto == null)
                    return NotFound();

                return Ok(producto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Error al obtener el producto.");
            }
        }

        /// Crea un nuevo producto.
        [HttpPost("CrearProducto")]
        public async Task<ActionResult<Products>> PostProductos(Products P)
        {
            try
            {
                _context.Products.Add(P);
                await _context.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(productoId),
                    new { id = P.Id },
                    P
                );
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Error al crear el producto.");
            }
        }

        /// Actualiza un producto existente.
        [HttpPut("ActualizarProducto/{id}")]
        public async Task<IActionResult> PutProducto(int id, Products P)
        {
            if (id != P.Id)
                return BadRequest("El ID del producto no coincide.");

            _context.Entry(P).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Error al actualizar el producto.");
            }
        }

        /// Elimina un producto por su ID.
        [HttpDelete("EliminarProducto/{id}")]
        public async Task<IActionResult> deleteProducto(int id)
        {
            try
            {
                var producto = await _context.Products.FindAsync(id);

                if (producto == null)
                    return NotFound();

                _context.Products.Remove(producto);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Error al eliminar el producto.");
            }
        }
    }
}
