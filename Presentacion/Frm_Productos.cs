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
    public partial class Frm_Productos : Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            cbxEstado.Items.Add(new OpCombo() { Valor = 1, Texto = "Activo" });
            cbxEstado.Items.Add(new OpCombo() { Valor = 0, Texto = "No Activo" });
            cbxEstado.DisplayMember = "Texto";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.SelectedIndex = 0;

            List<Categoria> listaCategoria = new N_Categorias().Listar();

            foreach (Categoria item in listaCategoria)
            {
                cbxCategoria.Items.Add(new OpCombo() { Valor = item.Idcategoria, Texto = item.Descripcion });
            }
            cbxCategoria.DisplayMember = "Texto";
            cbxCategoria.ValueMember = "Valor";
            cbxCategoria.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in Dtg_Productos.Columns)
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
            List<Producto> listaProductos = new N_Producto().Listar();

            foreach (Producto item in listaProductos)
            {
                Dtg_Productos.Rows.Add(new object[] { 
                    "",
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion,
                    item.oCategoria.Idcategoria,
                    item.oCategoria.Descripcion,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"

                 

               });

            }

        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            // Convertir el valor de txt_Idcategoria.Text a int
            if (!int.TryParse(Txt_IdProducto.Text, out int idProducto))
            {
                MessageBox.Show("El ID del Producto no es válido.");
                return;
            }

            Producto objPro = new Producto()
            {
                IdProducto = idProducto, // Asignar el valor convertido a int
                Codigo = Txt_Codigo.Text,
                Nombre = Txt_Nombre.Text,
                Descripcion = txt_Descripcion.Text,
                oCategoria = new Categoria() { Idcategoria = Convert.ToInt32(((OpCombo)cbxCategoria.SelectedItem).Valor)},
                Estado = Convert.ToInt32(((OpCombo)cbxEstado.SelectedItem).Valor) == 1 ? true : false
            };

            // Verificar si el ID de categoría es cero para determinar si se está insertando o editando

            // Insertar un nuevo registro
            int usuariogenerado = new N_Producto().Registrar(objPro, out Mensaje);

            if (usuariogenerado != 0)
            {
                Dtg_Productos.Rows.Add(new object[] {" ", usuariogenerado, idProducto,Txt_Codigo.Text,Txt_Nombre.Text, txt_Descripcion.Text,
                        ((OpCombo)cbxCategoria.SelectedItem).Valor.ToString(),
                        ((OpCombo)cbxCategoria.SelectedItem).Texto.ToString(),
                        "0",
                        "0.00",
                        "0.00",
                        ((OpCombo)cbxEstado.SelectedItem).Valor.ToString(),
                        ((OpCombo)cbxEstado.SelectedItem).Texto.ToString(),


                    });

                Limpiar();
            }
            else
            {
                MessageBox.Show(Mensaje);
            }
        }


        private void Limpiar()
        {
            txt_Indice.Text = "0";
            //txt_Id.Text = "0";
            Txt_IdProducto.Text = "";
            Txt_Codigo.Text = "";
            Txt_Nombre.Text = "";
            txt_Descripcion.Text = "";
            cbxCategoria.SelectedIndex = 0;
            cbxEstado.SelectedIndex = 0;


            Txt_Codigo.Select();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles de la interfaz de usuario
            int idproducto;
            if (!int.TryParse(Txt_IdProducto.Text, out idproducto))
            {
                MessageBox.Show("El ID de categoría no es válido.");
                return;
            }
            
            
            string nombre = Txt_Nombre.Text;
            string descripcion = txt_Descripcion.Text;
          
            string codigo = Txt_Codigo.Text;
            int idcategoria = Convert.ToInt32(((OpCombo)cbxCategoria.SelectedItem).Valor);
            int estado = Convert.ToInt32(((OpCombo)cbxEstado.SelectedItem).Valor);

            // Llamar al método de edición de categoría en la capa de negocio
            string mensaje;
            bool exito = new N_Producto().ModificarProducto(idproducto, codigo, nombre, descripcion, idcategoria, estado, out mensaje);

            // Mostrar el resultado de la operación
            if (exito)
            {
                // Actualizar la fila correspondiente en el DataGridView con los nuevos datos
                DataGridViewRow row = Dtg_Productos.Rows[Convert.ToInt32(txt_Indice.Text)];
                row.Cells["IdProducto"].Value = idproducto.ToString();
                row.Cells["Codigo"].Value = codigo;
                row.Cells["Nombre"].Value = nombre;
                row.Cells["Descripcion"].Value = descripcion;
                row.Cells["IdCategoria"].Value = ((OpCombo)cbxCategoria.SelectedItem).Texto.ToString();

                row.Cells["EstadoValor"].Value = ((OpCombo)cbxEstado.SelectedItem).Valor.ToString();
                row.Cells["Estado"].Value = ((OpCombo)cbxEstado.SelectedItem).Texto.ToString();

                //row.Cells["EstadoValor"].Value = estado.ToString();
                //row.Cells["Estado"].Value = ((OpCombo)cbxEstado.SelectedItem).Texto.ToString();

                Limpiar(); // Limpiar los campos después de la edición exitosa
            }
            else
            {
                MessageBox.Show(mensaje, "Error al editar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Dtg_Productos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void Dtg_Productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dtg_Productos.Columns[e.ColumnIndex].Name == "Btn_Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {

                    txt_Indice.Text = indice.ToString();
                    Txt_IdProducto.Text = Dtg_Productos.Rows[indice].Cells["IdProducto"].Value.ToString();
                    Txt_Codigo.Text = Dtg_Productos.Rows[indice].Cells["Codigo"].Value.ToString();
                    Txt_Nombre.Text = Dtg_Productos.Rows[indice].Cells["Nombre"].Value.ToString();
                    txt_Descripcion.Text = Dtg_Productos.Rows[indice].Cells["Descripcion"].Value.ToString();


                    foreach (OpCombo oc in cbxCategoria.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(Dtg_Productos.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            int indice_combo = cbxCategoria.Items.IndexOf(oc);
                            cbxCategoria.SelectedIndex = indice_combo;
                            break;
                        }
                    }


                    foreach (OpCombo oc in cbxEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(Dtg_Productos.Rows[indice].Cells["EstadoValor"].Value))
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
            if (Convert.ToInt32(Txt_IdProducto.Text) != 0)
            {
                if (MessageBox.Show("Desea eliminar Producto", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Producto obj = new Producto()
                    {

                        IdProducto = Convert.ToInt32(Txt_IdProducto.Text)

                    };
                    bool respuesta = new N_Producto().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        Dtg_Productos.Rows.RemoveAt(Convert.ToInt32(txt_Indice.Text));
                        Limpiar();

                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string ColumnaFiltro = ((OpCombo)cbx_Buscar.SelectedItem).Valor.ToString();

            if (Dtg_Productos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Dtg_Productos.Rows)
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
            foreach (DataGridViewRow row in Dtg_Productos.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
