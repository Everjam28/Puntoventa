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
    public class D_Cliente
    {


        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();
                oconexion.Open();  // Abrir la conexión al inicio del bloque try

                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT Documento, Primer_Nombre, Primer_Apellido, Correo, Telefono, Estado FROM Clientes");

                using (OracleCommand cmd = new OracleCommand(query.ToString(), oconexion))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                Documento = dr["Documento"].ToString(),
                                Primer_Nombre = dr["Primer_Nombre"].ToString(),
                                Primer_Apellido = dr["Primer_Apellido"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            };

                            lista.Add(cliente);  // Añadir a la lista
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");  // Manejo de errores específicos de Oracle
                lista.Clear();  // Limpiar la lista en caso de error
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");  // Manejo de errores generales
                lista.Clear();  // Limpiar la lista en caso de error
            }
            finally
            {
                if (oconexion != null && oconexion.State == ConnectionState.Open)
                {
                    oconexion.Close();  // Cerrar la conexión de forma segura
                }
            }

            return lista;  // Retornar la lista de clientes
        }



        public int Registrar(Cliente obj, out string mensaje)
        {
            int clientegenerado = 0;
            mensaje = string.Empty;

            using (var oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("SP_RegistrarCliente", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Configurar parámetros de entrada
                    cmd.Parameters.Add(new OracleParameter("p_Documento", OracleDbType.Varchar2)).Value = obj.Documento;
                    cmd.Parameters.Add(new OracleParameter("p_Primer_Nombre", OracleDbType.Varchar2)).Value = obj.Primer_Nombre;
                    cmd.Parameters.Add(new OracleParameter("p_Primer_Apellido", OracleDbType.Varchar2)).Value = obj.Primer_Apellido;
                    cmd.Parameters.Add(new OracleParameter("p_Correo", OracleDbType.Varchar2)).Value = obj.Correo;
                    cmd.Parameters.Add(new OracleParameter("p_Telefono", OracleDbType.Varchar2)).Value = obj.Telefono;
                    cmd.Parameters.Add(new OracleParameter("p_Estado", OracleDbType.Int32)).Value = obj.Estado;

                    // Parámetros de salida
                    OracleParameter paramResultado = new OracleParameter("p_ClienteResultado", OracleDbType.Varchar2);
                    paramResultado.Direction = ParameterDirection.Output;
                    paramResultado.Size = 4000;  // Establece un tamaño adecuado para el VARCHAR2
                    cmd.Parameters.Add(paramResultado);

                    OracleParameter paramMensaje = new OracleParameter("p_Mensaje", OracleDbType.Varchar2, 1000);
                    paramMensaje.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramMensaje);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    string resultadoStr = paramResultado.Value.ToString();
                    mensaje = paramMensaje.Value.ToString();  // Obtener el mensaje de salida

                    // Convertir el resultado a int
                    if (int.TryParse(resultadoStr, out clientegenerado))
                    {
                        return clientegenerado;
                    }
                    else
                    {
                        // Manejo de caso cuando el resultado no es un número válido
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    clientegenerado = 0;
                    mensaje = "Error: " + ex.Message;
                }
                finally
                {
                    if (oconexion.State == ConnectionState.Open)
                    {
                        oconexion.Close();  // Asegúrate de cerrar la conexión
                    }
                }

                return clientegenerado;  // Retornar el ID del cliente generado
            }
        }





        public bool Editar(Cliente obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();
                OracleCommand cmd = new OracleCommand("ClientePkg.SP_ModificarCliente", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Configuración de parámetros de entrada
                cmd.Parameters.Add(new OracleParameter("pDocumento", OracleDbType.Varchar2)).Value = obj.Documento;
                cmd.Parameters.Add(new OracleParameter("pPrimer_Nombre", OracleDbType.Varchar2)).Value = obj.Primer_Nombre;
                cmd.Parameters.Add(new OracleParameter("pPrimer_Apellido", OracleDbType.Varchar2)).Value = obj.Primer_Apellido;
                cmd.Parameters.Add(new OracleParameter("pCorreo", OracleDbType.Varchar2)).Value = obj.Correo;
                cmd.Parameters.Add(new OracleParameter("pTelefono", OracleDbType.Varchar2)).Value = obj.Telefono;

                cmd.Parameters.Add(new OracleParameter("pEstado", OracleDbType.Int32)).Value = obj.Estado;

                // Parámetro de salida para el mensaje
                OracleParameter paramMensaje = new OracleParameter("pMensaje", OracleDbType.Varchar2, 200);
                paramMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramMensaje);

                oconexion.Open();  // Abrir la conexión
                cmd.ExecuteNonQuery();  // Ejecutar el procedimiento almacenado

                mensaje = paramMensaje.Value.ToString();  // Obtener el mensaje del parámetro de salida

                respuesta = true;  // Indicar que la operación fue exitosa
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                respuesta = false;
                mensaje = "Error de base de datos: " + ex.Message;  // Error específico de Oracle
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error: " + ex.Message;  // Error general
            }
            finally
            {
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Asegúrate de cerrar la conexión para evitar fugas
                }
            }

            return respuesta;
        }



        public bool Eliminar(Cliente obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();

                string query = "DELETE FROM clientes WHERE Documento = :Documento";
                using (OracleCommand cmd = new OracleCommand(query, oconexion))
                {
                    // Configurar el parámetro con el tipo correcto
                    cmd.Parameters.Add(new OracleParameter("Documento", OracleDbType.Varchar2)).Value = obj.Documento;

                    oconexion.Open();  // Abrir la conexión
                    respuesta = cmd.ExecuteNonQuery() > 0;  // Comprobar si se eliminó algún registro
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                respuesta = false;
                mensaje = "Error de base de datos: " + ex.Message;  // Error específico de Oracle
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error: " + ex.Message;  // Error general
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







        /*public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select Documento, Primer_Nombre, Primer_Apellido,Correo,Telefono,Estado From Clientes");


                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {

                                Documento = dr["Documento"].ToString(),
                                Primer_Nombre = dr["Primer_Nombre"].ToString(),
                                Primer_Apellido = dr["Primer_Apellido"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])

                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    lista = new List<Cliente>();
                }
                finally
                {
                    oconexion.Close();
                }

                return lista;
            }
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            int clientegenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    OracleCommand cmd = new OracleCommand("SP_RegistrarCliente", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("pDocumento", OracleType.VarChar).Value = obj.Documento;
                    cmd.Parameters.Add("pPrimer_Nombre", OracleType.VarChar).Value = obj.Primer_Nombre;
                    cmd.Parameters.Add("pPrimer_Apellido", OracleType.VarChar).Value = obj.Primer_Apellido;
                    cmd.Parameters.Add("pCorreo", OracleType.VarChar).Value = obj.Correo;
                    cmd.Parameters.Add("pTelefono", OracleType.VarChar).Value = obj.Telefono;
                    cmd.Parameters.Add("pEstado", OracleType.Int32).Value = obj.Estado;
                    cmd.Parameters.Add("pResultado", OracleType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("pMensaje", OracleType.VarChar, 1000).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    clientegenerado = Convert.ToInt32(cmd.Parameters["pResultado"].Value);
                    Mensaje = cmd.Parameters["pMensaje"].Value.ToString();





                }
            }
            catch (Exception ex)
            {
                clientegenerado = 0;
                Mensaje = ex.Message;

            }

            return clientegenerado;
        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    OracleCommand cmd = new OracleCommand("SP_ModificarCliente", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("pDocumento", OracleType.VarChar).Value = obj.Documento;
                    cmd.Parameters.Add("pPrimer_Nombre", OracleType.VarChar).Value = obj.Primer_Nombre;
                    cmd.Parameters.Add("pPrimer_Apellido", OracleType.VarChar).Value = obj.Primer_Apellido;
                    cmd.Parameters.Add("pCorreo", OracleType.VarChar).Value = obj.Correo;
                    cmd.Parameters.Add("pTelefono", OracleType.VarChar).Value = obj.Telefono;
                    
                    cmd.Parameters.Add("pEstado", OracleType.Int32).Value = obj.Estado;
                    
                    cmd.Parameters.Add("pMensaje", OracleType.VarChar, 200).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Mensaje = cmd.Parameters["pMensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    string query = "DELETE FROM clientes WHERE Documento = :Documento";
                    using (OracleCommand cmd = new OracleCommand(query, oconexion))
                    {
                        cmd.Parameters.Add("Documento", OracleType.VarChar).Value = obj.Documento;
                        oconexion.Open();
                        respuesta = cmd.ExecuteNonQuery() > 0;
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
