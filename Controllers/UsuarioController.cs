using Final.Datos;
using Final.Entidades;
using Final.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpPost]
        [Route("api/AgregarUsuario")]
        public IActionResult AgregarUsuario([FromBody] EntEstudiante agregar)
        {
            //Verificar que existen los datos 
            if (agregar == null)
            {
                return NoContent();
            }
            else 
            { 
                //No regresa nada, nada mas guarda el usuario
                new DatosEstudiante().GuardarUsuario(agregar);
                return Ok();
            }
      
        }

        [HttpPost]
        [Route("api/EliminarUsuario")]
        public IActionResult EliminarUsuario([FromBody] EntEstudiante eliminar)
        {

            if (eliminar == null)
            {
                return NoContent();
            }
            else 
            {
                new DatosEstudiante().EliminarUsuario(eliminar);
                return Ok();
            }

        }
        [HttpPost]
        [Route("api/ModificarUsuario")]
        public IActionResult ModificarUsuario([FromBody] EntEstudiante modificar)
        {
            if (modificar == null)
            {
                return NoContent();
            }
            else
            {
                new DatosEstudiante().ModificarUsuario(modificar);
                return Ok();
            }
            
        }
        [HttpPost]
        [Route("api/ConsultarUsuario")]
        public IActionResult ConsultarUsuario([FromBody] EntEstudiante consulta)
        {
            if (consulta == null)
            {
                return NoContent();
            }
            else 
            {
                EntEstudiante entEstudiante = new DatosEstudiante().ConsultarUsuario(consulta);

                return Ok(entEstudiante);
            }

        }
    }
}
