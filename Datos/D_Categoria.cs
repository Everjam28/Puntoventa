using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OracleClient;
using Entidad;
using System.Data;

namespace Datos
{
    public  class D_Categoria
    {
        public List<Categoria> ListarC()
        {
            List<Categoria> lista = new List<Categoria>();
            OracleConnection oconexion = null;

            try
            {
                oconexion = Conexion.ObtenerConexion();

                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT u.IdCategoria,u.Descripcion,u.Estado FROM CATEGORIA u");

                OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria()
                        {
                            Idcategoria = Convert.ToInt32(dr["IdCategoria"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente si es necesario
            }
            finally
            {
                if (oconexion != null)
                {
                    oconexion.Close();
                }
            }

            return lista;
        }





        /*List<Categoria> lista = new List<Categoria>();
        OracleConnection oconexion = Conexion.ObtenerConexion(); // No usar 'using' aquí

        try
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT u.IdCategoria,u.Descripcion,u.Estado FROM CATEGORIA u");
            OracleCommand cmd = new OracleCommand(query.ToString(), oconexion);
            cmd.CommandType = CommandType.Text;
            oconexion.Open();

            using (OracleDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new Categoria()
                    {
                        Idcategoria = Convert.ToInt32(dr["IdCategoria"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"]),
                        //FechaRegistro = dr["Primer_Apellido"].ToString(),
                    });
                }
            }
        }
        catch (Exception ex)
        {
            // Manejar la excepción adecuadamente
        }
        finally
        {
            // Cerrar la conexión aquí en el bloque 'finally' para asegurarse de que siempre se cierre,
            // incluso si se lanza una excepción
            if (oconexion.State == ConnectionState.Open)
            {
                oconexion.Close();
            }
        }

        return lista;
    }*/




        public int Registrar(Categoria obj, out string Mensaje)
        {
            int Categoriagenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    OracleCommand cmd = new OracleCommand("SP_RegistrarCategorias", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Corregimos el tipo de dato para el parámetro IdCategoria
                    cmd.Parameters.Add("IdCategoria", OracleType.Int32).Value = obj.Idcategoria;

                    cmd.Parameters.Add("Descripcion", OracleType.VarChar).Value = obj.Descripcion;
                    cmd.Parameters.Add("Estado", OracleType.Number).Direction = ParameterDirection.Output; // Asegurarse de que este parámetro sea establecido por el procedimiento almacenado
                    cmd.Parameters.Add("Resultado", OracleType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", OracleType.VarChar, 1000).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener valores de salida
                    Categoriagenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Categoriagenerado = 0;
                Mensaje = ex.Message;

            }
            return Categoriagenerado;

        }






            public bool Editar(Categoria obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    OracleCommand cmd = new OracleCommand("SP_EditarCategoria", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("Idcategoria", OracleType.VarChar).Value = obj.Idcategoria;
                    cmd.Parameters.Add("Descripcion", OracleType.VarChar).Value = obj.Descripcion;
                    cmd.Parameters.Add("Resultado", OracleType.Number).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", OracleType.VarChar, 200).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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





        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (OracleConnection oconexion = Conexion.ObtenerConexion())
                {
                    OracleCommand cmd = new OracleCommand("SP_EliminarCategoria", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Añadir parámetros
                    cmd.Parameters.Add("Idcategoria", OracleType.VarChar).Value = obj.Idcategoria;
                    cmd.Parameters.Add("Resultado", OracleType.Number).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", OracleType.VarChar, 200).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener valores de los parámetros de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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




    }
}
