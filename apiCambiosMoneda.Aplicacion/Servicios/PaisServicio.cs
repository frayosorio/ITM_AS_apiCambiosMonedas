using apiCambiosMoneda.Core.Interfaces.Repositorios;
using apiCambiosMoneda.Dominio.Entidades;
using apiCambiosPais.Core.Interfaces.Servicios;

namespace apiCambiosMoneda.Aplicacion.Servicios
{
    public class PaisServicio : IPaisServicio
    {
        private readonly IPaisRepositorio repositorio;

        public PaisServicio(IPaisRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Pais> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Pais>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
        public async Task<IEnumerable<Pais>> Buscar(int Tipo, string Dato)
        {
            return await repositorio.Buscar(Tipo, Dato);
        }

        public async Task<Pais> Agregar(Pais Pais)
        {
            return await repositorio.Agregar(Pais);
        }

        public async Task<Pais> Modificar(Pais Pais)
        {
            return await repositorio.Modificar(Pais);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

    }
}
