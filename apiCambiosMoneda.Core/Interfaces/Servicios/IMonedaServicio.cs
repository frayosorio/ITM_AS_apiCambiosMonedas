using apiCambiosMoneda.Dominio.Entidades;

namespace apiCambiosMoneda.Core.Interfaces.Servicios
{
    public interface IMonedaServicio
    {
        Task<Moneda> Obtener(int Id);

        Task<IEnumerable<Moneda>> ObtenerTodos();

        Task<IEnumerable<Moneda>> Buscar(int Tipo, string Dato);

        Task<Moneda> Agregar(Moneda Moneda);

        Task<Moneda> Modificar(Moneda Moneda);

        Task<bool> Eliminar(int Id);

        /********** CAMBIOS **********/

        Task<IEnumerable<CambioMoneda>> ObtenerCambios(int IdMoneda);

        Task<IEnumerable<CambioMoneda>> BuscarCambio(int Tipo, string Dato);

        Task<Moneda> AgregarCambio(CambioMoneda Cambio);

        Task<Moneda> ModificarCambio(CambioMoneda Cambio);

        Task<bool> EliminarCambio(int IdMoneda, DateTime Fecha);

        /********** CONSULTAS **********/

        Task<IEnumerable<CambioMoneda>> ObtenerHistorialCambios(int idMoneda, DateTime desde, DateTime hasta);

        Task<CambioMoneda> ObtenerCambioActual(int idMoneda);

        Task<IEnumerable<Pais>> ObtenerPaisesPorMoneda(int idMoneda);
    }
}
