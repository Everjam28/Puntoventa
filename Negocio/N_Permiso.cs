using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Negocio
{
    public class N_Permiso
    {
        private D_Permiso obj_permiso = new D_Permiso();

        public List<Permiso>Listar(int IdUsuario)
        {
            return obj_permiso.Listar(IdUsuario);
        }
    }
}
