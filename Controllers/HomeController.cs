using System.Diagnostics;
using Final.Datos;
using Final.Entidades;
using Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{

    public class HomeController : Controller
    {
        [HttpGet]
        [Route("api/test")]

        public IActionResult test()
        {
            return Ok("hola");
        }

        [HttpPost]
        [Route("api/login")]
        public IActionResult login([FromBody] EntEstudiante Estudiante)
        {
            if (Estudiante == null)
                return NoContent();
            else
            {
                EntEstudiante entEstudiante = new DatosEstudiante().ValidaUsuario(Estudiante);

                return Ok(entEstudiante);

            }
        }

    }
}
