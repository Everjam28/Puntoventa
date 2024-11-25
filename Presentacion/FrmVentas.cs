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
    public partial class FrmVentas : Form
    {
        private Usuario _Usuario = null;
        public FrmVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            cbx_TipDocu.Items.Add(new OpCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbx_TipDocu.Items.Add(new OpCombo() { Valor = "Factura", Texto = "Factura" });
            cbx_TipDocu.DisplayMember = "Texto";
            cbx_TipDocu.ValueMember = "Valor";
            cbx_TipDocu.SelectedIndex = 0;

            txt_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txt_idP.Text = "0";
            txt_PagoCon.Text = "0";
            txt_cambio.Text = "";
            txt_TP.Text = "0";


            // Métodos de pago
            cbx_MetodoPago.Items.Add(new OpCombo() { Valor = "Efectivo", Texto = "Efectivo" });
            cbx_MetodoPago.Items.Add(new OpCombo() { Valor = "Tarjeta", Texto = "Tarjeta" });
            cbx_MetodoPago.Items.Add(new OpCombo() { Valor = "Transferencia", Texto = "Transferencia" });
            cbx_MetodoPago.DisplayMember = "Texto";
            cbx_MetodoPago.ValueMember = "Valor";
            cbx_MetodoPago.SelectedIndex = 0;

        }

        private void btn_BuscarC_Click(object sender, EventArgs e)
        {
            using (var modal = new MdClientes())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txt_documenC.Text = modal._cliente.Documento;
                    txt_Pnombre.Text = modal._cliente.Primer_Nombre;
                    txt_apellido.Text = modal._cliente.Primer_Apellido;
                    txt_CodiP.Select();

                }
                else
                {
                    txt_documenC.Select();
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
                    txt_precio.Text = modal._Producto.PrecioVenta.ToString("0.000");
                    txt_Stock.Text = modal._Producto.Stock.ToString();
                    txt_Contador.Select();

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
                    txt_precio.Text = oProducto.PrecioVenta.ToString("0.00");
                    txt_Stock.Text = oProducto.Stock.ToString();
                    txt_Contador.Select();
                }
                else
                {
                    txt_CodiP.BackColor = Color.MistyRose;
                    txt_idP.Text = "0";
                    txt_Producto.Text = "";
                    txt_precio.Text = "";
                    txt_Stock.Text = "";
                    txt_Contador.Value = 1;
                }
            }
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool producto_existe = false;

            if (int.Parse(txt_idP.Text) == 0)
            {

                MessageBox.Show("Debe seleccionar un Producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txt_precio.Text, out precio))
            {

                MessageBox.Show("Precio - Formato moneda incorreto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_precio.Select();
                return;
            }

            if (Convert.ToInt32(txt_Stock.Text) < Convert.ToInt32(txt_Contador.Value.ToString()))
            {

                MessageBox.Show("La Cantidad no puede ser mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            foreach (DataGridViewRow fila in Dtg_Venta.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txt_Producto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                // string mensaje = string.Empty;
                bool respuesta = new N_Venta().RestarStock(
                    Convert.ToInt32(txt_idP.Text),
                    Convert.ToInt32(txt_Contador.Value.ToString())

                    );

                if (respuesta)
                {
                    Dtg_Venta.Rows.Add(new object[]{

                        txt_idP.Text,
                        txt_Producto.Text,
                        precio.ToString("0.000"),
                        txt_Contador.Value.ToString(),
                        (txt_Contador.Value * precio).ToString("0.000")

                    });

                    calcularTotal();
                    Limpiar();
                    txt_CodiP.Select();

                }

            }
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (Dtg_Venta.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Dtg_Venta.Rows)
                    total += Convert.ToDecimal(row.Cells["SubT"].Value.ToString());
            }
            txt_TP.Text = total.ToString("0.000");
        }

        private void Limpiar()
        {
            txt_idP.Text = "0";
            txt_Producto.Text = "";
            txt_CodiP.BackColor = Color.White;
            txt_precio.Text = "";
            txt_Stock.Text = "";
            txt_Contador.Value = 1;


        }

        private void Dtg_Venta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
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

        private void Dtg_Venta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txt_precio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
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

        private void txt_PagoCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txt_PagoCon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
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


        private void calcularCambio()
        {
            if (string.IsNullOrWhiteSpace(txt_TP.Text) || txt_TP.Text == "0.000")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal pagaCon;
            decimal total = 0;

            // Verifica si el campo total tiene un valor válido
            if (!decimal.TryParse(txt_TP.Text, out total))
            {
                MessageBox.Show("El total a pagar no tiene un formato válido.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_PagoCon.Text))
            {
                txt_PagoCon.Text = "0";
            }

            // Verifica si el campo Pago Con tiene un valor válido
            if (decimal.TryParse(txt_PagoCon.Text.Trim(), out pagaCon))
            {
                if (pagaCon < total)
                {
                    txt_cambio.Text = "0.000";
                }
                else
                {
                    decimal cambio = pagaCon - total;
                    txt_cambio.Text = cambio.ToString("0.000");
                }
            }
            else
            {
                MessageBox.Show("El monto ingresado para pagar no tiene un formato válido.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        /* private void calcularCambio()
         {
             if (txt_TP.Text.Trim() == "")
             {
                 MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
             }

             decimal pagaCon;
             decimal total = Convert.ToDecimal(txt_TP.Text);

             if (txt_PagoCon.Text.Trim() == "")
             {
                 txt_PagoCon.Text = "0";
             }

             if (decimal.TryParse(txt_PagoCon.Text.Trim(), out pagaCon))
             {
                 if (pagaCon < total)
                 {
                     txt_cambio.Text = "0.000";
                 }
                 else
                 {
                     decimal cambio = pagaCon - total;
                     txt_cambio.Text = cambio.ToString("0.000");
                 }
             }
         }
         */
        private void txt_PagoCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calcularCambio();
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_documenC.Text == "")
                {
                    MessageBox.Show("Debe ingresar el documento del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (txt_Pnombre.Text == "")
                {
                    MessageBox.Show("Debe ingresar el Nombre del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (cbx_MetodoPago.Text == "")
                {
                    MessageBox.Show("Debe ingresar el metodo de pago", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (Dtg_Venta.Rows.Count < 1)
                {
                    MessageBox.Show("Debe ingresar productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }



                List<Detalle_Venta> detalles = new List<Detalle_Venta>();

                // Llenar la lista con datos del DataGridView
                foreach (DataGridViewRow row in Dtg_Venta.Rows)
                {
                    if (row.IsNewRow) continue; // Para evitar errores con filas vacías

                    // Validar y convertir valores
                    if (row.Cells["IdProducto"].Value == null ||
                        row.Cells["Producto"].Value == null ||
                        row.Cells["Precio"].Value == null ||
                        row.Cells["Cantidad"].Value == null ||
                        row.Cells["SubT"].Value == null)
                    {
                        MessageBox.Show("Todos los campos de producto deben estar completos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Detalle_Venta detalle = new Detalle_Venta
                    {
                        oProducto = new Producto { IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value) },

                        PrecioVenta = Convert.ToDecimal(row.Cells["Precio"].Value),
                        Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                        Subtotal = Convert.ToDecimal(row.Cells["SubT"].Value),
                        FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };

                    detalles.Add(detalle);
                }

                // Obtener el correlativo para el número de documento
                int idcorrelativo = new N_Compra().ObtenerCorrelativo();
                string numerodocumento = string.Format("{0:00000}", idcorrelativo);

                // Crear el objeto Compra
                Venta oVenta = new Venta
                {
                    Idventa = idcorrelativo,
                    oUsuario = new Usuario { Documento = _Usuario.Documento },
                    TipoDocumento = ((OpCombo)cbx_TipDocu.SelectedItem).Texto,
                    NumeroDocumento = numerodocumento,
                    DocumentoCliente = txt_documenC.Text,
                    NombreCliente = txt_Pnombre.Text,
                    MetodoPago = cbx_MetodoPago.Text,
                    MontoPago = Convert.ToDecimal(txt_PagoCon.Text),
                    MontoCambio = Convert.ToDecimal(txt_cambio.Text),
                    MontoTotal = Convert.ToDecimal(txt_TP.Text),
                    FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    oDetalleVenta = detalles
                };

                string mensaje;
                bool respuesta = new N_Venta().Registrar(oVenta, out mensaje);

                if (respuesta)
                {
                    var result = MessageBox.Show("Número de venta generada:\n" + numerodocumento + "\n\n ¿Desea Copiar al portapapeles?",
                                                 "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        Clipboard.SetText(numerodocumento);
                    }

                    // Limpiar el formulario
                    txt_apellido.Text = "";
                    txt_documenC.Text = "";
                    txt_Pnombre.Text = "";
                    Dtg_Venta.Rows.Clear();
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





        private void Dtg_Venta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dtg_Venta.Columns[e.ColumnIndex].Name == "Btn_Eliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    bool respuesta = new N_Venta().SumarStock(
                        Convert.ToInt32(Dtg_Venta.Rows[indice].Cells["IdProducto"].Value.ToString()),
                        Convert.ToInt32(Dtg_Venta.Rows[indice].Cells["Cantidad"].Value.ToString()));

                    if (respuesta)
                    {
                        Dtg_Venta.Rows.RemoveAt(indice);
                        calcularTotal();
                    }


                }
            }
        }
    }
}
