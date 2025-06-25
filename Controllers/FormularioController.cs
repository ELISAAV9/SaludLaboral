using Final.Datos;
using Final.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Final.Controllers
{
    public class FormularioController : Controller
    {
        [HttpPost]
        [Route("api/ObtenerPreguntas")]
        public IActionResult ObtenerPreguntas([FromBody] EntCapturaFormulario Captura)
        {
            if (Captura == null)
                return NoContent();
            else
            {

                List<EntPreguntas> entPreguntas = new DatosFormulario().ObtenerPreguntas();

                return Ok(entPreguntas);

            }
        }

        [HttpGet]
        [Route("api/ObtenerOpciones")]
        public IActionResult ObtenerOpciones()
        {

            List<EntOpcion> entOpcion = new DatosFormulario().ObtenerOpciones();

            return Ok(entOpcion);


        }

        [HttpPost]
        [Route("api/GuardarDatosFormulario")]
        public IActionResult GuardarDatosFormulario([FromBody] EntCapturaFormulario Captura)
        {
            if (Captura == null)
                return NoContent();
            else
            {              
                //Guadar empresa
                int idEmpresa = new DatosEmpresa().GuardarEmpresa(Captura.Empresa);

                // Guardar Trabajador
                //Se asigna el id de la empresa a trabajador
                Captura.Trabajador.Id_empresa = idEmpresa;
                int idTrabajador = new DatosTrabajador().GuardarTrabajador(Captura.Trabajador, Captura.Formulario[0].Folio);

                //Se asignan los id y se regresan los datos a la vista
                Captura.Empresa.Id_empresa = idEmpresa;
                Captura.Trabajador.Id_trabajador = idTrabajador;

                return Ok(Captura);

            }
        }

        [HttpPost]
        [Route("api/GuardarRespuestas")]
        public IActionResult GuardarRespuestas([FromBody] EntFormulario CapturaRes)
        {
            if (CapturaRes == null)
                return NoContent();
            else { 
            int idFormulario = new DatosFormulario().GuardarRespuestas(CapturaRes);
            return Ok(idFormulario);
            }
            
            
        }
    }
}
