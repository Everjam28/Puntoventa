using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zen.Barcode;
using System.Drawing;
using System.IO;


public class CodigoDeBarras
{
    public static void GenerarCodigoDeBarras(string texto, string rutaArchivo)
    {

        try
        {
            BarcodeDraw barcode = BarcodeDrawFactory.Code128WithChecksum;

            using (Image image = barcode.Draw(texto, 50))
            using (Bitmap bitmap = new Bitmap(image))
            {
                bitmap.Save(rutaArchivo);
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores
            throw new Exception("Error al generar el código de barras: " + ex.Message);
        }
    }
}
