using System.ComponentModel.DataAnnotations;

namespace SimpleOrderManagementApi.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Range(0.01, 100000)]
        public decimal Precio { get; set; }

        public List<PedidoProducto> PedidoProductos { get; set; }
    }
}
