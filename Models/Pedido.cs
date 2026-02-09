using System.ComponentModel.DataAnnotations;

namespace SimpleOrderManagementApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<PedidoProducto> PedidoProductos { get; set; }
    }
}
