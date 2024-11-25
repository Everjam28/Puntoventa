using Entidad;
using Negocio;
using Presentacion.Modales;
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
    public partial class FrmCompras : Form
    {
        private Usuario _Usuario;
        public FrmCompras(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            cbx_TipDocu.Items.Add(new OpCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbx_TipDocu.Items.Add(new OpCombo() { Valor = "Factura", Texto = "Factura" });
            cbx_TipDocu.DisplayMember = "Texto";
            cbx_TipDocu.ValueMember = "Valor";
            cbx_TipDocu.SelectedIndex = 0;

            txt_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txt_idP.Text = "0";
        }

        private void btn_BuscarP_Click(object sender, EventArgs e)
        {
            using (var modal = new MdProveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txt_documenP.Text = modal._Proveedor.Documento;
                    txt_RazonP.Text = modal._Proveedor.RazonSocial;

                }
                else
                {
                    txt_documenP.Select();
                }
            }
        }

        private void Btn_BuscarCp_Click(object sender, EventArgs e)
        {
            using (var modal = new MdProducto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txt_idP.Text = modal._Producto.IdProducto.ToString();
                    txt_CodiP.Text = modal._Producto.Codigo;
                    txt_Producto.Text = modal._Producto.Nombre;
                    txt_precioC.Select();

                }
                else
                {
                    txt_CodiP.Select();
                }
            }
        }

        private void txt_CodiP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new N_Producto().Listar().Where(p => p.Codigo == txt_CodiP.Text && p.Estado == true).FirstOrDefault();

                if (oProducto != null)
                {
                    txt_CodiP.BackColor = Color.Honeydew;
                    txt_idP.Text = oProducto.IdProducto.ToString();
                    txt_Producto.Text = oProducto.Nombre;
                    txt_precioC.Select();
                }
                else
                {
                    txt_CodiP.BackColor = Color.MistyRose;
                    txt_idP.Text = "0";
                    txt_Producto.Text = "";
                }
            }
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            decimal precioventa = 0;
            bool producto_existe = false;

            if (int.Parse(txt_idP.Text) == 0)
            {

                MessageBox.Show("Debe seleccionar un Producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txt_precioC.Text, out preciocompra))
            {

                MessageBox.Show("Precio Compra - Formato moneda incorreto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_precioC.Select();
                return;
            }

            if (!decimal.TryParse(txt_PrecioV.Text, out precioventa))
            {

                MessageBox.Show("Precio Venta - Formato moneda incorreto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_PrecioV.Select();
                return;
            }

            foreach (DataGridViewRow fila in Dtg_Compra.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txt_Producto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                Dtg_Compra.Rows.Add(new object[]{

                    txt_idP.Text,
                    txt_Producto.Text,
                    preciocompra.ToString("00.000"),
                    precioventa.ToString("00.000"),
                    txt_Contador.Value.ToString(),
                    (txt_Contador.Value * preciocompra).ToString("0.000")

                });
                calcularTotal();
                Limpiar();
                txt_CodiP.Select();
            }
        }

        private void Limpiar()
        {
            txt_idP.Text = "0";
            //txt_Id.Text = "0";
            txt_Producto.Text = "";
            txt_CodiP.BackColor = Color.White;
            txt_Producto.Text = "";
            txt_precioC.Text = "";
            txt_PrecioV.Text = "";
            txt_Contador.Value = 1;


        }

        private void calcularTotal()
        {
            decimal Total = 0;
            if (Dtg_Compra.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Dtg_Compra.Rows)
                    Total += Convert.ToDecimal(row.Cells["SubT"].Value.ToString());

            }
            txt_TP.Text = Total.ToString("00.000");
        }

        private void Dtg_Compra_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.eliminar.Width;
                var h = Properties.Resources.eliminar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.eliminar, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void Dtg_Compra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dtg_Compra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dtg_Compra.Columns[e.ColumnIndex].Name == "Btn_Eliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    Dtg_Compra.Rows.RemoveAt(indice);
                    calcularTotal();

                }
            }
        }

        private void txt_precioC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txt_precioC.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == "," || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txt_PrecioV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txt_PrecioV.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == "," || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int documenP;

                // Validación para asegurar que el documento del proveedor sea un número válido
                if (!int.TryParse(txt_documenP.Text, out documenP) || documenP <= 0)
                {
                    MessageBox.Show("Debe seleccionar un proveedor válido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Validación para asegurarse de que haya productos en la compra
                if (Dtg_Compra.Rows.Count < 1)
                {
                    MessageBox.Show("Debe ingresar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Crear la lista de detalles de la compra
                List<Detalle_Compra> detalles = new List<Detalle_Compra>();

                // Llenar la lista con datos del DataGridView
                foreach (DataGridViewRow row in Dtg_Compra.Rows)
                {
                    if (row.IsNewRow) continue; // Para evitar errores con filas vacías

                    // Validar y convertir valores
                    if (row.Cells["IdProducto"].Value == null ||
                        row.Cells["PrecioC"].Value == null ||
                        row.Cells["PrecioV"].Value == null ||
                        row.Cells["Cantidad"].Value == null ||
                        row.Cells["SubT"].Value == null)
                    {
                        MessageBox.Show("Todos los campos de producto deben estar completos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Detalle_Compra detalle = new Detalle_Compra
                    {
                        oProducto = new Producto { IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value) },
                        PrecioCompra = Convert.ToDecimal(row.Cells["PrecioC"].Value),
                        PrecioVenta = Convert.ToDecimal(row.Cells["PrecioV"].Value),
                        Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                        MontoTotal = Convert.ToDecimal(row.Cells["SubT"].Value),
                        FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };

                    detalles.Add(detalle);
                }

                // Obtener el correlativo para el número de documento
                int idcorrelativo = new N_Compra().ObtenerCorrelativo();
                string numerodocumento = string.Format("{0:00000}", idcorrelativo);

                // Crear el objeto Compra
                Compra oCompra = new Compra
                {
                    IdCompra = idcorrelativo,
                    oUsuario = new Usuario { Documento = _Usuario.Documento },
                    oProveedor = new Proveedor { Documento = txt_documenP.Text },
                    TipoDocumento = ((OpCombo)cbx_TipDocu.SelectedItem).Texto,
                    NumeroDocumento = numerodocumento,
                    MontoTotal = Convert.ToDecimal(txt_TP.Text),
                    FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    oDetalleCompra = detalles
                };

                string mensaje;
                bool respuesta = new N_Compra().Registrar(oCompra, out mensaje);

                if (respuesta)
                {
                    var result = MessageBox.Show("Número de Compra generada:\n" + numerodocumento + "\n\n ¿Desea Copiar al portapapeles?",
                                                 "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        Clipboard.SetText(numerodocumento);
                    }

                    // Limpiar el formulario
                    txt_documenP.Text = "";
                    txt_RazonP.Text = "";
                    Dtg_Compra.Rows.Clear();
                    calcularTotal();
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la compra: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        }
}

