using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleOrderManagementApi.Data;
using SimpleOrderManagementApi.Models;

namespace SimpleOrderManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        
        private readonly DataContext _context;

        public ProductosController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Producto>>> DameLosProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> DameUnProducto(int id)
        {
            var lista = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "iPhone 15", Precio = 20000m },
                new Producto { Id = 2, Nombre = "Laptop Gamer", Precio = 35000m },
                new Producto { Id = 3, Nombre = "Teclado Mecánico", Precio = 1500m }
            };

            var productoEncontrado = lista.FirstOrDefault(x => x.Id == id);

            if (productoEncontrado == null)
            {
                return NotFound();
            }

            return productoEncontrado;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> Crear(Producto producto)
        {
            _context.Productos.Add(producto);

            await _context.SaveChangesAsync();

            return Ok(producto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(int id, Producto productoActualizado)
        {
            var productoEnLaBase = await _context.Productos.FindAsync(id);

            if(productoEnLaBase == null)
            {
                return NotFound();
            }

            productoEnLaBase.Nombre = productoActualizado.Nombre;
            productoEnLaBase.Precio = productoActualizado.Precio;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult>  Borrar(int id) 
        {
            var producto = await _context.Productos.FindAsync(id);

            if( producto == null) 
            { 
                return NotFound(); 
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
