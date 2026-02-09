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
    public class PedidosController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> DameLosPedidos()
        {
            var listaPedidos = await _context.Pedidos.Include(p => p.Cliente).ToListAsync();

            return Ok(listaPedidos);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<List<Pedido>>> DamePedidosPorCliente(int clienteId)
        {
            var lista = await _context.Pedidos
                .Where(p => p.ClienteId == clienteId )
                .Include(p => p.Cliente)
                .ToListAsync();

            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> CrearPedido(PedidoCreateDto pedido)
        {
            var nuevoPedido = new Pedido
            {
                ClienteId = pedido.ClienteId,
                Fecha = DateTime.Now,
            };

            _context.Pedidos.Add(nuevoPedido);

            await _context.SaveChangesAsync();

            return Ok(nuevoPedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pedido>> EditarPedido(int id, PedidoCreateDto pedido)
        {
            var pedidoEnLaBase = await _context.Pedidos.FindAsync(id);

            if (pedidoEnLaBase == null)
            {
                return NotFound();
            }

            pedidoEnLaBase.ClienteId = pedido.ClienteId;

            await _context.SaveChangesAsync();

            return Ok(pedidoEnLaBase);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> EliminaPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if(pedido == null)
            {
                return NotFound();
            }
            _context.Pedidos.Remove(pedido);

            await _context.SaveChangesAsync();

            return Ok(pedido);
        }
    }
}
