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
    public partial class MdProveedor : Form
    {
        public  Proveedor _Proveedor { get; set; }

        public MdProveedor()
        {
            InitializeComponent();
        }

        private void MdProveedor_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in Dtg_MDP.Columns)
            {
                if (columna.Visible == true )
                {
                    cbx_Buscar.Items.Add(new OpCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbx_Buscar.DisplayMember = "Texto";
            cbx_Buscar.ValueMember = "Valor";
            cbx_Buscar.SelectedIndex = 0;


            List<Proveedor> lista = new N_Proveedor().Listar();

            foreach (Proveedor item in lista)
            {
                Dtg_MDP.Rows.Add(new object[] {"",item.Documento,item.RazonSocial});

            }
        }

        private void Dtg_MDP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if(iRow >= 0 && iColum > 0) {
                _Proveedor = new Proveedor()
                {
                    Documento = (Dtg_MDP.Rows[iRow].Cells["Documento"].Value.ToString()),
                    RazonSocial = (Dtg_MDP.Rows[iRow].Cells["R_Social"].Value.ToString())

                };

                this.DialogResult = DialogResult.OK;
                this.Close();


            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string ColumnaFiltro = ((OpCombo)cbx_Buscar.SelectedItem).Valor.ToString();

            if (Dtg_MDP.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Dtg_MDP.Rows)
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
            foreach (DataGridViewRow row in Dtg_MDP.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
