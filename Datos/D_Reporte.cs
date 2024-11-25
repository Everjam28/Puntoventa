using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidad;
using System.Data;
using System.Collections;
using System.Security.Cryptography;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;

namespace Datos
{
    public class D_Reporte
    {

        public List<ReporteCompra> compra(string fechainicio, string fechafin, int idproveedor)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ReporteCompras", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.Add("fechainicio", OracleDbType.Varchar2).Value = fechainicio;
                    cmd.Parameters.Add("fechafin", OracleDbType.Varchar2).Value = fechafin;
                    cmd.Parameters.Add("documentoPro", OracleDbType.Int32).Value = idproveedor;

                    // Parámetro de salida
                    cmd.Parameters.Add("out_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteCompra()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoProveedor = dr["DocumentoP"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioCompra = dr["PrecioCompra"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                SubTotal = dr["SubTotal"].ToString(),
                            });
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



        /*public List<ReporteCompra> compra(string fechainicio, string fechafin, int idproveedor)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ReporteCompras", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.Add("fechainicio", OracleDbType.Varchar2).Value = fechainicio;
                    cmd.Parameters.Add("fechafin", OracleDbType.Varchar2).Value = fechafin;
                    cmd.Parameters.Add("documentoPro", OracleDbType.Int32).Value = idproveedor;

                    // Parámetro de salida
                    cmd.Parameters.Add("out_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteCompra()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoProveedor = dr["DocumentoP"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioCompra = dr["PrecioCompra"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                SubTotal = dr["SubTotal"].ToString(),
                            });
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
        }*/









        public List<ReporteVenta> ventas(string fechainicio, string fechafin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("ReporteVentas", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.Add("fechainicio", OracleDbType.Varchar2).Value = fechainicio;
                    cmd.Parameters.Add("fechafin", OracleDbType.Varchar2).Value = fechafin;
                    
                    // Parámetro de salida
                    cmd.Parameters.Add("out_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                SubTotal = dr["SubTotal"].ToString(),
                            });
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



    }
}
