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
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;

namespace Datos
{
    public class D_Categorias
    {

        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdCategoria, Descripcion, Estado FROM CATEGORIA");

                    OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Categoria categoria = new Categoria();

                            if (!dr.IsDBNull(dr.GetOrdinal("IdCategoria")))
                            {
                                categoria.Idcategoria = Convert.ToInt32(dr["IdCategoria"]);
                            }

                            if (!dr.IsDBNull(dr.GetOrdinal("Descripcion")))
                            {
                                categoria.Descripcion = dr["Descripcion"].ToString();
                            }

                            if (!dr.IsDBNull(dr.GetOrdinal("Estado")))
                            {
                                categoria.Estado = Convert.ToBoolean(dr["Estado"]);
                            }

                            lista.Add(categoria);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al listar categorías: {ex.Message}", ex); // Manejo de excepciones
                }
                finally
                {
                    if (oconexion.State == System.Data.ConnectionState.Open)
                    {
                        oconexion.Close(); // Cerrar la conexión de forma segura
                    }
                }
            }

            return lista;
        }



       public int Registrar(Categoria obj, out string Mensaje)
        {
            int usuariogenerado = 0;
            Mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();
                OracleCommand cmd = new OracleCommand("CategoriaPkg.SP_RegistrarCategorias", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.Add(new OracleParameter("IdCategoria", OracleDbType.Int32)).Value = obj.Idcategoria;
                cmd.Parameters.Add(new OracleParameter("Descripcion", OracleDbType.Varchar2)).Value = obj.Descripcion;
                cmd.Parameters.Add(new OracleParameter("Estado", OracleDbType.Int32)).Value = obj.Estado;

                // Parámetros de salida
                OracleParameter paramResultado = new OracleParameter("Resultado", OracleDbType.Int32);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                OracleParameter paramMensaje = new OracleParameter("Mensaje", OracleDbType.Varchar2, 1000);
                paramMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramMensaje);

                // Abrir conexión y ejecutar comando
                oconexion.Open();
                cmd.ExecuteNonQuery();

                // Obtener el resultado del parámetro de salida
                usuariogenerado = Convert.ToInt32(((Oracle.ManagedDataAccess.Types.OracleDecimal)paramResultado.Value).Value);
                Mensaje = paramMensaje.Value.ToString();  // Obtener el mensaje del parámetro de salida
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                usuariogenerado = 0;
                Mensaje = "Error de base de datos: " + ex.Message;
            }
            catch (Exception ex)
            {
                usuariogenerado = 0;
                Mensaje = "Error general: " + ex.Message;
            }
            finally
            {
                if (oconexion != null && oconexion.State == System.Data.ConnectionState.Open)
                {
                    oconexion.Close();  // Asegúrate de cerrar la conexión
                }
            }

            return usuariogenerado;
        }




        public bool EditarCategoria(int idCategoria, string descripcion, int estado, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            OracleConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                conexion.Open();

                OracleTransaction transaction = conexion.BeginTransaction();

                try
                {
                    OracleCommand cmd = new OracleCommand("CategoriaPkg.SP_EditarCategoria", conexion);
                    cmd.Transaction = transaction;
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.Add(new OracleParameter("Idcategoria", OracleDbType.Int32)).Value = idCategoria;
                    cmd.Parameters.Add(new OracleParameter("Descripcion", OracleDbType.Varchar2)).Value = descripcion;
                    cmd.Parameters.Add(new OracleParameter("Estado", OracleDbType.Int32)).Value = estado;

                    // Parámetros de salida
                    OracleParameter paramResultado = new OracleParameter("Resultado", OracleDbType.Int32);
                    paramResultado.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramResultado);

                    OracleParameter paramMensaje = new OracleParameter("Mensaje", OracleDbType.Varchar2, 200);
                    paramMensaje.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramMensaje);

                    // Ejecutar el comando
                    cmd.ExecuteNonQuery();

                    // Obtener valores de salida
                    resultado = Convert.ToInt32(((Oracle.ManagedDataAccess.Types.OracleDecimal)paramResultado.Value).Value) == 1;
                    mensaje = paramMensaje.Value.ToString();

                    transaction.Commit();  // Confirmar la transacción
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Revertir en caso de error
                    throw;  // Propagar la excepción para manejo en un nivel superior
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                resultado = false;
                mensaje = "Error de base de datos: " + ex.Message;  // Error específico de Oracle
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = "Error: " + ex.Message;  // Error general
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();  // Cerrar la conexión de forma segura
                }
            }

            return resultado;
        }




        public bool Eliminar(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();
                OracleCommand cmd = new OracleCommand("CategoriaPkg.SP_EliminarCategoria", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Configurar parámetros
                cmd.Parameters.Add(new OracleParameter("Idcategoria", OracleDbType.Int32)).Value = obj.Idcategoria;

                OracleParameter paramResultado = new OracleParameter("Resultado", OracleDbType.Int32);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                OracleParameter paramMensaje = new OracleParameter("Mensaje", OracleDbType.Varchar2, 200);
                paramMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramMensaje);

                oconexion.Open();
                cmd.ExecuteNonQuery();

                // Obtener valores de salida
                respuesta = Convert.ToInt32(((Oracle.ManagedDataAccess.Types.OracleDecimal)paramResultado.Value).Value) == 1;
                mensaje = paramMensaje.Value.ToString();
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
                    oconexion.Close();  // Asegúrate de cerrar la conexión para evitar fugas
                }
            }

            return respuesta;
        }





        public bool VerificarExistenciaCategoria(int idCategoria)
        {
            bool existe = false;

            try
            {
                using (OracleConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();

                    string query = "SELECT COUNT(*) FROM CATEGORIA WHERE Idcategoria = :idCategoria";
                    using (OracleCommand cmd = new OracleCommand(query, conexion))
                    {
                        // Utiliza OracleDbType en lugar de OracleType
                        cmd.Parameters.Add("idCategoria", OracleDbType.Int32).Value = idCategoria;

                        // Usa ExecuteScalar para obtener el recuento directamente
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        existe = (count > 0);
                    }
                }
            }
            catch (OracleException ex)
            {
                // Registra o maneja la excepción adecuadamente
                Console.WriteLine("Error de base de datos: " + ex.Message);
                existe = false; // Marcar como no existente en caso de excepción
            }
            catch (Exception ex)
            {
                // Registra o maneja la excepción adecuadamente
                Console.WriteLine("Error: " + ex.Message);
                existe = false; // Marcar como no existente en caso de excepción
            }

            return existe;
        }





    }
}
