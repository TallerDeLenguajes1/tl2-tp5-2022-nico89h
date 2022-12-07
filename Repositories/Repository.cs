using Microsoft.Data.Sqlite;
using System.Drawing.Printing;
using System.Text.Json.Serialization;
using tl2_tp5_2022_nico89h.Models;

namespace tl2_tp5_2022_nico89h.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        public abstract void actualizarEntidad(T dato);
        public  abstract IEnumerable<T> GetAll();
        public abstract void insertar(T dato);
        public abstract T buscarPorId(int Id);
        public abstract void eliminarEntidad(int id);

        private readonly IConfiguration? _config;
        protected readonly string conexiondb;
        //inicio de la clase repository
        //inicio de el constructor
        protected Repository(IConfiguration config)
        {
            this._config = config;
            this.conexiondb = config.GetConnectionString("ConnectionString");
        }
       


    }
}
