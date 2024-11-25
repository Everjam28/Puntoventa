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
    public partial class Frm_ReporteVentas : Form
    {
        public Frm_ReporteVentas()
        {
            InitializeComponent();
        }

        private void Frm_ReporteVentas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dtg_Reporte.Columns)
            {
                cbx_Buscar.Items.Add(new OpCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cbx_Buscar.DisplayMember = "Texto";
            cbx_Buscar.ValueMember = "Valor";
            cbx_Buscar.SelectedIndex = 0;
        }

        private void btn_BuscarP_Click(object sender, EventArgs e)
        {
            List<ReporteVenta> lista = new N_Reporte().venta(
                    txt_FechaInicio.Value.ToString("dd/MM/yyyy"), // Asegurarse de usar el formato correcto
                    txt_fechaFin.Value.ToString("dd/MM/yyyy") // Asegurarse de usar el formato correcto
              
                );

            dtg_Reporte.Rows.Clear();

            foreach ( ReporteVenta rv in lista )
            {
                dtg_Reporte.Rows.Add(new object[]
                {
                        rv.FechaRegistro,
                        rv.TipoDocumento,
                        rv.NumeroDocumento,
                        rv.MontoTotal,
                        rv.UsuarioRegistro,
                        rv.DocumentoCliente,
                        rv.NombreCliente,
                        rv.CodigoProducto,
                        rv.NombreProducto,
                        rv.Categoria,
                        rv.PrecioVenta,
                        rv.Cantidad,
                        rv.SubTotal,





                });
            }
                    
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string ColumnaFiltro = ((OpCombo)cbx_Buscar.SelectedItem).Valor.ToString();

            if (dtg_Reporte.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtg_Reporte.Rows)
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
            foreach (DataGridViewRow row in dtg_Reporte.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
