namespace tl2_tp5_2022_nico89h.Models
{
    public class Cadetes
    {
        //inicio de la clase cadete
        //private static int IdCantidad = 0;
        private int Id;
        private string? nombre;
        private ICollection<Pedidos>? pedidos;
        public Cadetes()
        {
            this.Id = 999;
            this.nombre = "";
            this.Pedidos = new List<Pedidos>();
        }
        public Cadetes(string nombre, int id)
        {
            this.Id = id;
            this.nombre = nombre;
            this.Pedidos = new List<Pedidos>();
        }

        //public Cadetes(string nombre, IEnumerable<Pedidos>? pedidos)
        //{
        //    IdCantidad++;
        //    Id1 = IdCantidad;
        //    Nombre = nombre;
        //    Pedidos = pedidos;
        //}

        public int Id1 { get => Id; set => Id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public ICollection<Pedidos>? Pedidos { get => pedidos; set => pedidos = value; }
    }
}
