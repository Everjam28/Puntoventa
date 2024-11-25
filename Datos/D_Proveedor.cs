using Entidad;
using System;
using System.Collections.Generic;
//using System.Data.OracleClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Datos
{
    public class D_Proveedor
    {


        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();  // Obtener la conexión
                oconexion.Open();  // Abrir la conexión al inicio del bloque try

                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT DocumentoP, RazonSocial, Correo, Telefono, Estado FROM PROVEEDOR");

                using (OracleCommand cmd = new OracleCommand(query.ToString(), oconexion))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Proveedor proveedor = new Proveedor
                            {
                                Documento = dr["DocumentoP"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            };

                            lista.Add(proveedor);  // Agregar a la lista
                        }
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
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
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Cerrar la conexión para evitar fugas
                }
            }

            return lista;  // Devolver la lista de proveedores
        }



        public int Registrar(Proveedor obj, out string mensaje)
        {
            int usuariogenerado = 0;
            mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();  // Obtener la conexión
                oconexion.Open();  // Abrir la conexión

                OracleCommand cmd = new OracleCommand("SP_RegistrarProveedor", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Configuración de parámetros de entrada
                cmd.Parameters.Add(new OracleParameter("pDocumentoP", OracleDbType.Varchar2)).Value = obj.Documento;
                cmd.Parameters.Add(new OracleParameter("pRazonSocial", OracleDbType.Varchar2)).Value = obj.RazonSocial;
                cmd.Parameters.Add(new OracleParameter("pCorreo", OracleDbType.Varchar2)).Value = obj.Correo;
                cmd.Parameters.Add(new OracleParameter("pTelefono", OracleDbType.Varchar2)).Value = obj.Telefono;
                cmd.Parameters.Add(new OracleParameter("pEstado", OracleDbType.Int32)).Value = obj.Estado;

                // Configuración de parámetros de salida
                OracleParameter paramResultado = new OracleParameter("pResultado", OracleDbType.Int32);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                OracleParameter paramMensaje = new OracleParameter("pMensaje", OracleDbType.Varchar2, 500);
                paramMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramMensaje);

                // Ejecutar el procedimiento almacenado
                cmd.ExecuteNonQuery();

                usuariogenerado = Convert.ToInt32(paramResultado.Value);  // Obtener el resultado del parámetro de salida
                mensaje = paramMensaje.Value.ToString();  // Obtener el mensaje del parámetro de salida
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                usuariogenerado = 0;
                mensaje = "Error de base de datos: " + ex.Message;  // Manejo de errores específicos de Oracle
            }
            catch (Exception ex)
            {
                usuariogenerado = 0;
                mensaje = "Error general: " + ex.Message;  // Manejo de errores generales
            }
            finally
            {
                if (oconexion != null && oconexion.State == ConnectionState.Open)
                {
                    oconexion.Close();  // Cerrar la conexión para evitar fugas de recursos
                }
            }

            return usuariogenerado;  // Devolver el resultado
        }





        public bool Editar(Proveedor obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();  // Obtener la conexión
                oconexion.Open();  // Abrir la conexión

                OracleCommand cmd = new OracleCommand("SP_ModificarProveedor", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Configuración de parámetros de entrada
                cmd.Parameters.Add(new OracleParameter("pDocumentoP", OracleDbType.Varchar2)).Value = obj.Documento;
                cmd.Parameters.Add(new OracleParameter("pRazonSocial", OracleDbType.Varchar2)).Value = obj.RazonSocial;
                cmd.Parameters.Add(new OracleParameter("pCorreo", OracleDbType.Varchar2)).Value = obj.Correo;
                cmd.Parameters.Add(new OracleParameter("pTelefono", OracleDbType.Varchar2)).Value = obj.Telefono;
                cmd.Parameters.Add(new OracleParameter("pEstado", OracleDbType.Int32)).Value = obj.Estado;

                // Configuración de parámetros de salida
                OracleParameter paramResultado = new OracleParameter("pResultado", OracleDbType.Int32);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                OracleParameter paramMensaje = new OracleParameter("pMensaje", OracleDbType.Varchar2, 500);
                paramMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramMensaje);

                // Ejecutar el procedimiento almacenado
                cmd.ExecuteNonQuery();

                // Obtener los valores de salida
                respuesta = Convert.ToBoolean(Convert.ToInt32(paramResultado.Value));
                mensaje = paramMensaje.Value.ToString();
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
                    oconexion.Close();  // Asegúrate de cerrar la conexión para evitar fugas
                }
            }

            return respuesta;  // Devolver el resultado
        }



        public bool Eliminar(Proveedor obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();  // Obtener la conexión
                oconexion.Open();  // Abrir la conexión

                OracleCommand cmd = new OracleCommand("SP_EliminarProveedor", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Configurar los parámetros
                cmd.Parameters.Add(new OracleParameter("pDocumentoP", OracleDbType.Varchar2)).Value = obj.Documento;

                // Parámetros de salida
                OracleParameter paramResultado = new OracleParameter("pResultado", OracleDbType.Int32);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                OracleParameter paramMensaje = new OracleParameter("pMensaje", OracleDbType.Varchar2, 200);
                paramMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramMensaje);

                cmd.ExecuteNonQuery();  // Ejecutar el procedimiento almacenado

                // Obtener el resultado de salida
                respuesta = Convert.ToBoolean(Convert.ToInt32(paramResultado.Value));
                mensaje = paramMensaje.Value.ToString();  // Obtener el mensaje del parámetro de salida
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
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Asegúrate de cerrar la conexión para evitar fugas
                }
            }

            return respuesta;  // Devolver el resultado
        }







        /*public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT DocumentoP,RazonSocial,Correo,Telefono,Estado FROM PROVEEDOR");
                    
                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor()
                            {

                                Documento = dr["DocumentoP"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
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
                    lista = new List<Proveedor>();
                }
                finally
                {
                    oconexion.Close();
                }

                return lista;
            }

        }




        public int Registrar(Proveedor obj, out string Mensaje)
        {
            int usuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    OracleCommand cmd = new OracleCommand("SP_RegistrarProveedor", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("pDocumentoP", OracleType.VarChar).Value = obj.Documento;
                    cmd.Parameters.Add("pRazonSocial", OracleType.VarChar).Value = obj.RazonSocial;
                    cmd.Parameters.Add("pCorreo", OracleType.VarChar).Value = obj.Correo;
                    cmd.Parameters.Add("pTelefono", OracleType.VarChar).Value = obj.Telefono;
                    cmd.Parameters.Add("pEstado", OracleType.Int32).Value = obj.Estado;
                    cmd.Parameters.Add("pResultado", OracleType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("pMensaje", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    usuariogenerado = Convert.ToInt32(cmd.Parameters["pResultado"].Value);
                    Mensaje = cmd.Parameters["pMensaje"].Value.ToString();





                }
            }
            catch (Exception ex)
            {
                usuariogenerado = 0;
                Mensaje = ex.Message;

            }

            return usuariogenerado;
        }







        public bool Editar(Proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    OracleCommand cmd = new OracleCommand("SP_ModificarProveedor", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("pDocumentoP", OracleType.VarChar).Value = obj.Documento;
                    cmd.Parameters.Add("pRazonSocial", OracleType.VarChar).Value = obj.RazonSocial;
                    cmd.Parameters.Add("pCorreo", OracleType.VarChar).Value = obj.Correo;
                    cmd.Parameters.Add("pTelefono", OracleType.VarChar).Value = obj.Telefono;
                    cmd.Parameters.Add("pEstado", OracleType.Int32).Value = obj.Estado;
                    cmd.Parameters.Add("pResultado", OracleType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("pMensaje", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["pResultado"].Value);
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









        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    OracleCommand cmd = new OracleCommand("SP_EliminarProveedor", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Añadir parámetros
                    cmd.Parameters.Add("pDocumentoP", OracleType.VarChar).Value = obj.Documento;
                    cmd.Parameters.Add("pResultado", OracleType.Number).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("pMensaje", OracleType.VarChar, 200).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener valores de los parámetros de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["pResultado"].Value);
                    Mensaje = cmd.Parameters["pMensaje"].Value.ToString();
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
