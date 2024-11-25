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

namespace Presentacion.Modales
{
    public partial class MdProducto : Form
    {
        public Producto _Producto { get; set; }
        public MdProducto()
        {
            InitializeComponent();
        }

        private void MdProducto_Load(object sender, EventArgs e)
        {

            foreach (DataGridViewColumn columna in Dtg_MdProductos.Columns)
            {
                if (columna.Visible == true) {
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
                Dtg_MdProductos.Rows.Add(new object[] {item.IdProducto,item.Codigo,item.Nombre,item.oCategoria.Descripcion,item.Stock,item.PrecioCompra,item.PrecioVenta,








               });

            }

        }

        private void Dtg_Productos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                _Producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(Dtg_MdProductos.Rows[iRow].Cells["IdProducto"].Value.ToString()),
                    Codigo = (Dtg_MdProductos.Rows[iRow].Cells["Codigo"].Value.ToString()),
                    Nombre = (Dtg_MdProductos.Rows[iRow].Cells["Nombre"].Value.ToString()),
                    Stock = Convert.ToInt32(Dtg_MdProductos.Rows[iRow].Cells["Stock"].Value.ToString()),
                    PrecioCompra = Convert.ToDecimal(Dtg_MdProductos.Rows[iRow].Cells["PrecioCompra"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(Dtg_MdProductos.Rows[iRow].Cells["PrecioVenta"].Value.ToString())

                };

                this.DialogResult = DialogResult.OK;
                this.Close();


            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {

            string ColumnaFiltro = ((OpCombo)cbx_Buscar.SelectedItem).Valor.ToString();

            if (Dtg_MdProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Dtg_MdProductos.Rows)
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
            foreach (DataGridViewRow row in Dtg_MdProductos.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
