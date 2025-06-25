using Final.Entidades;
using Final.Models;

namespace Final.Datos
{
    public class DatosEmpresa : DatosBase
    {
        public int GuardarEmpresa(EntEmpresa empresa)
        {
            // Buscar si existe empresa
           var existe = context.Empresa
                .Where(e => e.Nombre.Trim() == empresa.Nombre.Trim()).FirstOrDefault();
            //Si no existe inserta empresa
            if (existe == null)
            {
                // INSERTA EMPRESA 
                Empresa item = new Empresa();
                item.Nombre = empresa.Nombre;



                context.Empresa.Add(item);
                context.SaveChanges();

                return item.id_empresa;
            }
            // Si existe actualiza el actual y manda id empresa
            else
            {
                existe.Nombre = empresa.Nombre.Trim();
                context.SaveChanges();
                return existe.id_empresa;
            }

           



        }
    }
}
