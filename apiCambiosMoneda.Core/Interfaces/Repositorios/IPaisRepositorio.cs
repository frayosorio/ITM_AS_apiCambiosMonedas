using apiCambiosMoneda.Dominio.Entidades;

namespace apiCambiosMoneda.Core.Interfaces.Repositorios
{
    public interface IPaisRepositorio
    {
        Task<IEnumerable<Pais>> ObtenerTodos();

        Task<Pais> Obtener(int Id);

        Task<IEnumerable<Pais>> Buscar(int Tipo, string Dato);

        Task<Pais> Agregar(Pais Pais);

        Task<Pais> Modificar(Pais Pais);

        Task<bool> Eliminar(int Id);
    }
}
