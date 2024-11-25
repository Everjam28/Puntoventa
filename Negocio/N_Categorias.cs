using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Categorias
    {
        public D_Categorias obj_usuario = new D_Categorias();
        public List<Categoria> Listar()
        {
            return obj_usuario.Listar();
        }


        public int Registrar(Categoria obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la categoria\n";
            }

            

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return obj_usuario.Registrar(obj, out Mensaje);
            }



        }

        public bool EditarCategoria(int idCategoria, string descripcion, int estado, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(descripcion))
            {
                mensaje = "La descripción de la categoría no puede estar vacía.";
                return false;
            }

            return new D_Categorias().EditarCategoria(idCategoria, descripcion, estado, out mensaje);
        }


        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            return obj_usuario.Eliminar(obj, out Mensaje);
        }

        private D_Categorias datosCategorias = new D_Categorias();

        public bool VerificarExistenciaCategoria(int idCategoria)
        {
            // Llama al método de la capa de datos
            return datosCategorias.VerificarExistenciaCategoria(idCategoria);
        }
    }
}
