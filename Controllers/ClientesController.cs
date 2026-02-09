using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleOrderManagementApi.Data;
using SimpleOrderManagementApi.DTOs;
using SimpleOrderManagementApi.Models;

namespace SimpleOrderManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> DameLosClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> DameUnCliente(int id)
        {

            var clienteEncontrado = await _context.Clientes.FindAsync(id);

            if (clienteEncontrado == null)
            {
                return NotFound();
            }


            return clienteEncontrado;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Crear(Cliente cliente)
        {
            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(int id, ClientUpdateDTO clienteActualizado)
        {
            var clienteEnLaBase = await _context.Clientes.FindAsync(id);

            if (clienteEnLaBase == null)
            {
                return NotFound();
            }

            clienteEnLaBase.Nombre = clienteActualizado.Nombre;
            clienteEnLaBase.Apellido = clienteActualizado.Apellido;


            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Borrar(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
