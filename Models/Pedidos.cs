using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using tl2_tp5_2022_nico89h.ViewModels;

namespace tl2_tp5_2022_nico89h.Models
{
    public enum Tipo
    {
        fragil,
        normal
    }
    public class Pedidos
    {
        [Key]
        private int Id;
        [Required(ErrorMessage = "El nombre debe tener entre 5 y 50 caracteres")]
        [MaxLength(50)]
        [MinLength(5)]
        private string? nombre;
        [Required]
        private Tipo tipo;
        [ForeignKey("Cadetes")]
        private int? Idcadete;

        [DisplayName("Tipo de pedido")]
        public Tipo Tipo { get => tipo; set => tipo = value; }
        [DisplayName("Nombre")]
        public string? Nombre { get => nombre; set => nombre = value; }
        [DisplayName("Identificador")]
        public int Id1 { get => Id; set => Id = value; }
        [DisplayName("Id cadete")]
        public int? Idcadete1 { get => Idcadete; set => Idcadete = value; }



        //inicio de constructores
        public Pedidos()
        {
            //Idcantidad++;
            this.Id = 999;
            this.Nombre = "";
            this.tipo = Tipo.fragil;
        }

        public Pedidos(string? nombre, Tipo tipo, int id)
        {
            this.Id = id;
            Nombre = nombre;
            Tipo = tipo;
            Tipo = tipo;
            Nombre = nombre;
        }
    }
}