using Final.Entidades;
using Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Final.Datos
{
    public class DatosFormulario : DatosBase
    {
        public List<EntPreguntas> ObtenerPreguntas()
        {
            var lista = context.VistaPreguntas.ToList();
            lista = lista.Where(c => c.IsEnabled == true).ToList();
            List<EntPreguntas> preguntas = mapperEntity.ToEntity<List<EntPreguntas>>(lista);
            return preguntas;
        }

        public List<EntOpcion> ObtenerOpciones() 
        {
            var option = context.OpcionesPreguntas.ToList();

            List<EntOpcion> opciones = mapperEntity.ToEntity<List<EntOpcion>>(option);
            return opciones;
        }

        public int GuardarRespuestas(EntFormulario res) {
          

            if (res.Respuesta == null)
            {
                return 0;
            }

            var existe = context.Formulario
                .Where(a => a.id_pregunta == res.Id_pregunta && a.id_trabajador == res.Id_trabajador).FirstOrDefault();
            
            //Si no existe agrega una nueva respuesta
            if (existe == null)
            {
                Formulario item = new Formulario();
                item.Respuesta = res.Respuesta;
                item.folio = res.Folio;
                item.Fecha = new DateOnly(res.Fecha.Value.Year, res.Fecha.Value.Month, res.Fecha.Value.Day);
                item.id_trabajador = res.Id_trabajador;
                item.id_pregunta = res.Id_pregunta;

                context.Formulario.Add(item);
                context.SaveChanges();
                return item.id_formulario;


            }

            //Si existe lo va a actualizar
            else 
            {
                existe.Respuesta = res.Respuesta;

                context.SaveChanges();
                return existe.id_formulario;
            }

            
        }
    }
}
