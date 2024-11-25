using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Negocio
{
    public class N_Categoria
    {
        public D_Categoria obj_Categoria = new D_Categoria();


        /* public List<Categoria> ListarC()
         {
           D_Categoria categoria = new D_Categoria();

             return categoria.ListarC();
         }
        */



        public List<Categoria> Listar()
        {
            return obj_Categoria.ListarC();
        }


        public int Registrar(Categoria obj, out string Mensaje)
        {

            Mensaje = string.Empty;

          

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la Categoria\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return obj_Categoria.Registrar(obj, out Mensaje);
            }



        }

        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;


            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la Categoria\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return obj_Categoria.Editar(obj, out Mensaje);
            }

        }

        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            return obj_Categoria.Eliminar(obj, out Mensaje);
        }
    }
}
