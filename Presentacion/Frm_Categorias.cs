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
    public partial class Frm_Categorias : Form
    {
        public Frm_Categorias()
        {
            InitializeComponent();
        }

        private void Frm_Categorias_Load(object sender, EventArgs e)
        {
            cbxEstado.Items.Add(new OpCombo() { Valor = 1, Texto = "Activo" });
            cbxEstado.Items.Add(new OpCombo() { Valor = 0, Texto = "No Activo" });
            cbxEstado.DisplayMember = "Texto";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dtg_categoria.Columns)
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
            List<Categoria> listacategoria = new N_Categorias().Listar();

            foreach (Categoria item in listacategoria)
            {
                dtg_categoria.Rows.Add(new object[] {"",item.Idcategoria,
                    item.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"


                });

            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            // Convertir el valor de txt_Idcategoria.Text a int
            if (!int.TryParse(txt_Idcategoria.Text, out int idCategoria))
            {
                MessageBox.Show("El ID de categoría no es válido.");
                return;
            }

            Categoria objusuario = new Categoria()
            {
                Idcategoria = idCategoria, // Asignar el valor convertido a int
                Descripcion = Txt_Descripcion.Text,
                Estado = Convert.ToInt32(((OpCombo)cbxEstado.SelectedItem).Valor) == 1 ? true : false
            };

            // Verificar si el ID de categoría es cero para determinar si se está insertando o editando

            // Insertar un nuevo registro
            int usuariogenerado = new N_Categorias().Registrar(objusuario, out Mensaje);

            if (usuariogenerado != 0)
            {
                dtg_categoria.Rows.Add(new object[] {" ", usuariogenerado, idCategoria, Txt_Descripcion.Text,
                        ((OpCombo)cbxEstado.SelectedItem).Valor.ToString(),
                        ((OpCombo)cbxEstado.SelectedItem).Texto.ToString()
                    });

                Limpiar();
            }
            else
            {
                MessageBox.Show(Mensaje);
            }

            // Editar un registro existente

        }




        private void Limpiar()
        {
            txt_Indice.Text = "0";
            //txt_Id.Text = "0";
            txt_Idcategoria.Text = "";
            Txt_Descripcion.Text = "";
            cbxEstado.SelectedIndex = 0;


            Txt_Descripcion.Select();
        }

        private void dtg_categoria_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dtg_categoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtg_categoria.Columns[e.ColumnIndex].Name == "Btn_Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {

                    txt_Indice.Text = indice.ToString();
                    txt_Idcategoria.Text = dtg_categoria.Rows[indice].Cells["IdCategoria"].Value.ToString();
                    Txt_Descripcion.Text = dtg_categoria.Rows[indice].Cells["Descripcion"].Value.ToString();


                    foreach (OpCombo oc in cbxEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dtg_categoria.Rows[indice].Cells["EstadoValor"].Value))
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
            if (Convert.ToInt32(txt_Idcategoria.Text) != 0)
            {
                if (MessageBox.Show("Desea eliminar la categoria", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Categoria obj = new Categoria()
                    {

                        Idcategoria = Convert.ToInt32(txt_Idcategoria.Text)

                    };
                    bool respuesta = new N_Categorias().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dtg_categoria.Rows.RemoveAt(Convert.ToInt32(txt_Indice.Text));
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

           



        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string ColumnaFiltro = ((OpCombo)cbx_Buscar.SelectedItem).Valor.ToString();

            if (dtg_categoria.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtg_categoria.Rows)
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
            foreach (DataGridViewRow row in dtg_categoria.Rows)
            {
                row.Visible = true;
            }
        }

        private void btn_Editar_Click_1(object sender, EventArgs e)
        {
            // Obtener los valores de los controles de la interfaz de usuario
            int idCategoria;
            if (!int.TryParse(txt_Idcategoria.Text, out idCategoria))
            {
                MessageBox.Show("El ID de categoría no es válido.");
                return;
            }

            string descripcion = Txt_Descripcion.Text;
            int estado = Convert.ToInt32(((OpCombo)cbxEstado.SelectedItem).Valor);

            // Llamar al método de edición de categoría en la capa de negocio
            string mensaje;
            bool exito = new N_Categorias().EditarCategoria(idCategoria, descripcion, estado, out mensaje);

            // Mostrar el resultado de la operación
            if (exito)
            {
                // Actualizar la fila correspondiente en el DataGridView con los nuevos datos
                DataGridViewRow row = dtg_categoria.Rows[Convert.ToInt32(txt_Indice.Text)];
                row.Cells["Idcategoria"].Value = idCategoria.ToString();
                row.Cells["Descripcion"].Value = descripcion;
                row.Cells["EstadoValor"].Value = estado.ToString();
                row.Cells["Estado"].Value = ((OpCombo)cbxEstado.SelectedItem).Texto.ToString();

                Limpiar(); // Limpiar los campos después de la edición exitosa
            }
            else
            {
                MessageBox.Show(mensaje, "Error al editar categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
