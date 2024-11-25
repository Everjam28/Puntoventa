//using Oracle.ManagedDataAccess.Client;
using System.Data.OracleClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_productos
    {
/*
        public DataTable listado_ca()
        {
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = Conexion.getInstancia().CrearConexion();

            try
            {
                SqlCon.Open();

                using (OracleCommand Comando = new OracleCommand("SELECT Descripcion, Idcategoria FROM Categoria", SqlCon))
                {
                    Comando.CommandType = CommandType.Text;

                    using (OracleDataReader Resultado = Comando.ExecuteReader())
                    {
                        Tabla.Load(Resultado);
                    }
                }

                return Tabla;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
*/


    }
        

}
