using apiCambiosMoneda.Aplicacion.Servicios;
using apiCambiosMoneda.Core.Interfaces.Repositorios;
using apiCambiosMoneda.Core.Interfaces.Servicios;
using apiCambiosMoneda.Infraestructura.Repositorio.Contextos;
using apiCambiosMoneda.Infraestructura.Repositorio.Repositorios;
using apiCambiosPais.Core.Interfaces.Servicios;
using Microsoft.EntityFrameworkCore;

namespace apiCambiosMoneda.Presentacion.InyeccionDependencias
{
    public static class InyeccionDependencias
    {

        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios, IConfiguration configuracion)
        {
            //Agregar el DBContext
            servicios.AddDbContext<CambiosMonedaContext>(opcionesConstruccion =>
            {
                opcionesConstruccion.UseSqlServer(configuracion.GetConnectionString("CambiosMoneda"));
            });

            //Agregar los repositorios
            servicios.AddTransient<IPaisRepositorio, PaisRepositorio>();
            servicios.AddTransient<IMonedaRepositorio, MonedaRepositorio>();


            //Agregar los servicios
            servicios.AddTransient<IPaisServicio, PaisServicio>();
            servicios.AddTransient<IMonedaServicio, MonedaServicio>();


            servicios.AddSingleton<IConfiguration>(configuracion);

            return servicios;
        }
    }
}
