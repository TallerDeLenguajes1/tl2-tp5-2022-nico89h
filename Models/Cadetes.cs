namespace tl2_tp4_2022_nico89h.Models
{
    public class Cadetes
    {
        //inicio de la clase cadete
        private static int IdCantidad=0;
        private int Id;
        private string? nombre;
        private IEnumerable<Pedidos>? pedidos;
        public Cadetes()
        {
            IdCantidad++;
            this.Id = IdCantidad;
            this.nombre = "";
            this.Pedidos = new List<Pedidos>();
        }
        public Cadetes(string nombre)
        {
            IdCantidad++;
            this.Id = IdCantidad;
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
        public IEnumerable<Pedidos>? Pedidos { get => pedidos; set => pedidos = value; }


    }
}
