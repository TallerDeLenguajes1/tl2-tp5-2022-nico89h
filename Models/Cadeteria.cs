namespace tl2_tp5_2022_nico89h.Models
{
    public class Cadeteria
    {
        private int Id;
        private string Name="";
        private IEnumerable<Cadetes>? cadetes;

        public Cadeteria()
        {
            Name1 = "";
            this.Id = 0;
            this.cadetes = new List<Cadetes>();
        }
        public Cadeteria(string name, IEnumerable<Cadetes>? cadetesDos,int id)
        {
            this.Id=id;
            Name1 = name;
            this.cadetes = cadetesDos;
        }
        public string Name1 { get => Name; set => Name = value; }
        public IEnumerable<Cadetes>? Cadetes { get => cadetes; set => cadetes = value; }
        public int Id1 { get => Id; set => Id = value; }
    }
}
