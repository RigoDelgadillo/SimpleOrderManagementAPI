namespace SimpleOrderManagementApi.Models
{
    public class Cliente
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public decimal Saldo { get; set; }

        public List<Pedido> Pedidos { get; set; }

    }
}
