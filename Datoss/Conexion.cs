using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

using System.IO;

namespace Adondevamos.Datoss
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion() {



            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL() {
            return cadenaSQL;
        }


    }
}
