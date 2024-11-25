using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public  class N_Venta
    {
        public D_Ventas obj_venta = new D_Ventas();

        public bool RestarStock(int idproducto, int cantidad)
        {
            return obj_venta.RestarStock(idproducto, cantidad);
        }

        public bool SumarStock(int idproducto, int cantidad)
        {
            return obj_venta.SumarStock(idproducto, cantidad);
        }





        public int ObtenerCorrelativo()
        {
            return obj_venta.ObtenerCorrelativo();
        }

        public bool Registrar(Venta obj, out string Mensaje)
        {

            Mensaje = string.Empty;
            try
            {
                obj_venta.RegistrarVenta(obj);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = "Error al registrar la venta: " + ex.Message;
                return false;
            }
        }

        public Venta ObtenerVenta(string numero)
        {
            Venta oVenta = obj_venta.ObtenerVenta(numero);

            if (oVenta.Idventa != 0)
            {
                List<Detalle_Venta> oDetalleVenta = obj_venta.ObtenerDetalleVenta(oVenta.Idventa);
                oVenta.oDetalleVenta = oDetalleVenta;
            }
            return oVenta;
        }

        private D_Ventas datosVentas = new D_Ventas();

        public List<KeyValuePair<string, int>> ObtenerTopProductos()
        {
            return datosVentas.ObtenerProductosMasVendidos();
        }

        public List<KeyValuePair<string, decimal>> ObtenerVentasPorMes()
        {
            return datosVentas.ObtenerVentasPorMes();
        }




    }
}
