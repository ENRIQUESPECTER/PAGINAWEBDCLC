using System.Data.SqlClient;

namespace CRUDCORE.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
#pragma warning disable CS8601 // Posible asignación de referencia nula
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
#pragma warning restore CS8601 // Posible asignación de referencia nula

        }
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }


    }
}
