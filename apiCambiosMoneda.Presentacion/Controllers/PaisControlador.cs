using apiCambiosMoneda.Dominio.Entidades;
using apiCambiosPais.Core.Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace apiCambiosMoneda.Presentacion.Controllers
{
    [ApiController]
    [Route("api/paises")]
    public class PaisControlador : ControllerBase
    {
        private readonly IPaisServicio servicio;

        public PaisControlador(IPaisServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Pais>>> ObtenerTodos()
        {
            return Ok(await servicio.ObtenerTodos());
        }

        [HttpGet("obtener/{Id}")]
        public async Task<ActionResult<Pais>> Obtener(int Id)
        {
            return Ok(await servicio.Obtener(Id));
        }

        [HttpGet("buscar/{Tipo}/{Dato}")]
        public async Task<ActionResult<Pais>> Buscar(int Tipo, string Dato)
        {
            return Ok(await servicio.Buscar(Tipo, Dato));
        }

        [HttpPost("agregar")]
        public async Task<ActionResult<Pais>> Agregar([FromBody] Pais Pais)
        {
            return Ok(await servicio.Agregar(Pais));
        }

        [HttpPut("modificar")]
        public async Task<ActionResult<Pais>> Modificar([FromBody] Pais Pais)
        {
            return Ok(await servicio.Modificar(Pais));
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<ActionResult<bool>> Eliminar(int Id)
        {
            return Ok(await servicio.Eliminar(Id));
        }
    }
}
