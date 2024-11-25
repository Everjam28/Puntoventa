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
using System.Collections;
using System.IO;
using Oracle.ManagedDataAccess.Types;




namespace Datos
{
    public class D_Compra
    {
        public int ObtenerCorrelativo()
        {

            int idcorrelativo = 0;

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("SELECT sec_compra.nextval FROM dual", oconexion);
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



         public void RegistrarCompra(Compra compra)
         {
             using (OracleConnection oconexion = Conexion.ObtenerConexion())
             {
                 oconexion.Open();
                 OracleTransaction transaction = oconexion.BeginTransaction();

                 try
                 {
                     // Insertar en la tabla Compra
                     string insertCompraQuery = @"
                     INSERT INTO Compra (IDCOMPRA, DOCUMENTOU, DOCUMENTOP, TIPODOCUMENTO, NUMERODOCUMENTO, MONTOTOTAL, FECHAREGISTRO)
                     VALUES (:IDCOMPRA, :DOCUMENTOU, :DOCUMENTOP, :TIPODOCUMENTO, :NUMERODOCUMENTO, :MONTOTOTAL, TO_DATE(:FECHAREGISTRO, 'YYYY-MM-DD HH24:MI:SS'))";

                     using (OracleCommand insertCompraCmd = new OracleCommand(insertCompraQuery, oconexion))
                     {
                         insertCompraCmd.Transaction = transaction;

                         // Asignar parámetros
                         insertCompraCmd.Parameters.Add(new OracleParameter("IDCOMPRA", OracleDbType.Int64)).Value = compra.IdCompra;
                         insertCompraCmd.Parameters.Add(new OracleParameter("DOCUMENTOU", OracleDbType.Varchar2)).Value = compra.oUsuario.Documento;
                         insertCompraCmd.Parameters.Add(new OracleParameter("DOCUMENTOP", OracleDbType.Varchar2)).Value = compra.oProveedor.Documento;
                         insertCompraCmd.Parameters.Add(new OracleParameter("TIPODOCUMENTO", OracleDbType.Varchar2)).Value = compra.TipoDocumento;
                         insertCompraCmd.Parameters.Add(new OracleParameter("NUMERODOCUMENTO", OracleDbType.Varchar2)).Value = compra.NumeroDocumento;
                         insertCompraCmd.Parameters.Add(new OracleParameter("MONTOTOTAL", OracleDbType.Decimal)).Value = compra.MontoTotal;
                         insertCompraCmd.Parameters.Add(new OracleParameter("FECHAREGISTRO", OracleDbType.Varchar2)).Value = compra.FechaRegistro;

                         insertCompraCmd.ExecuteNonQuery();
                     }

                     // Insertar en la tabla DetalleCompra
                     string insertDetalleCompraQuery = @"
                     INSERT INTO DetalleCompra (IDDETALLECOMPRA, IDCOMPRA, IDPRODUCTO, PRECIOCOMPRA, PRECIOVENTA, CANTIDAD, MONTOTOTAL, FECHAREGISTRO)
                     VALUES (SEQ_IDDETALLECOMPRA.NEXTVAL, :IDCOMPRA, :IDPRODUCTO, :PRECIOCOMPRA, :PRECIOVENTA, :CANTIDAD, :MONTOTOTAL, TO_DATE(:FECHAREGISTRO, 'YYYY-MM-DD HH24:MI:SS'))";

                     foreach (var detalle in compra.oDetalleCompra)
                     {
                         using (OracleCommand insertDetalleCompraCmd = new OracleCommand(insertDetalleCompraQuery, oconexion))
                         {
                             insertDetalleCompraCmd.Transaction = transaction;

                             // Asignar parámetros
                             insertDetalleCompraCmd.Parameters.Add(new OracleParameter("IDCOMPRA", OracleDbType.Int64)).Value = compra.IdCompra;
                             insertDetalleCompraCmd.Parameters.Add(new OracleParameter("IDPRODUCTO", OracleDbType.Int64)).Value = detalle.oProducto.IdProducto;
                             insertDetalleCompraCmd.Parameters.Add(new OracleParameter("PRECIOCOMPRA", OracleDbType.Decimal)).Value = detalle.PrecioCompra;
                             insertDetalleCompraCmd.Parameters.Add(new OracleParameter("PRECIOVENTA", OracleDbType.Decimal)).Value = detalle.PrecioVenta;
                             insertDetalleCompraCmd.Parameters.Add(new OracleParameter("CANTIDAD", OracleDbType.Int32)).Value = detalle.Cantidad;
                             insertDetalleCompraCmd.Parameters.Add(new OracleParameter("MONTOTOTAL", OracleDbType.Decimal)).Value = detalle.MontoTotal;
                             insertDetalleCompraCmd.Parameters.Add(new OracleParameter("FECHAREGISTRO", OracleDbType.Varchar2)).Value = detalle.FechaRegistro;

                             insertDetalleCompraCmd.ExecuteNonQuery();
                         }
                     }


                    // Confirmar transacción
                    transaction.Commit();
                 }
                 catch (Exception ex)
                 {
                     // En caso de error, deshacer transacción
                     transaction.Rollback();
                     throw new Exception("Error al registrar la compra: " + ex.Message);
                 }
             }
         }





        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT c.IdCompra,");
                    query.AppendLine("u.Primer_Nombre,");
                    query.AppendLine("u.Primer_Apellido,");
                    query.AppendLine("pr.DocumentoP, pr.RazonSocial,");
                    query.AppendLine("c.TipoDocumento, c.NumeroDocumento, c.MontoTotal, c.FechaRegistro");
                    query.AppendLine("FROM Compra c");
                    query.AppendLine("INNER JOIN Usuarios u ON u.Documento = c.DocumentoU");
                    query.AppendLine("INNER JOIN Proveedor pr ON pr.DocumentoP = c.DocumentoP");
                    query.AppendLine("WHERE c.NumeroDocumento = :numero");

                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.Parameters.Add(new OracleParameter(":numero", OracleDbType.Varchar2)).Value = numero;

                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                oUsuario = new Usuario() { PrimerNombre = dr["Primer_Nombre"].ToString(), PrimerApellido = dr["Primer_Apellido"].ToString() },
                                oProveedor = new Proveedor() { Documento = dr["DocumentoP"].ToString(), RazonSocial = dr["RazonSocial"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    obj = new Compra();
                }
                finally
                {
                    oconexion.Close();
                }
            }

            return obj;
        }


        public List<Detalle_Compra> ObtenerDetalleCompra(int idcompra)
        {
            List<Detalle_Compra> oLista = new List<Detalle_Compra>();
            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal FROM DetalleCompra dc");
                    query.AppendLine("INNER JOIN Producto p ON p.IdProducto = dc.IdProducto");
                    query.AppendLine("WHERE dc.IdCompra = :idcompra");

                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.Parameters.Add(new OracleParameter(":idcompra", OracleDbType.Int32)).Value = idcompra;
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            decimal precioCompra = dr.GetDecimal(dr.GetOrdinal("PrecioCompra"));
                            int cantidad = dr.GetInt32(dr.GetOrdinal("Cantidad"));
                            decimal montoTotal = dr.GetDecimal(dr.GetOrdinal("MontoTotal"));

                            oLista.Add(new Detalle_Compra()
                            {
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioCompra = precioCompra,
                                Cantidad = cantidad,
                                MontoTotal = montoTotal
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<Detalle_Compra>();
            }

            return oLista;
        }

        
    }
}