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
using System.Security.Cryptography;
using Oracle.ManagedDataAccess.Client;
using Zen.Barcode;
using System.Drawing;
using System.IO;


namespace Datos
{
    public class D_Producto
    {


        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();
                oconexion.Open();  // Abrir la conexión al inicio del bloque try

                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT IdProducto, Codigo, Nombre, p.Descripcion, c.IdCategoria, c.Descripcion as DescripcionCategoria, Stock, PrecioCompra, PrecioVenta, p.Estado FROM Producto p");
                query.AppendLine("INNER JOIN CATEGORIA c ON c.IdCategoria = p.IdCategoria");

                using (OracleCommand cmd = new OracleCommand(query.ToString(), oconexion))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Producto producto = new Producto
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oCategoria = new Categoria
                                {
                                    Idcategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    Descripcion = dr["DescripcionCategoria"].ToString()
                                },
                                Stock = Convert.ToInt32(dr["Stock"]),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            };

                            lista.Add(producto);  // Agregar a la lista
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
                lista.Clear();  // Limpiar la lista en caso de error
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
                lista.Clear();  // Limpiar la lista en caso de error
            }
            finally
            {
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Asegúrate de cerrar la conexión para evitar fugas
                }
            }

            return lista;
        }




        //Listar Alerta del Stock
        public List<Alerta> ObtenerAlertasDeStockBajo()
        {
            List<Alerta> listaAlertas = new List<Alerta>();
            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();
                oconexion.Open();

                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT  a.productoId, p.Nombre AS NombreProducto, a.Mensaje, p.Stock, a.FechaAlerta");
                query.AppendLine("FROM Alertas a");
                query.AppendLine("INNER JOIN Producto p ON a.ProductoId = p.IdProducto");
                query.AppendLine("WHERE a.FechaAlerta = ( SELECT MAX(FechaAlerta)");
                query.AppendLine("FROM Alertas");
                query.AppendLine("WHERE ProductoId = a.ProductoId AND FechaAlerta IS NOT NULL");
                query.AppendLine(")");

                using (OracleCommand cmd = new OracleCommand(query.ToString(), oconexion))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Alerta alerta = new Alerta
                            {
                                ProductoId = Convert.ToInt32(dr["ProductoId"]),
                                NombreP = dr["NombreProducto"].ToString(),
                                Mensaje = dr["Mensaje"].ToString(),
                                Stock = Convert.ToInt32(dr["Stock"]),
                                FechaAlerta = Convert.ToDateTime(dr["FechaAlerta"])
                            };

                            listaAlertas.Add(alerta);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
                listaAlertas.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
                listaAlertas.Clear();
            }
            finally
            {
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();
                }
            }

            return listaAlertas;
        }







        public int Registrar(Producto obj, out string mensaje)
        {
            int productoGenerado = 0;
            mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();

                //OracleCommand cmd = new OracleCommand("SP_registrarProducto", oconexion);
                OracleCommand cmd = new OracleCommand("ProductoPkg.SP_registrarProducto", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.Add(new OracleParameter("idProducto", OracleDbType.Int32)).Value = obj.IdProducto;
                cmd.Parameters.Add(new OracleParameter("Codigo", OracleDbType.Varchar2)).Value = obj.Codigo;
                cmd.Parameters.Add(new OracleParameter("Nombre", OracleDbType.Varchar2)).Value = obj.Nombre;
                cmd.Parameters.Add(new OracleParameter("Descripcion", OracleDbType.Varchar2)).Value = obj.Descripcion;
                cmd.Parameters.Add(new OracleParameter("idCategoria", OracleDbType.Int32)).Value = obj.oCategoria.Idcategoria;
                cmd.Parameters.Add(new OracleParameter("Estado", OracleDbType.Int32)).Value = obj.Estado;

                // Parámetros de salida
                OracleParameter paramResultado = new OracleParameter("Resultado", OracleDbType.Int32);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                OracleParameter paramMensaje = new OracleParameter("Mensaje", OracleDbType.Varchar2, 1000);
                paramMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramMensaje);

                oconexion.Open();
                cmd.ExecuteNonQuery();  // Ejecutar el procedimiento almacenado

                productoGenerado = Convert.ToInt32(paramResultado.Value);  // Obtener el resultado del parámetro de salida
                mensaje = paramMensaje.Value.ToString();  // Obtener el mensaje del parámetro de salida
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                productoGenerado = 0;
                mensaje = "Error de base de datos: " + ex.Message;  // Error específico de Oracle
            }
            catch (Exception ex)
            {
                productoGenerado = 0;
                mensaje = "Error: " + ex.Message;  // Error general
            }
            finally
            {
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Cerrar la conexión para evitar fugas
                }
            }

            return productoGenerado;
        }






        public bool ModificarProducto(int idProducto, string codigo, string nombre, string descripcion, int idCategoria, int estado, out string mensaje)
        {
            bool resultado = false;
            mensaje = "";

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();  // Obteniendo conexión
                using (OracleCommand cmd = new OracleCommand("ProductoPkg.SP_ModificarProductos", oconexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.Add(new OracleParameter("IdProducto", OracleDbType.Int32)).Value = idProducto;
                    cmd.Parameters.Add(new OracleParameter("Codigo", OracleDbType.Varchar2)).Value = codigo;
                    cmd.Parameters.Add(new OracleParameter("Nombre", OracleDbType.Varchar2)).Value = nombre;
                    cmd.Parameters.Add(new OracleParameter("Descripcion", OracleDbType.Varchar2)).Value = descripcion;
                    cmd.Parameters.Add(new OracleParameter("IdCategoria", OracleDbType.Int32)).Value = idCategoria;
                    cmd.Parameters.Add(new OracleParameter("Estado", OracleDbType.Int32)).Value = estado;

                    // Parámetros de salida
                    OracleParameter paramResultado = new OracleParameter("Resultado", OracleDbType.Int32);
                    paramResultado.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramResultado);

                    OracleParameter paramMensaje = new OracleParameter("Mensaje", OracleDbType.Varchar2, 500);
                    paramMensaje.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramMensaje);

                    oconexion.Open();  // Abrir la conexión
                    cmd.ExecuteNonQuery();  // Ejecutar el procedimiento almacenado

                    // Obtener valores de salida
                    resultado = Convert.ToInt32(paramResultado.Value) == 1;  // Convertir a booleano
                    mensaje = paramMensaje.Value.ToString();  // Obtener el mensaje del parámetro de salida
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                resultado = false;
                mensaje = "Error de base de datos: " + ex.Message;  // Manejar errores específicos de Oracle
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = "Error general: " + ex.Message;  // Manejar errores generales
            }
            finally
            {
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Cerrar la conexión para evitar fugas
                }
            }

            return resultado;  // Devolver el resultado booleano
        }




        public bool Eliminar(Producto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();  // Obtiene la conexión

                OracleCommand cmd = new OracleCommand("ProductoPkg.SP_eliminarProducto", oconexion);  // Verifica el nombre del procedimiento
                cmd.CommandType = CommandType.StoredProcedure;

                // Configuración de parámetros de entrada y salida
                cmd.Parameters.Add(new OracleParameter("IdProducto", OracleDbType.Int32)).Value = obj.IdProducto;  // Cambiar a OracleDbType
                OracleParameter paramRespuesta = new OracleParameter("Respuesta", OracleDbType.Int32);
                paramRespuesta.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramRespuesta);

                OracleParameter paramMensaje = new OracleParameter("Mensaje", OracleDbType.Varchar2, 200);
                paramMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramMensaje);

                oconexion.Open();  // Abrir la conexión
                cmd.ExecuteNonQuery();  // Ejecutar el procedimiento almacenado

                // Obtener valores de salida
                respuesta = Convert.ToBoolean(Convert.ToInt32(paramRespuesta.Value));  // Convertir a booleano
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

            return respuesta;  // Devolver el resultado booleano
        }




        /*public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdProducto, Codigo, Nombre, p.Descripcion, c.Idcategoria, c.Descripcion as DescripcionCategoria, Stock, PrecioCompra, PrecioVenta, p.Estado From Producto p");
                    query.AppendLine("inner join CATEGORIA c on c.IdCategoria = p.IdCategoria");

                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {

                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oCategoria = new Categoria() { Idcategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DescripcionCategoria"].ToString() },
                                Stock = Convert.ToInt32(dr["Stock"].ToString()),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Estado = Convert.ToBoolean(dr["Estado"])

                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    lista = new List<Producto>();
                }
                finally
                {
                    oconexion.Close();
                }

                return lista;
            }
        }









        public int Registrar(Producto obj, out string Mensaje)
        {
            int usuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    OracleCommand cmd = new OracleCommand("SP_registrarProducto", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("idProducto", OracleType.Int32).Value = obj.IdProducto;
                    cmd.Parameters.Add("Codigo", OracleType.VarChar).Value = obj.Codigo;
                    cmd.Parameters.Add("Nombre", OracleType.VarChar).Value = obj.Nombre;
                    cmd.Parameters.Add("Descripcion", OracleType.VarChar).Value = obj.Descripcion;
                    cmd.Parameters.Add("idCategoria", OracleType.VarChar).Value = obj.oCategoria.Idcategoria;
                    cmd.Parameters.Add("Estado", OracleType.Int32).Value = obj.Estado;// Tipo correcto para OUT parameter
                    cmd.Parameters.Add("Resultado", OracleType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", OracleType.VarChar, 1000).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    usuariogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();





                }
            }
            catch (Exception ex)
            {
                usuariogenerado = 0;
                Mensaje = ex.Message;

            }

            return usuariogenerado;
        }



        public bool ModificarProducto(int idProducto, string codigo, string nombre, string descripcion, int idCategoria, int estado, out string mensaje)
        {
            bool resultado = false;
            mensaje = "";

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    using (OracleCommand cmd = new OracleCommand("SP_ModificarProductos", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        cmd.Parameters.Add("IdProducto", OracleType.Int32).Value = idProducto;
                        cmd.Parameters.Add("Codigo", OracleType.VarChar).Value = codigo;
                        cmd.Parameters.Add("Nombre", OracleType.VarChar).Value = nombre;
                        cmd.Parameters.Add("Descripcion", OracleType.VarChar).Value = descripcion;
                        cmd.Parameters.Add("IdCategoria", OracleType.Int32).Value = idCategoria;
                        cmd.Parameters.Add("Estado", OracleType.Number).Value = estado;

                        // Parámetros de salida
                        cmd.Parameters.Add("Resultado", OracleType.Int32).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("Mensaje", OracleType.VarChar, 500).Direction = ParameterDirection.Output;

                        oconexion.Open();
                        cmd.ExecuteNonQuery();

                        // Obtener valores de los parámetros de salida
                        resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value) == 1; // Convertir a bool
                        mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }

            return resultado; // Devuelve el resultado booleano
        }



        public bool Eliminar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    OracleCommand cmd = new OracleCommand("SP_registrarProductos", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Añadir parámetros
                    cmd.Parameters.Add("IdProducto", OracleType.VarChar).Value = obj.IdProducto;
                    cmd.Parameters.Add("Respuesta", OracleType.Number).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", OracleType.VarChar, 200).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener valores de los parámetros de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        */

    }
}