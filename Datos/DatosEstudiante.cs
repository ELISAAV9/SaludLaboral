using Final.Entidades;
using Final.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Final.Datos
{
    public class DatosEstudiante : DatosBase
    {
        public EntEstudiante ValidaUsuario(EntEstudiante Estudiante)
        {
            var data = context.Estudiante
                .AsNoTracking()
                .Where(w => w.id_estudiante == Estudiante.Id_estudiante && w.Contrasena == Estudiante.Contrasena)
                .FirstOrDefault();
            
            //Convierte los resultados de base de datos a un objeto igual a la tabla
            EntEstudiante datosEstudiantes = mapperEntity.ToEntity<EntEstudiante>(data);

            return datosEstudiantes;
        }

        public void GuardarUsuario(EntEstudiante Usuario) 
        {
            //Convierte EntEstudiante(Programa) a estudiante (de la base de datos)
            Estudiante entity = mapperEntity.ToEntity<Estudiante>(Usuario);

            //Agrega el nuevo estudiante y lo salva
            context.Estudiante.Add(entity);
            context.SaveChanges();

            return;
            
        }

        public void EliminarUsuario(EntEstudiante Usuario)
        {
            var data = context.Estudiante
                .Where(e => e.id_estudiante == Usuario.Id_estudiante)
                .FirstOrDefault();
            
            context.Estudiante.Remove(data);
            context.SaveChanges();

            return;
        }

        public void ModificarUsuario(EntEstudiante Usuario)
        {
            var data = context.Estudiante
                .Where(e => e.id_estudiante == Usuario.Id_estudiante)
                .FirstOrDefault();

            if (data != null) 
            {
                data.Nombre = Usuario.Nombre;
                data.Apellidos = Usuario.Apellidos;
                data.Contrasena = Usuario.Contrasena;
                data.Grupo = Usuario.Grupo;
                data.Rol = Usuario.Rol;

                context.SaveChanges();
            }
      

            return;
        }

        public EntEstudiante ConsultarUsuario(EntEstudiante Estudiante)
        {
            var data = context.Estudiante
                .AsNoTracking()
                .Where(w => w.id_estudiante == Estudiante.Id_estudiante)
                .FirstOrDefault();

            //Convierte los resultados de base de datos a un objeto igual a la tabla
            EntEstudiante datosEstudiantes = mapperEntity.ToEntity<EntEstudiante>(data);

            return datosEstudiantes;
        }

    }
}
