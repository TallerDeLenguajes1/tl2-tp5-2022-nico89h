namespace tl2_tp5_2022_nico89h.Repositories
{
    //inicio de interface generica
    public interface IRepository<T>
    {

        IEnumerable<T> GetAll(string nombre); //obtengo todos los datos
        void insertar(T dato);
        T buscarPorId(int Id);
        void eliminarEntidad(int id);
        void actualizarEntidad(T dato);
    
    }
}
