using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Negocio
    {
        public D_Negocio obj_negocio = new D_Negocio();

        public Negocios Obtenerdatos()
        {
            return obj_negocio.ObtenerDatos();
        }

        public bool GuardarDatos(Negocios obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el Documento del usuario\n";
            }

            if (obj.Ruc == "")
            {
                Mensaje += "Es necesario el nombre del usuario\n";
            }

            if (obj.Direccion == "")
            {
                Mensaje += "Es necesario el Apellido del usuario\n";
            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return obj_negocio.ActualizarDatos(obj, out Mensaje);
            }
        }


        public byte[] obtenerLogo(out bool obtenido)
        {
            return obj_negocio.obtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen, out string Mensaje)
        {
            return obj_negocio.ActualizarLogo(imagen,out Mensaje);
        }
    }
}
