using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
//using System.Data.OracleClient;
using Entidad;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Datos
{
    public class D_Permiso
    {



        public List<Permiso> Listar(int Idusuario)
        {
            List<Permiso> lista = new List<Permiso>();

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();  // Obtener la conexión
                oconexion.Open();  // Abrir la conexión al inicio del bloque try

                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT p.IdRol, NombreMenu FROM Permiso p");
                query.AppendLine("INNER JOIN Rol r ON r.IdRol = p.IdRol");
                query.AppendLine("INNER JOIN Usuario u ON u.IdRol = r.IdRol");
                query.AppendLine("WHERE u.IdUsuario = :Idusuario");

                using (OracleCommand cmd = new OracleCommand(query.ToString(), oconexion))
                {
                    cmd.CommandType = CommandType.Text;

                    // Configurar el parámetro de entrada
                    cmd.Parameters.Add(new OracleParameter(":Idusuario", OracleDbType.Int32)).Value = Idusuario;

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int idRol = dr["IdRol"] is DBNull ? 0 : Convert.ToInt32(dr["IdRol"]);  // Manejar posibles valores nulos

                            Permiso permiso = new Permiso
                            {
                                oRol = new Rol { IdRol = idRol },
                                Nombremenu = dr["NombreMenu"].ToString()
                            };

                            lista.Add(permiso);  // Añadir a la lista
                        }
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");  // Manejar errores específicos de Oracle
                lista.Clear();  // Limpiar la lista en caso de error
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");  // Manejar errores generales
                lista.Clear();  // Limpiar la lista en caso de error
            }
            finally
            {
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Asegúrate de cerrar la conexión para evitar fugas de recursos
                }
            }

            return lista;
        }






    }
}
