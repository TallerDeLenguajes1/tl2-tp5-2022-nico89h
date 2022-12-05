using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp5_2022_nico89h.Models;

namespace tl2_tp5_2022_nico89h.ViewModels
{
    public class CadetesView
    {
        //inico de el view model
        //private static int IdCantidad = 0;
        [Key]
        private int Id;
        [MaxLength(50)]
        [MinLength(5)]
        [Required(ErrorMessage = "El nombre debe tener entre 5 y 50 caracteres")]
        
        private string? nombre;

        private ICollection<PedidosView>? pedidos;
        [DisplayName("Nombre")]
        public string? Nombre { get => nombre; set => nombre = value; }
        [DisplayName("Pedidos")]
        public ICollection<PedidosView>? Pedidos { get => pedidos; set => pedidos = value; }
        [DisplayName("Identi")]
        public int Id1 { get => Id; set => Id = value; }

        public CadetesView()
        {
            //IdCantidad++;
            this.Id = 999;
            this.Nombre = "";
            this.Pedidos = new List<PedidosView>();
        }
        public CadetesView(string nombre, int id)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Pedidos = new List<PedidosView>();
        }
        public void agregarPedido(PedidosView pedido)
        {
            Pedidos.Add(pedido);
        }

    }
}
