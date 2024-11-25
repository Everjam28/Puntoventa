using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Alerta
    {
        public int ProductoId { get; set; }
        public string NombreP { get; set; }
       
        public string Mensaje { get; set; }
        public int Stock { get; set; }
        public DateTime FechaAlerta { get; set; }
    }
}
