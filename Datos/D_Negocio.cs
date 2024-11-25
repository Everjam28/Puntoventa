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
using System.Collections;
using Oracle.ManagedDataAccess.Client;



namespace Datos
{
    public class D_Negocio
    {



        public Negocios ObtenerDatos()
        {
            Negocios obj = null;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();  // Obtiene la conexión
                oconexion.Open();  // Abrir la conexión al inicio del bloque try

                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT IdNegocio, Nombre, Ruc, Direccion FROM Negocio WHERE IdNegocio = 1");

                using (OracleCommand cmd = new OracleCommand(query.ToString(), oconexion))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new Negocios
                            {
                                IdNegocio = Convert.ToInt32(dr["IdNegocio"]),
                                Nombre = dr["Nombre"].ToString(),
                                Ruc = dr["Ruc"].ToString(),
                                Direccion = dr["Direccion"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");  // Manejo de errores específicos de Oracle
                obj = new Negocios();  // Inicializar un objeto vacío para evitar referencias nulas
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");  // Manejo de errores generales
                obj = new Negocios();  // Inicializar un objeto vacío para evitar referencias nulas
            }
            finally
            {
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Cerrar la conexión para evitar fugas de recursos
                }
            }

            return obj;  // Devolver el objeto Negocios
        }




        public bool ActualizarDatos(Negocios obj, out string mensaje)
        {
            bool respuesta = true;
            mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();
                oconexion.Open();  // Abrir la conexión al inicio del bloque try

                StringBuilder query = new StringBuilder();
                query.AppendLine("UPDATE Negocio SET Nombre = :nombre,");
                query.AppendLine("Ruc = :ruc,");
                query.AppendLine("Direccion = :direccion");

                using (OracleCommand cmd = new OracleCommand(query.ToString(), oconexion))
                {
                    cmd.CommandType = CommandType.Text;

                    // Definir parámetros con el tipo correcto
                    cmd.Parameters.Add(new OracleParameter(":nombre", OracleDbType.Varchar2)).Value = obj.Nombre;
                    cmd.Parameters.Add(new OracleParameter(":ruc", OracleDbType.Varchar2)).Value = obj.Ruc;
                    cmd.Parameters.Add(new OracleParameter(":direccion", OracleDbType.Varchar2)).Value = obj.Direccion;

                    if (cmd.ExecuteNonQuery() < 1)  // Ejecutar el comando y verificar el resultado
                    {
                        respuesta = false;
                        mensaje = "No se pudo actualizar los datos";  // Mensaje de error si no se actualizó
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                respuesta = false;
                mensaje = "Error de base de datos: " + ex.Message;  // Manejo de errores específicos de Oracle
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error: " + ex.Message;  // Manejo de errores generales
            }
            finally
            {
                if (oconexion != null && oconexion.State == ConnectionState.Open)
                {
                    oconexion.Close();  // Cerrar la conexión para evitar fugas de recursos
                }
            }

            return respuesta;
        }







        public byte[] obtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] logoBytes = Array.Empty<byte>();  // Mejor uso de Array.Empty<byte>() para arrays vacíos

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();
                oconexion.Open();  // Abrir la conexión al inicio del bloque try

                string query = "SELECT Logo FROM Negocio WHERE IdNegocio = 1";

