using Final.Datos;
using Final.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class TrabajadorController : Controller
    {
        [HttpPost]
        [Route("api/ConsultarTrabajador")]
        public IActionResult ConsultarTrabajador([FromBody] EntTrabajador consulta)
        {
            if (consulta == null)
            {
                return NoContent();
            }
            else
            {
                List<EntTrabajador> entTrabajador = new DatosTrabajador().ConsultarTrabajador(consulta);

                return Ok(entTrabajador);
            }

        }
    }
}
