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
    public partial class Frm_ReporteCompra : Form
    {
        public Frm_ReporteCompra()
        {
            InitializeComponent();
        }

        private void Frm_ReporteCompra_Load(object sender, EventArgs e)
        {
            List<Proveedor> lista = new N_Proveedor().Listar();
            

            // Configurar DisplayMember y ValueMember antes de agregar elementos
            cbx_Proveedor.DisplayMember = "Texto";
            cbx_Proveedor.ValueMember = "Valor";

            // Agregar la opción "Todos"
            cbx_Proveedor.Items.Add(new OpCombo() { Valor = 0, Texto = "Todos" });

            // Agregar los proveedores al ComboBox
            foreach (Proveedor item in lista)
            {
                cbx_Proveedor.Items.Add(new OpCombo() { Valor = item.Documento, Texto = item.RazonSocial });
            }

            // Seleccionar el primer elemento por defecto
            cbx_Proveedor.SelectedIndex = 0;


            foreach ( DataGridViewColumn columna in dtg_Reporte.Columns)
            {
                cbx_Buscar.Items.Add(new OpCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cbx_Buscar.DisplayMember = "Texto";
            cbx_Buscar.ValueMember = "Valor";
            cbx_Buscar.SelectedIndex = 0;
        }

        private void btn_BuscarP_Click(object sender, EventArgs e)
        {

                // Obtener el ID del proveedor seleccionado
                int idproveedor = Convert.ToInt32(((OpCombo)cbx_Proveedor.SelectedItem).Valor);

                // Llamar al método de la capa de negocio para obtener los resultados
                List<ReporteCompra> lista = new N_Reporte().compra(
                    txt_FechaInicio.Value.ToString("dd/MM/yyyy"), // Asegurarse de usar el formato correcto
                    txt_fechaFin.Value.ToString("dd/MM/yyyy"), // Asegurarse de usar el formato correcto
                    idproveedor
                );

                // Limpiar el DataGridView antes de agregar nuevos datos
                dtg_Reporte.Rows.Clear();

                // Agregar los resultados al DataGridView
                foreach (ReporteCompra rc in lista)
                {
                    dtg_Reporte.Rows.Add(new object[]
                    {
                        rc.FechaRegistro,
                        rc.TipoDocumento,
                        rc.NumeroDocumento,
                        rc.MontoTotal,
                        rc.UsuarioRegistro,
                        rc.DocumentoProveedor,
                        rc.RazonSocial,
                        rc.CodigoProducto,
                        rc.NombreProducto,
                        rc.Categoria,
                        rc.PrecioCompra,
                        rc.PrecioVenta,
                        rc.Cantidad,
                        rc.SubTotal,
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