                using (OracleCommand cmd = new OracleCommand(query, oconexion))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(dr.GetOrdinal("Logo")))
                            {
                                logoBytes = (byte[])dr["Logo"];  // Convertir a byte[]
                            }
                        }
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                Console.WriteLine("Error de base de datos: " + ex.Message);  // Manejo de errores específicos de Oracle
                obtenido = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);  // Manejo de errores generales
                obtenido = false;
            }
            finally
            {
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Asegurarse de cerrar la conexión para evitar fugas
                }
            }

            return logoBytes;  // Devolver el array de bytes
        }




        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();
                oconexion.Open();  // Abrir la conexión al inicio del bloque try

                StringBuilder query = new StringBuilder();
                query.AppendLine("UPDATE Negocio SET Logo = :imagen WHERE IdNegocio = 1");

                using (OracleCommand cmd = new OracleCommand(query.ToString(), oconexion))
                {
                    cmd.CommandType = CommandType.Text;

                    // Configurar el parámetro BLOB para la imagen
                    OracleParameter paramImagen = new OracleParameter(":imagen", OracleDbType.Blob);
                    paramImagen.Value = image;

                    cmd.Parameters.Add(paramImagen);  // Añadir el parámetro al comando

                    if (cmd.ExecuteNonQuery() < 1)  // Comprobar el resultado de la ejecución
                    {
                        respuesta = false;
                        mensaje = "No se pudo actualizar el logo";
                    }
                    else
                    {
                        respuesta = true;  // Indicar que la operación fue exitosa
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                respuesta = false;
                mensaje = "Error de base de datos: " + ex.Message;  // Manejo de errores específicos de Oracle
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error general: " + ex.Message;  // Manejo de errores generales
            }
            finally
            {
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Asegúrate de cerrar la conexión para evitar fugas de recursos
                }
            }

            return respuesta;
        }






        /* public Negocios ObtenerDatos()
         {
             Negocios obj = null;

             using (OracleConnection oconexion = Conexion.ObtenerConexion())
             {
                 try
                 {
                     StringBuilder query = new StringBuilder();
                     query.AppendLine("SELECT IdNegocio, Nombre, Ruc, Direccion FROM Negocio WHERE IdNegocio = 1");

                     OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                     cmd.CommandType = CommandType.Text;
                     oconexion.Open();

                     using (OracleDataReader dr = cmd.ExecuteReader())
                     {
                         if (dr.Read())
                         {
                             obj = new Negocios()
                             {
                                 IdNegocio = Convert.ToInt32(dr["IdNegocio"]),
                                 Nombre = dr["Nombre"].ToString(),
                                 Ruc = dr["Ruc"].ToString(),
                                 Direccion = dr["Direccion"].ToString()
                             };
                         }
                     }
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine($"Error: {ex.Message}");
                     obj = new Negocios(); // inicializar un nuevo objeto en caso de error
                 }
                 finally
                 {
                     oconexion.Close();
                 }

                 return obj;
             }
         }


         public bool ActualizarDatos(Negocios obj, out string Mensaje)
         {
             bool respuesta = true;
             Mensaje = string.Empty;

             try
             {
                 using (OracleConnection oconexion = Conexion.ObtenerConexion())
                 {
                     StringBuilder query = new StringBuilder();
                     query.AppendLine("UPDATE Negocio set Nombre = :nombre,");
                     query.AppendLine("Ruc = :ruc,");
                     query.AppendLine("Direccion = :direccion");

                     OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                     cmd.CommandType = CommandType.Text;

                     cmd.Parameters.AddWithValue(":nombre", obj.Nombre);
                     cmd.Parameters.AddWithValue(":ruc", obj.Ruc);
                     cmd.Parameters.AddWithValue(":direccion", obj.Direccion);

                     oconexion.Open();
                     if (cmd.ExecuteNonQuery() < 1)
                     {
                         respuesta = false;
                         Mensaje = "No se pudo actualizar los datos";
                     }
                 }
             }
             catch (Exception ex)
             {
                 respuesta = false;
                 Mensaje = ex.Message;
             }

             return respuesta;
         }


         public byte[] obtenerLogo(out bool obtenido) {

             obtenido = true;
             byte[] LogoBytes = new byte[0];

             try
             {
                 using (OracleConnection oconexion = Conexion.ObtenerConexion())
                 {
                     string query = "SELECT Logo FROM Negocio where IdNegocio = 1";

                     OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                     cmd.CommandType = CommandType.Text;

                     oconexion.Open();

                     using (OracleDataReader dr = cmd.ExecuteReader())
                     {
                         if (dr.Read())
                         {
                             LogoBytes = (byte[])dr["Logo"];

                         }
                     }



                 }
             }
             catch (Exception ex)
             {
                 LogoBytes = new byte[0];
                 obtenido = false;

             }
             return LogoBytes;
         }


        public bool ActualizarLogo(byte[] image, out string Mensaje)
 {
             bool respuesta = false;
             Mensaje = string.Empty;

             try
             {
                 using (OracleConnection oconexion = Conexion.ObtenerConexion())
                 {
                     StringBuilder query = new StringBuilder();
                     query.AppendLine("UPDATE Negocio SET Logo = :imagen WHERE IdNegocio = 1");

                     OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                     cmd.CommandType = CommandType.Text;

                     OracleParameter paramImagen = new OracleParameter();
                     paramImagen.ParameterName = ":imagen";
                     paramImagen.OracleType = OracleType.Blob;
                     paramImagen.Value = image;

                     cmd.Parameters.Add(paramImagen);

                     oconexion.Open();
                     if (cmd.ExecuteNonQuery() < 1)
                     {
                         respuesta = false;
                         Mensaje = "No se pudo actualizar el logo";
                     }
                     else
                     {
                         respuesta = true;
                     }
                 }
             }
             catch (Exception ex)
             {
                 respuesta = false;
                 Mensaje = ex.Message;
             }

             return respuesta;
        }*/






    }
}
