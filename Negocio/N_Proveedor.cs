using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Proveedor
    {
        public D_Proveedor obj_usuario = new D_Proveedor();

        public List<Proveedor> Listar()
        {
            return obj_usuario.Listar();
        }

        public int Registrar(Proveedor obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario La Razon Social del Proveedor\n";
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

        public bool Editar(Proveedor obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario La Razon Social del Proveedor\n";
            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return obj_usuario.Editar(obj, out Mensaje);
            }


        }

        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            return obj_usuario.Eliminar(obj, out Mensaje);
        }

    }
}

