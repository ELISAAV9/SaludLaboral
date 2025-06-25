namespace Final.Datos
{
        public static class SQLConnection
        {
            private static IConfigurationRoot _configuration;
            static SQLConnection()
            {
            // Cargar la configuración desde el archivo appsettings.json
#if DEBUG
            string basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                var builder = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                _configuration = builder.Build();
#else
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
#endif
            }

            /// <summary>
            /// Obtiene La cadena de conexion que se Especifique
            /// </summary>
            /// <param name="LlaveCadena">Nombre de la cadena de conexion</param>
            /// <returns>Regresa la cadena de conexion</returns>
            public static string DB_ObtenCadenaConexion(string LlaveCadena)
            {
            //Se toma la conexion de App Settings de Azure o de las variables de entorno 
            //return Environment.GetEnvironmentVariable(LlaveCadena);

            //Forma Tradicional
            //return ConfigurationManager.ConnectionStrings[LlaveCadena].ConnectionString;

            //Forma mas moderna con IConfiguration
            //return _configuration.GetConnectionString(LlaveCadena);
            return "Server=DESKTOP-FSGELDJ\\SQLEXPRESS;Database=SaludLaboral;User Id=sa;Password=admin;TrustServerCertificate=True;";
            }


        }
    }
