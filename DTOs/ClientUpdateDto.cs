using System.ComponentModel.DataAnnotations;

namespace SimpleOrderManagementApi.DTOs
{
    public class ClientUpdateDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
    }
}
