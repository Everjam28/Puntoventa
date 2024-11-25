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
using FontAwesome.Sharp;
using Negocio;
using Presentacion.Modales;
using System.Runtime.InteropServices;
namespace Presentacion
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;






        public Inicio(Usuario objusuario)
        {
            usuarioActual = objusuario;
            InitializeComponent();
            abrirDashborad();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;



        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparm, int lparam);


        private void Inicio_Load(object sender, EventArgs e)
        {


            int documentoNumero = int.Parse(usuarioActual.Documento);
            List<Permiso> ListarPermisos = new N_Permiso().Listar(documentoNumero);

            foreach (IconMenuItem iconmenu in Menuu.Items)
            {
                bool encontrado = ListarPermisos.Any(m => m.Nombremenu == iconmenu.Name);

                if (encontrado == false)
                {
                    iconmenu.Visible = true;
                }
            }

            lbUsuario.Text = usuarioActual.PrimerNombre;
            txt_Rol.Text = usuarioActual.oRol.Descripcion;

            // Verifica si el rol es "empleado" y deshabilita botones
            if (usuarioActual.oRol.Descripcion.ToLower() == "empleado")
            {
                Musuarios.Enabled = false;
                Mcompras.Enabled = false;
                Mproveedores.Enabled = false;
            }




            /*
            int documentoNumero = int.Parse(usuarioActual.Documento);
            List<Permiso> ListarPermisos = new N_Permiso().Listar(documentoNumero);

           // List<Permiso> ListarPermisos = new N_Permiso().Listar(usuarioActual.Documento;

            //List<Permiso> ListarPermisos = new N_Permiso().Listar(usuarioActual.IdUsuario);
            
                foreach (IconMenuItem iconmenu in Menuu.Items)
                {
                    bool encontrado = ListarPermisos.Any(m => m.Nombremenu == iconmenu.Name);

                    if(encontrado == false)
                    {
                        iconmenu.Visible = true;
                    }
                }
              
                lbUsuario.Text = usuarioActual.PrimerNombre;
            txt_Rol.Text = usuarioActual.oRol.Descripcion;*/



        }



        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(MenuActivo != null)
            {
                MenuActivo.BackColor = Color.DeepSkyBlue;
            }

            menu.BackColor = Color.LimeGreen;
            MenuActivo = menu;

            if(FormularioActivo != null){
                FormularioActivo.Close();

            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            //formulario.BackColor = Color(24; 28; 63);
            
            Pcontenedor.Controls.Add(formulario);
            formulario.Show();

           


        }








        private void Musuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new Frm_Usuario());


        }

        private void subCateg_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Mmantenedor, new Frm_Categorias());
        }

        private void subProd_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Mmantenedor, new Frm_Productos());
        }

        private void subRegistrar_Click(object sender, EventArgs e)
        {
            AbrirFormulario(subRegistrarV, new FrmVentas(usuarioActual));
        }

        private void subDventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(subRegistrarV, new FrmDetalleVenta());
        }

        private void subRegistrarC_Click(object sender, EventArgs e)
        {
            AbrirFormulario(subRegistrarC, new FrmCompras(usuarioActual));
        }

        private void subRegistarDcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(subRegistrarC, new FrmDetalleCompra());
        }

        private void Mclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmClientes());
        }

        private void Mproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmProveedores());
        }

      

        private void SubNegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Mmantenedor, new Frm_Negocio());
        }

        private void Sub_RCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Mreportes, new Frm_ReporteCompra());
        }

        private void Sub_RVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Mreportes, new Frm_ReporteVentas());
            
        }

        private void Macercade_Click(object sender, EventArgs e)
        {
            MdAcercade md = new MdAcercade();
            md.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea salir ?","Mensaje",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }



        private void MuDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MuDashboard, new frm_Dashboard());

        }

        public void abrirDashborad()
        {
            AbrirFormulario(MuDashboard, new frm_Dashboard());
        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconRestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void iconRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Normal;
            iconRestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MenuTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012,0);
        }
    }
}
