using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Compra
    {
        public D_Compra obj_compra = new D_Compra();

        public int ObtenerCorrelativo()
        {
            return obj_compra.ObtenerCorrelativo();
        }

        public bool Registrar(Compra obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones antes de llamar a la capa de datos
            if (obj == null)
            {
                Mensaje = "El objeto compra no puede ser nulo.";
                return false;
            }

            if (obj.oDetalleCompra == null || obj.oDetalleCompra.Count == 0)
            {
                Mensaje = "El detalle de la compra no puede ser nulo o vacío.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.TipoDocumento))
            {
                Mensaje = "El tipo de documento es obligatorio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.NumeroDocumento))
            {
                Mensaje = "El número de documento es obligatorio.";
                return false;
            }

            if (obj.MontoTotal <= 0)
            {
                Mensaje = "El monto total debe ser mayor que cero.";
                return false;
            }

            // Lógica de negocio adicional si es necesario
            // Por ejemplo, validaciones de precios, fechas, etc.
            foreach (var detalle in obj.oDetalleCompra)
            {
                if (detalle.PrecioCompra <= 0 || detalle.PrecioVenta <= 0 || detalle.Cantidad <= 0 || detalle.MontoTotal <= 0)
                {
                    Mensaje = "Los precios, cantidad y monto total en los detalles deben ser mayores que cero.";
                    return false;
                }
            }

            // Llamar al método de la capa de datos
            try
            {
                obj_compra.RegistrarCompra(obj);
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = "Error al registrar la compra: " + ex.Message;
                return false;
            }
        }
        



        private DataTable ConvertToDataTable(List<Detalle_Compra> detallesCompra)
        {
            DataTable dataTable = new DataTable();

            // Definir las columnas del DataTable
            dataTable.Columns.Add("IdProducto", typeof(int));
            dataTable.Columns.Add("PrecioCompra", typeof(decimal));
            dataTable.Columns.Add("PrecioVenta", typeof(decimal));
            dataTable.Columns.Add("Cantidad", typeof(int));
            dataTable.Columns.Add("MontoTotal", typeof(decimal));

            // Llenar el DataTable con los detalles de compra
            foreach (var detalle in detallesCompra)
            {
                dataTable.Rows.Add(detalle.oProducto.IdProducto, detalle.PrecioCompra, detalle.PrecioVenta, detalle.Cantidad, detalle.MontoTotal);
            }

            return dataTable;
        }




        public Compra ObtenerCompra(string numero)
        {
            Compra oCompra = obj_compra.ObtenerCompra(numero);

            if(oCompra.IdCompra != 0)
            {
                List<Detalle_Compra> oDetalleCompra = obj_compra.ObtenerDetalleCompra(oCompra.IdCompra);
                oCompra.oDetalleCompra = oDetalleCompra;
            }
            return oCompra;
        }
    }
}
