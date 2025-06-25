using Final.Entidades;
using Final.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace Final.Datos
{
    public class DatosTrabajador : DatosBase
    {
        public int GuardarTrabajador(EntTrabajador trabajador, string folio) 
        {
            var existe = context.Formulario
                .Where(t => t.folio == folio).FirstOrDefault();
            if (existe == null)
            {
                // Convierte tu objeto EntTrabajador a la entidad real de la base de datos si es necesario
                var entity = mapperEntity.ToEntity<Trabajador>(trabajador);

                context.Trabajador.Add(entity);
                context.SaveChanges();

                //Regresa el id del trabajador recien insertado
                return entity.id_trabajador;
            }
            else 
            {
                return existe.id_trabajador.Value;
            }

            
        }

        public List<EntTrabajador> ConsultarTrabajador(EntTrabajador Trabajador)
        
        {
            var data = context.Trabajador
                .AsNoTracking()
                .ToList();



            List<EntTrabajador> datosTrabajador = mapperEntity.ToEntity<List<EntTrabajador>>(data);

            foreach (var item in datosTrabajador) {
                var formulario = context.Formulario.Where(f => f.id_trabajador == item.Id_trabajador).ToList();

                int ResultadosPositivos = formulario.Where(r=>r.Respuesta == "Si").Count();
                int totalPreguntasSiyNo = formulario.Where(p => p.Respuesta == "Si" || p.Respuesta == "No").Count();
                decimal valoracion = ResultadosPositivos / Convert.ToDecimal(totalPreguntasSiyNo);

                item.PorcentajeValoracion = valoracion * 100;

                if ((double)valoracion < 0.66)
                    item.ResultadoValoracion = "Negativa";
                else
                    item.ResultadoValoracion = "Positiva";

            }

            return datosTrabajador;
        }
    }
}
