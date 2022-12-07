using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using tl2_tp5_2022_nico89h.Models;

namespace tl2_tp5_2022_nico89h.Repositories
{
    public class RepositoryPedido:Repository<Pedidos>
    {
        public RepositoryPedido(IConfiguration configuration) : base(configuration)
        {
        }

        public override Pedidos buscarPorId(int id)
        {
            const string consulta = "select * from Pedido where Id = @id";

            try
            {
                using var conexion = new SqliteConnection(conexiondb);
                var peticion = new SqliteCommand(consulta, conexion);
                peticion.Parameters.AddWithValue("@id", id);
                conexion.Open();

                var salida = new Pedidos();
                using var reader = peticion.ExecuteReader();

                while (reader.Read())
                    salida = new Pedidos
                    {
                        Id1 = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Idcadete1 = reader.GetInt32(2)
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

        public override IEnumerable<Pedidos> GetAll()
        {
            //    throw new NotImplementedException
            const string consulta = "select * from Pedido";

            try
            {
                using var conexion = new SqliteConnection(conexiondb);
                var peticion = new SqliteCommand(consulta, conexion);
                conexion.Open();

                var salida = new List<Pedidos>();

                using var reader = peticion.ExecuteReader();

                while (reader.Read())
                {
                    var pedido = new Pedidos
                    {
                        Id1 = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Idcadete1 = reader.GetInt32(2)
                    };
                    salida.Add(pedido);
                }

                conexion.Close();
                return salida;
            }
            catch (Exception e)
            {
                //Logger.Debug("Error al buscar todos los cadetes - {Error}", e.Message);
                return new List<Pedidos>();
            }


        }

        public override void insertar(Pedidos dato)
        {
            const string consulta = "insert into Pedido nombre, Idcadete values (@nombre, @idCadete);";
            try
            {
                using var conexion = new SqliteConnection(conexiondb);
                var peticion = new SqliteCommand(consulta, conexion);
                conexion.Open();

                peticion.Parameters.AddWithValue("@nombre", dato.Nombre);
                peticion.Parameters.AddWithValue("@idCadete", dato.Idcadete1);
                // peticion.Parameters.AddWithValue("@cadeteria", entidad.Cadeteria);
                peticion.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                //Logger.Debug("Error al insertar el cadete {Id} - {Error}", entidad.Id, e.Message);

            }
        }
        public override void actualizarEntidad(Pedidos dato)
        {
            const string consulta =
                "update Pedidos set Idcadete = @idCadete where Id = @id";
            try
            {
                using var conexion = new SqliteConnection(conexiondb);
                var peticion = new SqliteCommand(consulta, conexion);
                conexion.Open();

                peticion.Parameters.AddWithValue("@id", dato.Id1);
                peticion.Parameters.AddWithValue("@idCadete", dato.Idcadete1);
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
            const string consulta ="delete from Pedido where Id = @id";

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


        //public IEnumerable<Pedido> BuscarTodosPorCliente(int id)
        //{
        //    const string consulta = "select * from Pedido where id_cliente = @id";
        //    return BuscarTodosPorEntidad(id, consulta);
        //}
        //busca los pedidos por id
        public IEnumerable<Pedidos> BuscarTodosPorCadete(int id)
        {
            const string consulta = "select * from Pedido where idCadete = @id";
            return BuscarTodosPorEntidad(id, consulta);
        }

        private IEnumerable<Pedidos> BuscarTodosPorEntidad(int id, string consulta)
        {
            try
            {
                using var conexion = new SqliteConnection(conexiondb);
                var peticion = new SqliteCommand(consulta, conexion);
                peticion.Parameters.AddWithValue("@id", id);
                conexion.Open();

                var salida = new List<Pedidos>();
                using var reader = peticion.ExecuteReader();
                while (reader.Read())
                {
                    var pedido = new Pedidos
                    {
                        Id1 = reader.GetInt32(0),
                        Idcadete1 = reader.IsDBNull(4) ? null : reader.GetInt32(4)
                    };
                    salida.Add(pedido);
                }

                conexion.Close();
                return salida;
            }
            catch (Exception e)
            {
                //Logger.Debug("Error al buscar todos los pedidos del cliente {Id}- {Error}", id, e.Message);
            }

            return new List<Pedidos>();
        }

    }
}
