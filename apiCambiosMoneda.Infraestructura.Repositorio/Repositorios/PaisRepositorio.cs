using apiCambiosMoneda.Core.Interfaces.Repositorios;
using apiCambiosMoneda.Dominio.Entidades;
using apiCambiosMoneda.Infraestructura.Repositorio.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace apiCambiosMoneda.Infraestructura.Repositorio.Repositorios
{
    public class PaisRepositorio : IPaisRepositorio
    {
        private CambiosMonedaContext context;

        public PaisRepositorio(CambiosMonedaContext context)
        {
            this.context = context;
        }

        public async Task<Pais> Obtener(int Id)
        {
            return (Pais)(await context.Paises
                .Include(item => item.Moneda) // Incluye la moneda
                .FirstOrDefaultAsync(item => item.Id == Id));
        }

        public async Task<IEnumerable<Pais>> ObtenerTodos()
        {
            return await context.Paises
                .Include(item => item.Moneda) // Incluye la moneda
                .ToListAsync();
        }

        public async Task<IEnumerable<Pais>> Buscar(int Tipo, string Dato)
        {
            return await context.Paises
                                   .Where(item => (Tipo == 0 && item.Nombre.Contains(Dato))
                                   || (Tipo == 1 && item.CodigoAlfa2.Contains(Dato))
                                   || (Tipo == 2 && item.CodigoAlfa3.Contains(Dato))
                                   || (Tipo == 3 && item.Moneda.Nombre.Contains(Dato))) // Filtrar elementos 
                                   .Include(item => item.Moneda) // Incluye la moneda
                                   .ToListAsync(); // Convertir a una lista IEnumerable<Pais>
        }

        public async Task<Pais> Agregar(Pais Pais)
        {
            context.Paises.Add(Pais);
            await context.SaveChangesAsync();
            return Pais;
        }
        public async Task<Pais> Modificar(Pais Pais)
        {
            var paisExistente = await context.Paises.FindAsync(Pais.Id);
            if (paisExistente == null)
            {
                return null;
            }
            context.Entry(paisExistente).CurrentValues.SetValues(Pais);
            await context.SaveChangesAsync();
            return (Pais)(await context.Paises.FindAsync(Pais.Id));
        }

        public async Task<bool> Eliminar(int Id)
        {
            var paisExistente = await context.Paises.FindAsync(Id);
            if (paisExistente == null)
            {
                return false;
            }

            context.Paises.Remove(paisExistente);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
