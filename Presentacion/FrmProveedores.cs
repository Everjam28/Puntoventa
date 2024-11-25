using Entidad;
using Negocio;
using Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            cbxEstado.Items.Add(new OpCombo() { Valor = 1, Texto = "Activo" });
            cbxEstado.Items.Add(new OpCombo() { Valor = 0, Texto = "No Activo" });
            cbxEstado.DisplayMember = "Texto";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.SelectedIndex = 0;



            foreach (DataGridViewColumn columna in Dtg_Proveedores.Columns)
            {
                if (columna.Visible == true & columna.Name != "Btn_Seleccionar")
                {
                    cbx_Buscar.Items.Add(new OpCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbx_Buscar.DisplayMember = "Texto";
            cbx_Buscar.ValueMember = "Valor";
            cbx_Buscar.SelectedIndex = 0;


            //Mostrar Todos Los Usuarios
            List<Proveedor> listaCliente = new N_Proveedor().Listar();

            foreach (Proveedor item in listaCliente)
            {
                Dtg_Proveedores.Rows.Add(new object[] {"",item.Documento,item.RazonSocial,item.Correo,item.Telefono,

                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"


                });

            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Proveedor obj = new Proveedor()
            {

                Documento = Txt_Documento.Text,
                RazonSocial = txt_RazonSocial.Text,
                Correo = txtCorreo.Text,
                Telefono = txt_Telofono.Text,

                Estado = Convert.ToInt32(((OpCombo)cbxEstado.SelectedItem).Valor) == 1 ? true : false
            };



            int clientegenerado = new N_Proveedor().Registrar(obj, out Mensaje);



            if (clientegenerado != 0)
            {
                Dtg_Proveedores.Rows.Add(new object[] {" ",clientegenerado,Txt_Documento.Text,txt_RazonSocial.Text,txtCorreo.Text,txt_Telofono.Text,

                    ((OpCombo)cbxEstado.SelectedItem).Valor.ToString(),
                    ((OpCombo)cbxEstado.SelectedItem).Texto.ToString(),



                   });

                    Limpiar();


            }
            else
            {
                MessageBox.Show(Mensaje);
            }

            if (!string.IsNullOrEmpty(obj.Documento))

            {

                bool resultado = new N_Proveedor().Editar(obj, out Mensaje);

                if (resultado)
                {


                    DataGridViewRow row = Dtg_Proveedores.Rows[Convert.ToInt32(txt_Indice.Text)];
                    row.Cells["Documento"].Value = Txt_Documento.Text;
                    row.Cells["RazonS"].Value = txt_RazonSocial.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Telefono"].Value = txtCorreo.Text;
                    row.Cells["EstadoValor"].Value = ((OpCombo)cbxEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpCombo)cbxEstado.SelectedItem).Texto.ToString();

                    Limpiar();

                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
                Limpiar();


            }

            Limpiar();

        }

        private void Limpiar()
        {
            txt_Indice.Text = "1";
            //txt_Id.Text = "0";
            Txt_Documento.Text = "";
            txt_RazonSocial.Text = "";
            txtCorreo.Text = "";
            txt_Telofono.Text = "";
            cbxEstado.SelectedIndex = 0;


            Txt_Documento.Select();
        }

        private void Dtg_Proveedores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.Check1.Width;
                var h = Properties.Resources.Check1.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.Check1, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void Dtg_Proveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dtg_Proveedores.Columns[e.ColumnIndex].Name == "Btn_Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txt_Indice.Text = indice.ToString();
                    Txt_Documento.Text = Dtg_Proveedores.Rows[indice].Cells["Documento"].Value.ToString();
                    txt_RazonSocial.Text = Dtg_Proveedores.Rows[indice].Cells["RazonS"].Value.ToString();
                    txtCorreo.Text = Dtg_Proveedores.Rows[indice].Cells["Correo"].Value.ToString();
                    txt_Telofono.Text = Dtg_Proveedores.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (OpCombo oc in cbxEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(Dtg_Proveedores.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cbxEstado.Items.IndexOf(oc);
                            cbxEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                }
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string ColumnaFiltro = ((OpCombo)cbx_Buscar.SelectedItem).Valor.ToString();

            if (Dtg_Proveedores.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Dtg_Proveedores.Rows)
                {
                    if (row.Cells[ColumnaFiltro].Value.ToString().Trim().ToUpper().Contains(txt_Buscar.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void Btn_LimpiarBuscar_Click(object sender, EventArgs e)
        {
            txt_Buscar.Text = " ";
            foreach (DataGridViewRow row in Dtg_Proveedores.Rows)
            {
                row.Visible = true;
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Txt_Documento.Text) != 0)
            {
                if (MessageBox.Show("Desea Eliminar el Proveedor", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Proveedor obj = new Proveedor()
                    {
                        Documento = Txt_Documento.Text
                    };

                    bool respuesta = new N_Proveedor().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        Dtg_Proveedores.Rows.RemoveAt(Convert.ToInt32(txt_Indice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}

