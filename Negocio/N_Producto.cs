using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zen.Barcode;
using System.Drawing;


namespace Negocio
{
    public  class N_Producto
    {
        public D_Producto obj_usuario = new D_Producto();
        public List<Producto> Listar()
        {
            return obj_usuario.Listar();
        }

        public List<Alerta> ObtenerAlertasDeStockBajo()
        {
            return obj_usuario.ObtenerAlertasDeStockBajo();
        }




        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validación básica
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripción del producto.\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0; // Si hay errores, se retorna 0 y no se registra el producto
            }
            else
            {
                // Registrar el producto en la base de datos
                int productoGenerado = obj_usuario.Registrar(obj, out Mensaje);

               // if (productoGenerado > 0)
               // {
                    try
                    {
                        string rutaArchivo = Path.Combine(@"C:\Users\yjose\Documents\Codigosbarra", $"{obj.Codigo}.png");
                        CodigoDeBarras.GenerarCodigoDeBarras(obj.Codigo, rutaArchivo);
                        Console.WriteLine("Código de barras generado y guardado en: " + rutaArchivo);
                    }
                    catch (Exception ex)
                    {
                        Mensaje += $" Error al generar el código de barras: {ex.Message}";
                    }
               // }

                return productoGenerado;
            }
        }




        /*public void ModificarProducto(int idProducto, string codigo, string nombre, string descripcion, int idCategoria, int estado, out string mensaje)
        {
            D_Producto datosProducto = new D_Producto();
            datosProducto.ModificarProducto(idProducto, codigo, nombre, descripcion, idCategoria, estado, out mensaje);
        }*/

        public bool ModificarProducto(int idProducto,string codigo,string nombre, string descripcion,int idCategoria, int estado, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(descripcion))
            {
                mensaje = "La descripción de la categoría no puede estar vacía.";
                return false;
            }

            return new D_Producto().ModificarProducto(idProducto,codigo,nombre, descripcion,idCategoria, estado, out mensaje);
        }

        public bool Eliminar(Producto obj, out string Mensaje)
        {
            return obj_usuario.Eliminar(obj, out Mensaje);
        }

    }
}
