using System.ComponentModel.DataAnnotations;

namespace SimpleOrderManagementApi.DTOs
{
    public class PedidoCreateDto
    {
        [Required]
        public int ClienteId { get; set; }
    }
}
