using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Entidad;
using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace Datos
{
    public class D_Ventas
    {
        public int ObtenerCorrelativo()
        {

            int idcorrelativo = 0;

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("SELECT sec_venta.nextval FROM dual", oconexion);
                    oconexion.Open();
                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    //idcorrelativo = 0;
                    // Manejo de excepciones...
                }
                finally
                {
                    oconexion.Close();
                }
            }



            return idcorrelativo;

        }

        public bool RestarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET Stock = Stock - :cantidad WHERE idproducto = :idproducto");

                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.Parameters.Add(":cantidad", OracleDbType.Int32).Value = cantidad;
                    cmd.Parameters.Add(":idproducto", OracleDbType.Int32).Value = idproducto;
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    // Aquí puedes manejar la excepción según tus necesidades, como registrar el error
                }
                finally
                {
                    oconexion.Close();
                }
            }
            return respuesta;
        }


        public bool SumarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET Stock = Stock + :cantidad WHERE idproducto = :idproducto");

                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.Parameters.Add(":cantidad", OracleDbType.Int32).Value = cantidad;
                    cmd.Parameters.Add(":idproducto", OracleDbType.Int32).Value = idproducto;
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    // Aquí puedes manejar la excepción según tus necesidades, como registrar el error
                }
                finally
                {
                    oconexion.Close();
                }
            }
            return respuesta;
        }


        public void RegistrarVenta(Venta venta)
        {
            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                oconexion.Open();
                OracleTransaction transaction = oconexion.BeginTransaction();

                try
                {
                    // Insertar en la tabla Venta
                    string insertVentaQuery = @"
                    INSERT INTO Venta (IDVENTA, DOCUMENTOU, TIPODOCUMENTO, NUMERODOCUMENTO, DOCUMENTOCLIENTE, NOMBRECLIENTE, METODOPAGO, MONTOPAGO, MONTOCAMBIO, MONTOTOTAL, FECHAREGISTRO)
                    VALUES (:IDVENTA, :DOCUMENTOU, :TIPODOCUMENTO, :NUMERODOCUMENTO, :DOCUMENTOCLIENTE, :NOMBRECLIENTE, :METODOPAGO, :MONTOPAGO, :MONTOCAMBIO, :MONTOTOTAL, TO_DATE(:FECHAREGISTRO, 'YYYY-MM-DD HH24:MI:SS'))";

                    using (OracleCommand insertVentaCmd = new OracleCommand(insertVentaQuery, oconexion))
                    {
                        insertVentaCmd.Transaction = transaction;

                        // Asignar parámetros
                        insertVentaCmd.Parameters.Add(new OracleParameter("IDVENTA", OracleDbType.Int64)).Value = venta.Idventa;
                        insertVentaCmd.Parameters.Add(new OracleParameter("DOCUMENTOU", OracleDbType.Varchar2)).Value = venta.oUsuario.Documento;
                        insertVentaCmd.Parameters.Add(new OracleParameter("TIPODOCUMENTO", OracleDbType.Varchar2)).Value = venta.TipoDocumento;
                        insertVentaCmd.Parameters.Add(new OracleParameter("NUMERODOCUMENTO", OracleDbType.Varchar2)).Value = venta.NumeroDocumento;
                        insertVentaCmd.Parameters.Add(new OracleParameter("DOCUMENTOCLIENTE", OracleDbType.Varchar2)).Value = venta.DocumentoCliente;
                        insertVentaCmd.Parameters.Add(new OracleParameter("NOMBRECLIENTE", OracleDbType.Varchar2)).Value = venta.NombreCliente;
                        insertVentaCmd.Parameters.Add(new OracleParameter("METODOPAGO", OracleDbType.Varchar2)).Value = venta.MetodoPago;
                        insertVentaCmd.Parameters.Add(new OracleParameter("MONTOPAGO", OracleDbType.Varchar2)).Value = venta.MontoPago;
                        insertVentaCmd.Parameters.Add(new OracleParameter("MONTOCAMBIO", OracleDbType.Decimal)).Value = venta.MontoCambio;
                        insertVentaCmd.Parameters.Add(new OracleParameter("MONTOTOTAL", OracleDbType.Decimal)).Value = venta.MontoTotal;
                        insertVentaCmd.Parameters.Add(new OracleParameter("FECHAREGISTRO", OracleDbType.Varchar2)).Value = venta.FechaRegistro;

                        insertVentaCmd.ExecuteNonQuery();
                    }

                    // Insertar en la tabla DetalleVenta
                    string insertDetalleVentaQuery = @"
                    INSERT INTO DetalleVenta (IDDETALLEVENTA, IDVENTA, IDPRODUCTO, PRECIOVENTA, CANTIDAD, SUBTOTAL, FECHAREGISTRO)
                    VALUES (SEQ_IDDETALLEVENTA.NEXTVAL, :IDVENTA, :IDPRODUCTO, :PRECIOVENTA, :CANTIDAD, :SUBTOTAL, TO_DATE(:FECHAREGISTRO, 'YYYY-MM-DD HH24:MI:SS'))";

                    foreach (var detalle in venta.oDetalleVenta)
                    {
                        using (OracleCommand insertDetalleVentaCmd = new OracleCommand(insertDetalleVentaQuery, oconexion))
                        {
                            insertDetalleVentaCmd.Transaction = transaction;

                            // Asignar parámetros
                            insertDetalleVentaCmd.Parameters.Add(new OracleParameter("IDVENTA", OracleDbType.Int64)).Value = venta.Idventa;
                            insertDetalleVentaCmd.Parameters.Add(new OracleParameter("IDPRODUCTO", OracleDbType.Int64)).Value = detalle.oProducto.IdProducto;
                            insertDetalleVentaCmd.Parameters.Add(new OracleParameter("PRECIOVENTA", OracleDbType.Decimal)).Value = detalle.PrecioVenta;
                            insertDetalleVentaCmd.Parameters.Add(new OracleParameter("CANTIDAD", OracleDbType.Int32)).Value = detalle.Cantidad;
                            insertDetalleVentaCmd.Parameters.Add(new OracleParameter("SUBTOTAL", OracleDbType.Decimal)).Value = detalle.Subtotal;
                            insertDetalleVentaCmd.Parameters.Add(new OracleParameter("FECHAREGISTRO", OracleDbType.Varchar2)).Value = detalle.FechaRegistro;

                            insertDetalleVentaCmd.ExecuteNonQuery();
                        }
                    }

                    // Confirmar transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // En caso de error, deshacer transacción
                    transaction.Rollback();
                    throw new Exception("Error al registrar la venta: " + ex.Message);
                }
            }
        }


        public Venta ObtenerVenta(string numero)
        {
            Venta obj = new Venta();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT v.Idventa, u.Primer_Nombre,u.Primer_Apellido,");
                    query.AppendLine("v.DocumentoCliente, v.NombreCliente,");
                    query.AppendLine("v.TipoDocumento, v.NumeroDocumento,");
                    query.AppendLine("v.MontoPago, v.MontoCambio,v.MontoTotal,");
                    query.AppendLine("v.FechaRegistro");
                    query.AppendLine("FROM Venta v");
                    query.AppendLine("inner join Usuarios u ON u.Documento = v.documentou");
                    query.AppendLine(" WHERE v.numerodocumento = :numero");

                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.Parameters.Add(new OracleParameter(":numero", OracleDbType.Varchar2)).Value = numero;

                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Venta()
                            {
                                Idventa = Convert.ToInt32(dr["Idventa"]),
                                oUsuario = new Usuario() { PrimerNombre = dr["Primer_Nombre"].ToString(), PrimerApellido = dr["Primer_Apellido"].ToString() },
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"].ToString()),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    obj = new Venta();
                }
                finally
                {
                    oconexion.Close();
                }
            }

            return obj;
        }



        public List<Detalle_Venta> ObtenerDetalleVenta(int idventa)
        {
            List<Detalle_Venta> oLista = new List<Detalle_Venta>();
            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    StringBuilder query = new StringBuilder();


                    query.AppendLine("SELECT p.Nombre,dv.PrecioVenta,dv.cantidad,dv.subtotal FROM DetalleVenta dv");
                    query.AppendLine("inner join Producto p ON p.IdProducto = dv.IdProducto");
                    query.AppendLine("WHERE dv.IdVenta = :idventa");

                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.Parameters.Add(new OracleParameter(":idventa", OracleDbType.Int32)).Value = idventa;
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            decimal precioVenta = dr.GetDecimal(dr.GetOrdinal("PrecioVenta"));
                            int cantidad = dr.GetInt32(dr.GetOrdinal("Cantidad"));
                            decimal montoTotal = dr.GetDecimal(dr.GetOrdinal("subtotal"));

                            oLista.Add(new Detalle_Venta()
                            {
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Cantidad = Convert.ToInt32(dr["cantidad"].ToString()),
                                Subtotal = Convert.ToInt32(dr["subtotal"].ToString()),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<Detalle_Venta>();
            }

            return oLista;
        }



        public List<KeyValuePair<string, int>> ObtenerProductosMasVendidos()
        {
            List<KeyValuePair<string, int>> productos = new List<KeyValuePair<string, int>>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    string query = @"
                        SELECT 
                            p.nombre,
                            SUM(dv.cantidad) AS total_vendido
                        FROM 
                            producto p
                        JOIN 
                            detalleventa dv ON p.idproducto = dv.idproducto
                        GROUP BY 
                            p.nombre
                        ORDER BY 
                            total_vendido DESC
                        FETCH FIRST 5 ROWS ONLY";

                    OracleCommand cmd = new OracleCommand(query, oconexion);
                    oconexion.Open();

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreProducto = reader["nombre"].ToString();
                            int totalVendido = Convert.ToInt32(reader["total_vendido"]);

                            productos.Add(new KeyValuePair<string, int>(nombreProducto, totalVendido));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los productos más vendidos: " + ex.Message);
                }
                finally
                {
                    oconexion.Close();
                }
            }

            return productos;
        }


        public List<KeyValuePair<string, decimal>> ObtenerVentasPorMes()
        {
            List<KeyValuePair<string, decimal>> ventasPorMes = new List<KeyValuePair<string, decimal>>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    string query = @"
                        SELECT
                            TO_CHAR(v.fechaRegistro, 'YYYY-MM') AS mes,
                            SUM(v.montoTotal) AS total_ventas
                        FROM
                            venta v
                        GROUP BY
                            TO_CHAR(v.fechaRegistro, 'YYYY-MM')
                        ORDER BY
                            total_ventas DESC
                        FETCH FIRST 12 ROWS ONLY";

                    OracleCommand cmd = new OracleCommand(query, oconexion);
                    oconexion.Open();

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string mes = reader["mes"].ToString();
                            decimal totalVentas = Convert.ToDecimal(reader["total_ventas"]);

                            ventasPorMes.Add(new KeyValuePair<string, decimal>(mes, totalVentas));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las ventas por mes: " + ex.Message);
                }
                finally
                {
                    oconexion.Close();
                }
            }

            return ventasPorMes;
        }







    }
}
