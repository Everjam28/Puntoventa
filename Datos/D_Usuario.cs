using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using Entidad;
using System.Data;
using System.Collections;
using System.Security.Cryptography;
using Oracle.ManagedDataAccess.Types;

namespace Datos
{
    public class D_Usuario
    {

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT u.Documento, u.Primer_Nombre, u.Primer_Apellido, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion FROM Usuarios u");
                    query.AppendLine("INNER JOIN Rol r ON r.IdRol = u.IdRol");

                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                Documento = dr["Documento"].ToString(),
                                PrimerNombre = dr["Primer_Nombre"].ToString(),
                                PrimerApellido = dr["Primer_Apellido"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol
                                {
                                    IdRol = Convert.ToInt32(dr["IdRol"]),
                                    Descripcion = dr["Descripcion"].ToString()
                                }
                            };

                            lista.Add(usuario);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    lista.Clear();  // Reiniciar la lista en caso de error
                }
                finally
                {
                    if (oconexion.State == ConnectionState.Open)
                    {
                        oconexion.Close();  // Asegurarse de cerrar la conexión
                    }
                }

                return lista;
            }
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int usuariogenerado = 0;
            Mensaje = string.Empty;

            using (var oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("SP_REGISTRARUSUARIO", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.Add(new OracleParameter("p_Documento", OracleDbType.Varchar2)).Value = obj.Documento;
                    cmd.Parameters.Add(new OracleParameter("p_Primer_Nombre", OracleDbType.Varchar2)).Value = obj.PrimerNombre;
                    cmd.Parameters.Add(new OracleParameter("p_Primer_Apellido", OracleDbType.Varchar2)).Value = obj.PrimerApellido;
                    cmd.Parameters.Add(new OracleParameter("p_Correo", OracleDbType.Varchar2)).Value = obj.Correo;
                    cmd.Parameters.Add(new OracleParameter("p_Clave", OracleDbType.Varchar2)).Value = obj.Clave;
                    cmd.Parameters.Add(new OracleParameter("p_IdRol", OracleDbType.Int32)).Value = obj.oRol.IdRol;
                    cmd.Parameters.Add(new OracleParameter("p_Estado", OracleDbType.Int32)).Value = obj.Estado;

                    // Parámetros de salida
                    OracleParameter paramResultado = new OracleParameter("p_UsuarioResultado", OracleDbType.Varchar2);
                    paramResultado.Direction = ParameterDirection.Output;
                    paramResultado.Size = 4000;  // Establece un tamaño adecuado para el VARCHAR2
                    cmd.Parameters.Add(paramResultado);

                    OracleParameter paramMensaje = new OracleParameter("p_Mensaje", OracleDbType.Varchar2, 1000);
                    paramMensaje.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramMensaje);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    string resultadoStr = paramResultado.Value.ToString();
                    Mensaje = paramMensaje.Value.ToString();  // Obtener el mensaje de salida

                    // Convertir el resultado a int
                    if (int.TryParse(resultadoStr, out usuariogenerado))
                    {
                        return usuariogenerado;
                    }
                    else
                    {
                        // Manejo de caso cuando el resultado no es un número válido
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    usuariogenerado = 0;
                    Mensaje = "Error: " + ex.Message;
                }
                finally
                {
                    if (oconexion.State == ConnectionState.Open)
                    {
                        oconexion.Close();  // Asegúrate de cerrar la conexión
                    }
                }

                return usuariogenerado;  // Retornar el ID del usuario generado
            }
        }




        public bool Editar(Usuario obj, out string Mensaje)
         {
             bool respuesta = false;
             Mensaje = string.Empty;

             using (OracleConnection oconexion = Conexion.ObtenerConexion())
             {
                 try
                 {
                     OracleCommand cmd = new OracleCommand("UsuarioPkg.SP_EDITARUSUARIOS", oconexion);
                     cmd.CommandType = CommandType.StoredProcedure;

                     // Parámetros de entrada
                     cmd.Parameters.Add(new OracleParameter("p_Documento", OracleDbType.Varchar2)).Value = obj.Documento;
                     cmd.Parameters.Add(new OracleParameter("p_Primer_Nombre", OracleDbType.Varchar2)).Value = obj.PrimerNombre;
                     cmd.Parameters.Add(new OracleParameter("p_Primer_Apellido", OracleDbType.Varchar2)).Value = obj.PrimerApellido;
                     cmd.Parameters.Add(new OracleParameter("p_Correo", OracleDbType.Varchar2)).Value = obj.Correo;
                     cmd.Parameters.Add(new OracleParameter("p_Clave", OracleDbType.Varchar2)).Value = obj.Clave;
                     cmd.Parameters.Add(new OracleParameter("p_IdRol", OracleDbType.Int32)).Value = obj.oRol.IdRol;
                     cmd.Parameters.Add(new OracleParameter("p_Estado", OracleDbType.Int32)).Value = obj.Estado;

                     // Parámetros de salida
                     OracleParameter paramRespuesta = new OracleParameter("p_Respuesta", OracleDbType.Int32);
                     paramRespuesta.Direction = ParameterDirection.Output;
                     cmd.Parameters.Add(paramRespuesta);

                     OracleParameter paramMensaje = new OracleParameter("p_Mensaje", OracleDbType.Varchar2, 200);
                     paramMensaje.Direction = ParameterDirection.Output;
                     cmd.Parameters.Add(paramMensaje);

                     // Ejecutar el procedimiento almacenado
                     oconexion.Open();
                     cmd.ExecuteNonQuery();

                    // Obtener el resultado de salida
                    respuesta = Convert.ToInt32(paramRespuesta.Value) == 0;

                    //respuesta = Convert.ToBoolean(paramRespuesta.Value);
                    // Mensaje = paramMensaje.Value.ToString();
                 }
                 catch (Exception ex)
                 {
                    respuesta = false;
                    Mensaje = "Error al editar el usuario: " + ex.Message;
                 }
                 finally
                 {
                     if (oconexion.State == ConnectionState.Open)
                     {
                         oconexion.Close();  // Asegúrate de cerrar la conexión
                     }
                 }
             }

             return respuesta;



         }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (var oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("UsuarioPkg.SP_ELIMINARUSUARIOS", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.Add(new OracleParameter("p_Documento", OracleDbType.Varchar2) { Value = obj.Documento });

                    // Parámetros de salida
                    OracleParameter paramRespuesta = new OracleParameter("p_Respuesta", OracleDbType.Int32);
                    paramRespuesta.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramRespuesta);

                    OracleParameter paramMensaje = new OracleParameter("p_Mensaje", OracleDbType.Varchar2, 200);
                    paramMensaje.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramMensaje);

                    // Ejecutar el procedimiento almacenado
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener el valor del parámetro de salida
                    int respuestaValor = Convert.ToInt32(paramRespuesta.Value);  // Convierte a entero
                    respuesta = (respuestaValor == 1);  // Considera que 1 es éxito, 0 es fallo

                    // Convertir el valor del mensaje correctamente
                    OracleString oracleMensaje = (OracleString)paramMensaje.Value;
                    Mensaje = oracleMensaje.IsNull ? string.Empty : oracleMensaje.Value;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = "Error al eliminar el usuario: " + ex.Message;  // Agregar contexto al mensaje de error
                }
                finally
                {
                    if (oconexion.State == System.Data.ConnectionState.Open)
                    {
                        oconexion.Close();  // Asegurarse de cerrar la conexión
                    }
                }
            }

            return respuesta;
        }






    }
}