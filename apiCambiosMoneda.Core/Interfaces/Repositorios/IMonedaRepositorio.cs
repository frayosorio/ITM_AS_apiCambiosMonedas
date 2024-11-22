using apiCambiosMoneda.Dominio.Entidades;

namespace apiCambiosMoneda.Core.Interfaces.Repositorios
{
    public interface IMonedaRepositorio
    {
        Task<IEnumerable<Moneda>> ObtenerTodos();

        Task<Moneda> Obtener(int Id);

        Task<IEnumerable<Moneda>> Buscar(int Tipo, string Dato);

        Task<Moneda> Agregar(Moneda Moneda);

        Task<Moneda> Modificar(Moneda Moneda);

        Task<bool> Eliminar(int Id);

        /********** CAMBIOS **********/

        Task<IEnumerable<CambioMoneda>> ObtenerCambios(int IdMoneda);

        Task<CambioMoneda> BuscarCambio(int IdMoneda, DateTime Fecha);

        Task<CambioMoneda> AgregarCambio(CambioMoneda Cambio);

        Task<CambioMoneda> ModificarCambio(CambioMoneda Cambio);

        Task<bool> EliminarCambio(int IdMoneda, DateTime Fecha);

        /********** CONSULTAS **********/

        Task<IEnumerable<CambioMoneda>> ObtenerHistorialCambios(int idMoneda, DateTime desde, DateTime hasta);

        Task<CambioMoneda> ObtenerCambioActual(int idMoneda);

        Task<IEnumerable<Pais>> ObtenerPaisesPorMoneda(int idMoneda);

    }
}
