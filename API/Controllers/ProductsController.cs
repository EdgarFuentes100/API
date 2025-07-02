using System;
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
    public class ProductsController : Controller
    {
        private readonly AppDBContext _context;

        public ProductsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Products>> GetProductos()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Products>> PostProductos(Products P)
        {
            _context.Products.Add(P);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProductos),
                new { id = P.Id },
                P
            );
        }
    }
}
