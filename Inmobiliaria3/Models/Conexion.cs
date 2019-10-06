using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria3.Models
{
    public class Conexion
    {
        public Conexion()
        {
        }

        public static SqlConnection getConnection() {
            String cadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\BRAYAN\\SOURCE\\REPOS\\INMOBILIARIA3\\INMOBILIARIA3\\DATA\\INMOBILIARIA.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(cadenaConexion);
            return connection;
        }
    }
}
