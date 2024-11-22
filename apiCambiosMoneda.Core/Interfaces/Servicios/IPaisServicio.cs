using apiCambiosMoneda.Dominio.Entidades;

namespace apiCambiosPais.Core.Interfaces.Servicios
{
    public interface IPaisServicio
    {
        Task<Pais> Obtener(int Id);

        Task<IEnumerable<Pais>> ObtenerTodos();

        Task<IEnumerable<Pais>> Buscar(int Tipo, string Dato);

        Task<Pais> Agregar(Pais Pais);

        Task<Pais> Modificar(Pais Pais);

        Task<bool> Eliminar(int Id);
    }
}
