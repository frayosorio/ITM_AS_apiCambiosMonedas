using apiCambiosMoneda.Core.Interfaces.Repositorios;
using apiCambiosMoneda.Core.Interfaces.Servicios;
using apiCambiosMoneda.Dominio.Entidades;

namespace apiCambiosMoneda.Aplicacion.Servicios
{
    public class MonedaServicio : IMonedaServicio
    {
        private readonly IMonedaRepositorio repositorio;

        public MonedaServicio(IMonedaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<IEnumerable<Moneda>> ObtenerTodos()
        {
            return repositorio.ObtenerTodos();
        }

        public Task<Moneda> Obtener(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Moneda>> Buscar(int Tipo, string Dato)
        {
            throw new NotImplementedException();
        }

        public Task<Moneda> Agregar(Moneda Moneda)
        {
            throw new NotImplementedException();
        }

        public Task<Moneda> Modificar(Moneda Moneda)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        /********** CAMBIOS **********/

        public Task<IEnumerable<CambioMoneda>> ObtenerCambios(int IdMoneda)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CambioMoneda>> BuscarCambio(int Tipo, string Dato)
        {
            throw new NotImplementedException();
        }

        public Task<Moneda> AgregarCambio(CambioMoneda Cambio)
        {
            throw new NotImplementedException();
        }

        public Task<Moneda> ModificarCambio(CambioMoneda Cambio)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarCambio(int IdMoneda, DateTime Fecha)
        {
            throw new NotImplementedException();
        }

        /********** CONSULTAS **********/

        public Task<CambioMoneda> ObtenerCambioActual(int idMoneda)
        {
            return repositorio.ObtenerCambioActual(idMoneda);
        }

        public Task<IEnumerable<CambioMoneda>> ObtenerHistorialCambios(int idMoneda, DateTime desde, DateTime hasta)
        {
            return repositorio.ObtenerHistorialCambios(idMoneda, desde, hasta);
        }

        public Task<IEnumerable<Pais>> ObtenerPaisesPorMoneda(int idMoneda)
        {
            return repositorio.ObtenerPaisesPorMoneda(idMoneda);
        }

    }
}
