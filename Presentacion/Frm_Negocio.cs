using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class Frm_Negocio : Form
    {
        public Frm_Negocio()
        {
            InitializeComponent();
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes,0,imageBytes.Length);
            Image image = new Bitmap(ms);

            return image;
        }

        private void Frm_Negocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimage = new N_Negocio().obtenerLogo(out obtenido);

            if (obtenido)
                Pic_logo.Image = ByteToImage(byteimage);

            Negocios datos = new N_Negocio().Obtenerdatos();

            txt_nombre.Text = datos.Nombre;
            txt_Ruc.Text = datos.Ruc;
            txt_Direccion.Text = datos.Direccion;

        }

        private void btn_Subir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "Files|(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimage = File.ReadAllBytes(openFileDialog.FileName);
                bool respuesta = new N_Negocio().ActualizarLogo(byteimage, out mensaje);
                if (respuesta)
                    Pic_logo.Image = ByteToImage(byteimage);
                else
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Negocios obj = new Negocios()
            {
                
                Nombre = txt_nombre.Text,
                Ruc = txt_Ruc.Text,
                Direccion = txt_Direccion.Text
            };

            bool respuesta = new N_Negocio().GuardarDatos(obj, out mensaje);

            if(respuesta)
                MessageBox.Show( "Los cambios fueron guardados","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }
    }
}
