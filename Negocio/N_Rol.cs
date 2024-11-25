using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Negocio
{
    public class N_Rol
    {
        private D_Rol objd_rol = new D_Rol();

        public List<Rol> Listar()
        {
            return objd_rol.Listar();
        }

    }
}
