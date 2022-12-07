using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using tl2_tp5_2022_nico89h.Models;

namespace tl2_tp5_2022_nico89h.Repositories
{
    public class RepositoryCadete:Repository<Cadetes>
    {
        public RepositoryCadete(IConfiguration configuration) : base(configuration)
        {
            
        }

        public override Cadetes buscarPorId(int id)
        {
            const string consulta = "select * from Cadete where id_cadete = @id;";

            try
            {
                using var conexion = new SqliteConnection(conexiondb);
                var peticion = new SqliteCommand(consulta, conexion);
                peticion.Parameters.AddWithValue("@id", id);
                conexion.Open();

                var salida = new Cadetes();
                using var reader = peticion.ExecuteReader();

                while (reader.Read())
                    salida = new Cadetes
                    {
                        Id1 = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                        // Cadeteria = reader.IsDBNull(4) ? null : reader.GetInt32(4)
                    };
                conexion.Close();
                return salida;
            }
            catch (Exception e)
            {
                //throw e.Message("Erroe en la consulta");
                return null;
            }

            //return null;
        }

        public override IEnumerable<Cadetes> GetAll()
        {
        //    throw new NotImplementedException
            const string consulta = "select * from Cadete";

            try
            {
                using var conexion = new SqliteConnection(conexiondb);
                var peticion = new SqliteCommand(consulta, conexion);
                conexion.Open();

                var salida = new List<Cadetes>();
                
                using var reader = peticion.ExecuteReader();

                while (reader.Read())
                {
                    var cadete = new Cadetes
                    {
                        Id1 = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    };
                    salida.Add(cadete);
                }

                conexion.Close();
                return salida;
            }
            catch (Exception e)
            {
                //Logger.Debug("Error al buscar todos los cadetes - {Error}", e.Message);
                Console.WriteLine("Error en el coso");
                return new List<Cadetes>();
            }

            
        }

        public override void insertar(Cadetes dato)
        {
            const string consulta ="insert into Cadete nombre values (@nombre);";
            try
            {
                using var conexion = new SqliteConnection(conexiondb);
                var peticion = new SqliteCommand(consulta, conexion);
                conexion.Open();

                peticion.Parameters.AddWithValue("@nombre", dato.Nombre);
                // peticion.Parameters.AddWithValue("@cadeteria", entidad.Cadeteria);
                peticion.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                //Logger.Debug("Error al insertar el cadete {Id} - {Error}", entidad.Id, e.Message);
                Console.WriteLine("Error en el coso");
            }
        }

        public override void actualizarEntidad(Cadetes dato)
        {
            const string consulta =
                "update Cadete set nombre = @nombre where id_cadete = @id;";
            try
            {
                using var conexion = new SqliteConnection(conexiondb);
                var peticion = new SqliteCommand(consulta, conexion);
                conexion.Open();

                peticion.Parameters.AddWithValue("@id", dato.Id1);
                peticion.Parameters.AddWithValue("@nombre", dato.Nombre);
                peticion.ExecuteReader();
                conexion.Close();
            }
            catch (Exception e)
            {
                //Logger.Debug("Error al insertar el pedido {Id} - {Error}", entidad.Id, e.Message);
            }
        }

        public override void eliminarEntidad(int id)
        {
            const string consulta =
                "delete from Cadete where id_cadete = @id;";

            try
            {
                using var conexion = new SqliteConnection(conexiondb);
                var peticion = new SqliteCommand(consulta, conexion);
                peticion.Parameters.AddWithValue("@id", id);
                peticion.ExecuteReader();
                conexion.Close();
            }
            catch (Exception e)
            {
                //Logger.Debug("Error al eliminar el cadete {Id} - {Error}", id, e.Message);
            }
        }
    }
}
