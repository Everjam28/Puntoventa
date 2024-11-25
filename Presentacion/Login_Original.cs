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
using Negocio;
using Entidad;

namespace Presentacion
{
    public partial class Login_Original : Form
    {
        public Login_Original()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bt_Ingresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new N_Usuario().Listar(); 
            
            Usuario ousuario = new N_Usuario().Listar().Where(u => u.Documento == txt_Usuario.Text && u.Clave == txt_Contraseña.Text).FirstOrDefault();
            
            if(ousuario != null)
            {

                Inicio form = new Inicio(ousuario);
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;

            }
            else
            {
                MessageBox.Show("No se encontro el usuario","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
           

            
        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
           txt_Usuario.Text = "";
            txt_Contraseña.Text = "";
            this.Show();
        }
    }
}
