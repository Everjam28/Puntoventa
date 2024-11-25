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
    public partial class FrmDetalleCompra : Form
    {
        public FrmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new N_Compra().ObtenerCompra(txt_Buscar.Text);

            if(oCompra.IdCompra != 0 ) {

                txt_NumeroDocu.Text = oCompra.NumeroDocumento;

                txt_fecha.Text = oCompra.FechaRegistro;
                txt_TipoDocumento.Text = oCompra.TipoDocumento;
                txt_Usuario.Text = oCompra.oUsuario.PrimerNombre.ToString();
                txt_Apellido.Text = oCompra.oUsuario.PrimerApellido.ToString();
                txt_documenP.Text = oCompra.oProveedor.Documento;
                txt_RazonP.Text = oCompra.oProveedor.RazonSocial;
                

                Dtg_D_Compra.Rows.Clear();
                foreach(Detalle_Compra dc in oCompra.oDetalleCompra)
                {
                    Dtg_D_Compra.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                }

                txt_TP.Text = oCompra.MontoTotal.ToString("00.000");
            
            }
        }

        private void Btn_LimpiarBuscar_Click(object sender, EventArgs e)
        {
            txt_fecha.Text = "";
            //txt_Id.Text = "0";
            txt_TipoDocumento.Text = "";
            txt_Usuario.Text = "";
            txt_documenP.Text = "";
            txt_RazonP.Text = "";

            Dtg_D_Compra.Rows.Clear();
            txt_TP.Text = "00.000";

        }

        private void Btn_Dpdf_Click(object sender, EventArgs e)
        {
            if(txt_TipoDocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            string Texto_Html = Properties.Resources.PlantillaCompra.ToString();
            Negocios odatos = new N_Negocio().Obtenerdatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.Ruc);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

            Texto_Html = Texto_Html.Replace("@tipodocumento",txt_TipoDocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txt_NumeroDocu.Text);


            Texto_Html = Texto_Html.Replace("@docproveedor", txt_documenP.Text);
            Texto_Html = Texto_Html.Replace("@nombreproveedor", txt_RazonP.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro",txt_fecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txt_Usuario.Text);


            string filas = string.Empty;
            foreach (DataGridViewRow row in Dtg_D_Compra.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioC"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubT"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txt_TP.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Compra_{0}.pdf", txt_NumeroDocu.Text );
            savefile.Filter = "Pdf Files|*.pdf";

            if(savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream  stream = new FileStream(savefile.FileName, FileMode.Create)){

                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25,25 );

                    PdfWriter write = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteimage = new N_Negocio().obtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteimage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left,pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(write, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }



        }
    }
}
