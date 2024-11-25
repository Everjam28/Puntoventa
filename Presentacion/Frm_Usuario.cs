using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion;
using Negocio;
using Entidad;

using Presentacion.Utilidades;
using System.Drawing.Text;
using System.Windows.Documents;
using iTextSharp.text.pdf.codec.wmf;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;

namespace Presentacion
{
    public partial class Frm_Usuario : Form
    {
        public Frm_Usuario()
        {
            InitializeComponent();
        }

        private void Frm_Usuario_Load(object sender, EventArgs e)
        {
            cbxEstado.Items.Add(new OpCombo() { Valor = 1, Texto = "Activo" });
             cbxEstado.Items.Add(new OpCombo() { Valor = 0, Texto = "No Activo" });
            cbxEstado.DisplayMember = "Texto";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.SelectedIndex = 0;

            List<Rol> listaRol = new N_Rol().Listar();

            foreach (Rol item in listaRol)
            {
                cbxRol.Items.Add(new OpCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cbxRol.DisplayMember = "Texto";
            cbxRol.ValueMember = "Valor";
            cbxRol.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in Dtg_Usuarios.Columns)
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
            List<Usuario> listaUsuario = new N_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                Dtg_Usuarios.Rows.Add(new object[] {"",item.Documento,item.PrimerNombre,item.PrimerApellido,item.Correo,item.Clave,
                    item.oRol.IdRol,
                    item.oRol.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"


                });

            }





        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {


            string Mensaje = string.Empty;

            // Validar campos
            if (string.IsNullOrWhiteSpace(Txt_Documento.Text) ||
                string.IsNullOrWhiteSpace(txt_PNombre.Text) ||
                string.IsNullOrWhiteSpace(txt_PApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txt_Clave.Text) ||
                cbxRol.SelectedItem == null ||
                cbxEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto Usuario con los datos del formulario
            Usuario objusuario = new Usuario()
            {
                Documento = Txt_Documento.Text.Trim(), // Trim para eliminar espacios innecesarios
                PrimerNombre = txt_PNombre.Text.Trim(),
                PrimerApellido = txt_PApellido.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Clave = txt_Clave.Text.Trim(),
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpCombo)cbxRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpCombo)cbxEstado.SelectedItem).Valor) == 1
            };

            // Registrar el usuario
            int usuariogenerado = new N_Usuario().Registrar(objusuario, out Mensaje);

            // Verificar el resultado del registro
            if (usuariogenerado != 0)
            {
                // Agregar usuario al DataGridView
                Dtg_Usuarios.Rows.Add(new object[]
                {
                    " ",  // Asumiendo que este es un valor por defecto o vacío
                    usuariogenerado,
                    txt_PNombre.Text.Trim(),
                    txt_PApellido.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txt_Clave.Text.Trim(),
                    ((OpCombo)cbxRol.SelectedItem).Valor.ToString(),
                    ((OpCombo)cbxRol.SelectedItem).Texto.ToString(),
                    ((OpCombo)cbxEstado.SelectedItem).Valor.ToString(),
                    ((OpCombo)cbxEstado.SelectedItem).Texto.ToString()
                });

                // Limpiar campos del formulario
                Limpiar();
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show(Mensaje, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btn_Editar_Click_1(object sender, EventArgs e)
        {

            string Mensaje = string.Empty;
            Usuario objusuario = new Usuario()
            {

                Documento = Txt_Documento.Text,
                PrimerNombre = txt_PNombre.Text,
                PrimerApellido = txt_PApellido.Text,
                Correo = txtCorreo.Text,
                Clave = txt_Clave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpCombo)cbxRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpCombo)cbxEstado.SelectedItem).Valor) == 1 ? true : false
            };


            if (!string.IsNullOrEmpty(objusuario.Documento))
            {
                bool resultado = new N_Usuario().Editar(objusuario, out Mensaje);

                


                // Actualiza los valores en la fila del DataGridView
                DataGridViewRow row = Dtg_Usuarios.Rows[Convert.ToInt32(txt_Indice.Text)];
                row.Cells["Documento"].Value = Txt_Documento.Text;
                row.Cells["P_Nombre"].Value = txt_PNombre.Text;
                row.Cells["P_Apellido"].Value = txt_PApellido.Text;
                row.Cells["Correo"].Value = txtCorreo.Text;
                row.Cells["Clave"].Value = txt_Clave.Text;
                row.Cells["IdRol"].Value = ((OpCombo)cbxRol.SelectedItem).Valor.ToString();
                row.Cells["Rol"].Value = ((OpCombo)cbxRol.SelectedItem).Texto.ToString();
                row.Cells["EstadoValor"].Value = ((OpCombo)cbxEstado.SelectedItem).Valor.ToString();
                row.Cells["Estado"].Value = ((OpCombo)cbxEstado.SelectedItem).Texto.ToString();
                Limpiar();
            }
        }




        private void Limpiar()
        {
            txt_Indice.Text = "0";
            //txt_Id.Text = "0";
            Txt_Documento.Text = "";
            txt_PNombre.Text = "";
            txt_PApellido.Text = "";
            txtCorreo.Text = "";
            txt_Clave.Text = "";
            txt_CClave.Text = "";
            cbxRol.SelectedIndex = 0;
            cbxEstado.SelectedIndex = 0;


            Txt_Documento.Select();
        }

        private void Dtg_Usuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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


        private void Dtg_Usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dtg_Usuarios.Columns[e.ColumnIndex].Name == "Btn_Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txt_Indice.Text = indice.ToString();
                    // txt_Id.Text = Dtg_Usuarios.Rows[indice].Cells["Id"].Value.ToString();
                    Txt_Documento.Text = Dtg_Usuarios.Rows[indice].Cells["Documento"].Value.ToString();
                    txt_PNombre.Text = Dtg_Usuarios.Rows[indice].Cells["P_Nombre"].Value.ToString();
                    txt_PApellido.Text = Dtg_Usuarios.Rows[indice].Cells["P_Apellido"].Value.ToString();
                    txtCorreo.Text = Dtg_Usuarios.Rows[indice].Cells["Correo"].Value.ToString();
                    txt_Clave.Text = Dtg_Usuarios.Rows[indice].Cells["Clave"].Value.ToString();
                    txt_CClave.Text = Dtg_Usuarios.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (OpCombo oc in cbxRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(Dtg_Usuarios.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = cbxRol.Items.IndexOf(oc);
                            cbxRol.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpCombo oc in cbxEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(Dtg_Usuarios.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cbxEstado.Items.IndexOf(oc);
                            cbxEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                }
            }

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Txt_Documento.Text))
            {
                if (MessageBox.Show("¿Desea eliminar el usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuario objusuario = new Usuario()
                    {
                        Documento = Txt_Documento.Text
                    };
                    bool respuesta = new N_Usuario().Eliminar(objusuario, out mensaje);

                    if (int.TryParse(txt_Indice.Text, out int indice) && indice >= 0 && indice < Dtg_Usuarios.Rows.Count)
                    {
                        Dtg_Usuarios.Rows.RemoveAt(indice);
                    }

                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un documento válido.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string ColumnaFiltro = ((OpCombo)cbx_Buscar.SelectedItem).Valor.ToString();

            if (Dtg_Usuarios.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Dtg_Usuarios.Rows)
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
            foreach (DataGridViewRow row in Dtg_Usuarios.Rows)
            {
                row.Visible = true;
            }
        }

    }
}
