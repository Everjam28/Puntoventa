using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Reporte
    {
        private D_Reporte obj_reporte = new D_Reporte();

        public List<ReporteCompra> compra(string fechainicio, string fechafin, int idproveedor)
        {
            return obj_reporte.compra(fechainicio, fechafin, idproveedor);
        }



        public List<ReporteVenta> venta(string fechainicio, string fechafin)
        {
            return obj_reporte.ventas(fechainicio, fechafin);
        }

    }
}
