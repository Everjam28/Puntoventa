using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace Presentacion
{
    public partial class FrmDetalleVenta : Form
    {
        public FrmDetalleVenta()
        {
            InitializeComponent();
        }

        private void FrmDetalleVenta_Load(object sender, EventArgs e)
        {
            txt_Buscar.Select();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            Venta oVenta = new N_Venta().ObtenerVenta(txt_Buscar.Text);

            if (oVenta.Idventa != 0)
            {

                txt_NumeroDocu.Text = oVenta.NumeroDocumento;

                txt_fecha.Text = oVenta.FechaRegistro;
                txt_TipoDocumento.Text = oVenta.TipoDocumento;
                txt_Usuario.Text = oVenta.oUsuario.PrimerNombre.ToString();
                txt_Apellido.Text = oVenta.oUsuario.PrimerApellido.ToString();
                txt_documenC.Text = oVenta.DocumentoCliente;
                txt_NombreC.Text = oVenta.NombreCliente.ToString();


                Dtg_D_Venta.Rows.Clear();
                foreach (Detalle_Venta dv in oVenta.oDetalleVenta)
                {
                    Dtg_D_Venta.Rows.Add(new object[] { dv.oProducto.Nombre, dv.PrecioVenta, dv.Cantidad, dv.Subtotal });
                }

                txt_TP.Text = oVenta.MontoTotal.ToString("0.000");
                txt_Mpago.Text = oVenta.MontoPago.ToString("0.000");
                txt_MCambio.Text = oVenta.MontoCambio.ToString("0.000");

            }
        }

        private void Btn_LimpiarBuscar_Click(object sender, EventArgs e)
        {
            txt_fecha.Text = "";
            txt_TipoDocumento.Text = "";
            txt_Usuario.Text = "";
            txt_NumeroDocu.Text = "";
            txt_NombreC.Text = "";

            Dtg_D_Venta.Rows.Clear();
            txt_Mpago.Text = "0.00";
            txt_MCambio.Text = "0.00";
            txt_TP.Text = "0.00";
        }

        private void Btn_Dpdf_Click(object sender, EventArgs e)
        {

                if (txt_TipoDocumento.Text == "")
                {
                    MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string Texto_Html = Properties.Resources.PlantillaVenta.ToString();
                Negocios odatos = new N_Negocio().Obtenerdatos();

                Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
                Texto_Html = Texto_Html.Replace("@docnegocio", odatos.Ruc);
                Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

                Texto_Html = Texto_Html.Replace("@tipodocumento", txt_TipoDocumento.Text.ToUpper());
                Texto_Html = Texto_Html.Replace("@numerodocumento", txt_NumeroDocu.Text);

                Texto_Html = Texto_Html.Replace("@doccliente", txt_documenC.Text);
                Texto_Html = Texto_Html.Replace("@nombrecliente", txt_NombreC.Text);
                Texto_Html = Texto_Html.Replace("@fecharegistro", txt_fecha.Text);
                Texto_Html = Texto_Html.Replace("@usuarioregistro", txt_Usuario.Text);

                string filas = string.Empty;
                foreach (DataGridViewRow row in Dtg_D_Venta.Rows)
                {
                    filas += "<tr>";
                    filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["PrecioC"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["SubT"].Value.ToString() + "</td>";
                    filas += "</tr>"; // Etiqueta de cierre corregida
                }
                Texto_Html = Texto_Html.Replace("@filas", filas);
                Texto_Html = Texto_Html.Replace("@montototal", txt_TP.Text);
                Texto_Html = Texto_Html.Replace("@pagocon", txt_Mpago.Text);
                Texto_Html = Texto_Html.Replace("@cambio", txt_MCambio.Text);

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Venta_{0}.pdf", txt_NumeroDocu.Text);
                savefile.Filter = "Pdf Files|*.pdf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        bool obtenido = true;
                        byte[] byteimage = new N_Negocio().obtenerLogo(out obtenido);

                        if (obtenido)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteimage);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                            pdfDoc.Add(img);
                        }

                        using (StringReader sr = new StringReader(Texto_Html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                        MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }


        
    }
}
