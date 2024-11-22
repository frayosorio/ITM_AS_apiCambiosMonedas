
using apiCambiosMoneda.Aplicacion.Servicios;
using apiCambiosMoneda.Core.Interfaces.Repositorios;
using apiCambiosMoneda.Core.Interfaces.Servicios;
using apiCambiosMoneda.Dominio.Entidades;
using Moq;

namespace apiCambiosMoneda.Test
{
    public class CambioMonedaServicioTest
    {

        private readonly Mock<IMonedaRepositorio> monedaRepositorioMock;
        private readonly IMonedaServicio monedaServicio;

        public CambioMonedaServicioTest()
        {
            monedaRepositorioMock = new Mock<IMonedaRepositorio>();
            monedaServicio = new MonedaServicio(monedaRepositorioMock.Object);
        }

        [Fact]
        public async void ObtenerHistorialCambios_RetornandoListaDeCambios()
        {
            //Arrange
            var idMoneda = 35;
            var desde = new DateTime(2024, 5, 15);
            var hasta = new DateTime(2024, 5, 31);

            var listaCambios = new List<CambioMoneda>
            {
                new CambioMoneda { IdMoneda = idMoneda, Fecha=new DateTime(2024, 5, 15), Cambio=4050 },
                new CambioMoneda { IdMoneda = idMoneda, Fecha=new DateTime(2024, 5, 16), Cambio=4060 },
                new CambioMoneda { IdMoneda = idMoneda, Fecha=new DateTime(2024, 5, 17), Cambio=4100 },
                new CambioMoneda { IdMoneda = idMoneda, Fecha=new DateTime(2024, 5, 18), Cambio=4050 },
                new CambioMoneda { IdMoneda = idMoneda, Fecha=new DateTime(2024, 5, 19), Cambio=4052 }
            }.AsEnumerable();

            monedaRepositorioMock.Setup(repositorio => repositorio.ObtenerHistorialCambios(idMoneda, desde, hasta))
                .ReturnsAsync(listaCambios);

            //Act
            var resultado = await monedaServicio.ObtenerHistorialCambios(idMoneda, desde, hasta);

            //Assert
            Assert.Equal(5, resultado.ToList().Count);
            Assert.Equal(4060, resultado.ToList()[1].Cambio);
            Assert.Equal(4052, resultado.Last().Cambio);
        }

        [Fact]
        public async void ObtenerHistorialCambios_RepositorioRetornandoListaVacia()
        {
            //Arrange
            var idMoneda = 35;
            var desde = new DateTime(2024, 5, 15);
            var hasta = new DateTime(2024, 5, 31);

            monedaRepositorioMock.Setup(repositorio => repositorio.ObtenerHistorialCambios(idMoneda, desde, hasta))
                .ReturnsAsync(new List<CambioMoneda>());

            //Act
            var resultado = await monedaServicio.ObtenerHistorialCambios(idMoneda, desde, hasta);

            //Assert
            Assert.Empty(resultado);
        }

        [Fact]
        public async void ObtenerCambioActual_RetornandoUltimoCambio()
        {
            //Arrange
            var idMoneda = 35;
            var cambioMonedaActual = new CambioMoneda { IdMoneda = idMoneda, Fecha = new DateTime(2024, 5, 15), Cambio = 4050 };

            monedaRepositorioMock.Setup(repositorio => repositorio.ObtenerCambioActual(idMoneda))
                .ReturnsAsync(cambioMonedaActual);

            //Act
            var resultado = await monedaServicio.ObtenerCambioActual(idMoneda);

            //Assert
            Assert.NotNull(resultado);
            Assert.Equal(4050, resultado.Cambio);
        }

        [Fact]
        public async void ObtenerPaisesPorMoneda_RetornandoListaDePaises()
        {
            //Arrange
            var idMoneda = 20;
            var listaPaises = new List<Pais>
            {
                new Pais{ Id=1, Nombre="Estados Unidos", CodigoAlfa2="US", IdMoneda=idMoneda },
                new Pais{ Id=2, Nombre="Ecuador", CodigoAlfa2="EC", IdMoneda=idMoneda },
                new Pais{ Id=3, Nombre="Panamá", CodigoAlfa2="PY", IdMoneda=idMoneda }
            }.AsEnumerable();

            monedaRepositorioMock.Setup(repositorio => repositorio.ObtenerPaisesPorMoneda(idMoneda))
                .ReturnsAsync(listaPaises);

            //Act
            var resultado = await monedaServicio.ObtenerPaisesPorMoneda(idMoneda);

            //Assert
            Assert.Equal(3, resultado.ToList().Count);
            Assert.Equal("Estados Unidos", resultado.ToList().First().Nombre);
            Assert.Equal("EC", resultado.ToList()[1].CodigoAlfa2);
        }

        [Fact]
        public async void ObtenerCambioActual_NoEncontrandoCambio_Y_RetornandoNulo()
        {
            //Arrange
            var idMoneda = 30;

            monedaRepositorioMock.Setup(repositorio => repositorio.ObtenerCambioActual(idMoneda))
                .ReturnsAsync((CambioMoneda)null);

            //Act
            var resultado = await monedaServicio.ObtenerCambioActual(idMoneda);

            //Assert
            Assert.Null(resultado);
            monedaRepositorioMock.Verify(repositorio => repositorio.ObtenerCambioActual(idMoneda), Times.Once);
        }

        [Fact]
        public async void ObtenerCambioActual_RepositorioLanzandoExcepcion()
        {
            //Arrange
            var idMoneda = 30;
            monedaRepositorioMock.Setup(repositorio => repositorio.ObtenerCambioActual(idMoneda))
                .ThrowsAsync(new Exception("Error al obtener el cambio actual"));

            //Act y Assert
            await Assert.ThrowsAsync<Exception>(() => monedaServicio.ObtenerCambioActual(idMoneda));

        }

    }
}
