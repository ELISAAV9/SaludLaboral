using Final.Context;
using Microsoft.EntityFrameworkCore;

namespace Final.Datos
{
    public class DatosBase
    {
        public SaludLaboralContext context;
        public MapperEntity mapperEntity;

        public DatosBase() 
        {
           //Mappea la cadena de conexion
            string connection = SQLConnection.DB_ObtenCadenaConexion("SaludLaboralConnection");

            var options = new DbContextOptionsBuilder<SaludLaboralContext>().UseSqlServer(connection).Options;
            context = new SaludLaboralContext(options);

            mapperEntity = new MapperEntity();
        }
    }
}
