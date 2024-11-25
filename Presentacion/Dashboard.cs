using Negocio;
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
    public partial class frm_Dashboard : Form
    {
        public frm_Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CargarGrafico();
            CargarGraficoVentasPorMes();
            CargarAlertasDeStockBajo();
        }



        private N_Producto negocioProducto = new N_Producto();
        private void CargarAlertasDeStockBajo()
        {
             var alertas = negocioProducto.ObtenerAlertasDeStockBajo();
            dataGridViewAlertas.DataSource = null;
            dataGridViewAlertas.DataSource = alertas;

             dataGridViewAlertas.Columns["ProductoId"].Visible = false;
             dataGridViewAlertas.Columns["NombreProducto"].HeaderText = "Nombre";
             dataGridViewAlertas.Columns["Mensaje"].HeaderText = "Alerta";
             dataGridViewAlertas.Columns["Stock"].HeaderText = "Stock";
             dataGridViewAlertas.Columns["FechaAlerta"].HeaderText = "Fecha de Alerta";



        }


        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            Label_Hora.Text = DateTime.Now.ToString("HH:mm:ss");
            label_Fecha.Text = DateTime.Now.ToShortDateString();
        }


        private void CargarGrafico()
        {
            try
            {
                N_Venta logicaVentas = new N_Venta();
                List<KeyValuePair<string, int>> topProductos = logicaVentas.ObtenerTopProductos();

                // Limpiar puntos existentes
                chart1_TopProduct.Series["Series1"].Points.Clear();

                // Cargar datos en la serie
                foreach (var producto in topProductos)
                {
                    chart1_TopProduct.Series["Series1"].Points.AddXY(producto.Key, producto.Value);
                }

                // Configurar el tipo de gráfico
                chart1_TopProduct.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;

                // Mostrar etiquetas con valores
                chart1_TopProduct.Series["Series1"].IsValueShownAsLabel = true;

                // Opcional: Formato de etiquetas
                chart1_TopProduct.Series["Series1"].LabelFormat = "{0}"; // Muestra el valor
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el gráfico: {ex.Message}");
            }
        }




        private void CargarGraficoVentasPorMes()
        {
            try
            {
                N_Venta logicaVentas = new N_Venta();
                List<KeyValuePair<string, decimal>> ventasPorMes = logicaVentas.ObtenerVentasPorMes();

                // Limpia la serie antes de agregar datos
                chart2.Series["Series1"].Points.Clear();

                foreach (var venta in ventasPorMes)
                {
                    chart2.Series["Series1"].Points.AddXY(venta.Key, venta.Value);
                }

                // Configura el tipo de gráfico como Column
                chart2.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                // Opcional: Configurar estilos
                chart2.Series["Series1"].IsValueShownAsLabel = true; // Mostrar los valores sobre las columnas
                chart2.ChartAreas[0].AxisX.Title = "Mes";
                chart2.ChartAreas[0].AxisY.Title = "Total Ventas";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico: " + ex.Message);
            }
        }




    }
}
