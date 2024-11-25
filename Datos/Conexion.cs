
using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace Datos
{
    public static class Conexion
    {
        public static string ObtenerCadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["cadenaBD"].ConnectionString; 
        }

        public static OracleConnection ObtenerConexion()
        {
            return new OracleConnection(ObtenerCadenaConexion());
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OracleClient;

namespace Datos
{
    public static class Conexion
    {

       // public static string cadena = ConfigurationManager.ConnectionStrings["cadenaBD"].ToString();
       // /*
        public static string ObtenerCadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["cadenaBD"].ToString();
        }

        public static OracleConnection ObtenerConexion()
        {
            return new OracleConnection(ObtenerCadenaConexion());
        }
       // */

        //public static readonly OracleConnection cadena = new OracleConnection("DATA SOURCE =xe ; PASSWORD=123456;USER ID = USER_VENTA;");

    //};
    




//};*/

    



