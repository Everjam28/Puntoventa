using Entidad;
using System;
using System.Collections.Generic;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            using (OracleConnection oconexion = Conexion.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdRol, Descripcion FROM Rol");
                    

                    using (OracleCommand cmd = new OracleCommand(query.ToString(), oconexion))
                    {
                       
                        cmd.CommandType = CommandType.Text;
                        oconexion.Open();

                        using (OracleDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                // Manejo de posibles valores nulos
                                int idRol = dr["IdRol"] is DBNull ? 0 : Convert.ToInt32(dr["IdRol"]);

                                lista.Add(new Rol()
                                {
                                    IdRol = Convert.ToInt32(dr["IdRol"]),
                                    Descripcion = dr["Descripcion"].ToString(),

                                    
                                }); ;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    lista = new List<Rol>();
                }
                finally
                {
                    oconexion.Close();
                }

                return lista;
            }
        }
    }
}
