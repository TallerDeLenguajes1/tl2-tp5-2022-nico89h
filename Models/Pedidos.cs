namespace tl2_tp4_2022_nico89h.Models
{
    public enum Tipo
    {
        fragil,
        normal
    }
    public class Pedidos
    {
        //inicio de la clase pedidos
        private int Id;
        private static int Idcantidad;
        private string? nombre;
        private Tipo tipo;

        public Pedidos()
        {
            Idcantidad++;
            this.Id1 = Idcantidad;
            this.Nombre = "";
            this.tipo = Tipo.fragil;
        }
        public Pedidos(string? nombre, Tipo tipo)
        {
            Idcantidad++;
            this.Id1 = Idcantidad;
            Nombre = nombre;
            Tipos = tipo;
        }

        public int Id1 { get => Id; set => Id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public Tipo Tipos { get => tipo; set => tipo = value; }
    }
}
