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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            cbxEstado.Items.Add(new OpCombo() { Valor = 1, Texto = "Activo" });
            cbxEstado.Items.Add(new OpCombo() { Valor = 0, Texto = "No Activo" });
            cbxEstado.DisplayMember = "Texto";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.SelectedIndex = 0;

           

            foreach (DataGridViewColumn columna in Dtg_Cliente.Columns)
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
            List<Cliente> listaCliente = new N_Cliente().Listar();

            foreach (Cliente item in listaCliente)
            {
                Dtg_Cliente.Rows.Add(new object[] {"",item.Documento,item.Primer_Nombre,item.Primer_Apellido,item.Correo,item.Telefono,
                    
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"


                });

            }
        }

       
            private void btn_Guardar_Click(object sender, EventArgs e)
            {

                string mensaje = string.Empty;

                // Validar campos
                if (string.IsNullOrWhiteSpace(Txt_Documento.Text) ||
                    string.IsNullOrWhiteSpace(txt_PNombre.Text) ||
                    string.IsNullOrWhiteSpace(txt_PApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(txt_Telofono.Text) ||
                    cbxEstado.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear objeto Cliente con los datos del formulario
                Cliente objCliente = new Cliente()
                {
                    Documento = Txt_Documento.Text.Trim(), // Trim para eliminar espacios innecesarios
                    Primer_Nombre = txt_PNombre.Text.Trim(),
                    Primer_Apellido = txt_PApellido.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Telefono = txt_Telofono.Text.Trim(),
                    Estado = Convert.ToInt32(((OpCombo)cbxEstado.SelectedItem).Valor) == 1
                };

                // Registrar el cliente
                int clienteGenerado = new N_Cliente().Registrar(objCliente, out mensaje);

                // Verificar el resultado del registro
                if (clienteGenerado != 0)
                {
                    // Agregar cliente al DataGridView
                    Dtg_Cliente.Rows.Add(new object[]
                    {
                         " ",  // Valor por defecto o vacío
                         clienteGenerado,
                         txt_PNombre.Text.Trim(),
                         txt_PApellido.Text.Trim(),
                         txtCorreo.Text.Trim(),
                         txt_Telofono.Text.Trim(),
                         ((OpCombo)cbxEstado.SelectedItem).Valor.ToString(), // Asumiendo que quieres mostrar el valor
                         ((OpCombo)cbxEstado.SelectedItem).Texto.ToString() // Asumiendo que quieres mostrar el texto
                    });

                    // Limpiar campos del formulario
                    Limpiar();
                    MessageBox.Show(mensaje, "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.None);

                }
                else
                {
                    // Mostrar mensaje de error
                    MessageBox.Show(mensaje, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }


        

        private void ActualizarDataGridView()
        {
            Dtg_Cliente.Rows.Clear(); // Limpiar el DataGridView antes de actualizar

            // Suponiendo que tienes un método para obtener todos los clientes
            List<Cliente> clientes = new N_Cliente().Listar(); // Asegúrate de tener este método

            foreach (var cliente in clientes)
            {
                Dtg_Cliente.Rows.Add(new object[]
                {
            " ",  // Valor por defecto o vacío
            cliente.Documento,
            cliente.Primer_Nombre,
            cliente.Primer_Apellido,
            cliente.Correo,
            cliente.Telefono,
            cliente.Estado
                });
            }
        }



        private void Limpiar()
        {
            txt_Indice.Text = "1";
            //txt_Id.Text = "0";
            Txt_Documento.Text = "";
            txt_PNombre.Text = "";
            txt_PApellido.Text = "";
            txtCorreo.Text = "";
            txt_Telofono.Text = "";
            cbxEstado.SelectedIndex = 0;


            Txt_Documento.Select();
        }

        private void Dtg_Cliente_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void Dtg_Cliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dtg_Cliente.Columns[e.ColumnIndex].Name == "Btn_Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txt_Indice.Text = indice.ToString();
                    Txt_Documento.Text = Dtg_Cliente.Rows[indice].Cells["Documento"].Value.ToString();
                    txt_PNombre.Text = Dtg_Cliente.Rows[indice].Cells["P_Nombre"].Value.ToString();
                    txt_PApellido.Text = Dtg_Cliente.Rows[indice].Cells["P_Apellido"].Value.ToString();
                    txtCorreo.Text = Dtg_Cliente.Rows[indice].Cells["Correo"].Value.ToString();
                    txt_Telofono.Text = Dtg_Cliente.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (OpCombo oc in cbxEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(Dtg_Cliente.Rows[indice].Cells["EstadoValor"].Value))
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

            if (Dtg_Cliente.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Dtg_Cliente.Rows)
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
            foreach (DataGridViewRow row in Dtg_Cliente.Rows)
            {
                row.Visible = true;
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(Txt_Documento.Text) != 0)
            {
                if (MessageBox.Show("Desea Eliminar el cliente", "Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Cliente obj = new Cliente()
                    {
                        Documento = Txt_Documento.Text
                    };

                    bool respuesta = new N_Cliente().ELiminar(obj, out mensaje);

                    if (respuesta)
                    {
                        Dtg_Cliente.Rows.RemoveAt(Convert.ToInt32(txt_Indice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

       
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            
                string Mensaje = string.Empty;

                if (!string.IsNullOrEmpty(txt_Indice.Text)) // Verificamos que el índice esté proporcionado
                {
                    int indice;
                    if (int.TryParse(txt_Indice.Text, out indice))
                    {
                        Cliente objcliente = new Cliente()
                        {
                            Documento = Txt_Documento.Text,
                            Primer_Nombre = txt_PNombre.Text,
                            Primer_Apellido = txt_PApellido.Text,
                            Correo = txtCorreo.Text,
                            Telefono = txt_Telofono.Text,
                            Estado = Convert.ToInt32(((OpCombo)cbxEstado.SelectedItem).Valor) == 1 ? true : false
                        };

                        bool resultado = new N_Cliente().Editar(objcliente, out Mensaje);

                        if (resultado)
                        {
                            DataGridViewRow row = Dtg_Cliente.Rows[indice];
                            row.Cells["Documento"].Value = Txt_Documento.Text;
                            row.Cells["P_Nombre"].Value = txt_PNombre.Text;
                            row.Cells["P_Apellido"].Value = txt_PApellido.Text;
                            row.Cells["Correo"].Value = txtCorreo.Text;
                            row.Cells["Telefono"].Value = txt_Telofono.Text;
                            row.Cells["EstadoValor"].Value = ((OpCombo)cbxEstado.SelectedItem).Valor.ToString();
                            row.Cells["Estado"].Value = ((OpCombo)cbxEstado.SelectedItem).Texto.ToString();

                            Limpiar();
                            MessageBox.Show("Cliente editado con éxito.");
                        }
                        else
                        {
                            MessageBox.Show(Mensaje);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El índice proporcionado no es válido. Asegúrate de que es un número entero.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un cliente para editar.");
                }
            


        }
    }
}

