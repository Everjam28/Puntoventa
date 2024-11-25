using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Pago
    {
            public int IdPago { get; set; }
            public string Metodo { get; set; }         // Efectivo, Tarjeta, Transferencia, etc.
            public decimal Monto { get; set; }         // Monto pagado
            public string Estado { get; set; }         // Realizado, Pendiente, Cancelado
            public DateTime FechaPago { get; set; }    // Fecha del pago

            // Relación con Venta (opcional si deseas mantener la conexión en ambos lados)
            public int? IdVenta { get; set; }

        

    }
}
