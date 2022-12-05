namespace tl2_tp5_2022_nico89h.Models
{
    public class Cadeteria
    {
        private string Name="";
        private IEnumerable<Cadetes>? cadetes;

        public Cadeteria()
        {
            Name1 = "";
            this.cadetes = new List<Cadetes>();
        }
        public Cadeteria(string name, IEnumerable<Cadetes>? cadetesDos)
        {
            Name1 = name;
            this.cadetes = cadetesDos;
        }

        public string Name1 { get => Name; set => Name = value; }
        public IEnumerable<Cadetes>? Cadetes { get => cadetes; set => cadetes = value; }
    }
}
