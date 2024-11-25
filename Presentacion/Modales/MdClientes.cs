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
using Entidad;
using Negocio;


namespace Presentacion.Modales
{
    public partial class MdClientes : Form
    {
        public Cliente _cliente { get; set; }
        public MdClientes()
        {
            InitializeComponent();
        }

        private void MdClientes_Load(object sender, EventArgs e)
        {
            foreach(DataGridViewColumn columna in Dtg_Cliente.Columns)
            {
                if (columna.Visible == true)
                    cbx_Buscar.Items.Add(new OpCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }

            cbx_Buscar.DisplayMember = "Texto";
            cbx_Buscar.ValueMember = "Valor";
            cbx_Buscar.SelectedIndex = 0;

            List<Cliente> lista = new N_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                if (item.Estado)
                    Dtg_Cliente.Rows.Add(new object[] { item.Documento, item.Primer_Nombre, item.Primer_Apellido });
            }

        }

        private void Dtg_Cliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0){
                _cliente = new Cliente()
                {
                    Documento = Dtg_Cliente.Rows[iRow].Cells["Documento"].Value.ToString(),
                    Primer_Nombre = Dtg_Cliente.Rows[iRow].Cells["P_Nombre"].Value.ToString(),
                    Primer_Apellido = Dtg_Cliente.Rows[iRow].Cells["P_Apellido"].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
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
    }
}
