namespace Presentacion
{
    partial class Frm_ReporteCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fechaFin = new System.Windows.Forms.DateTimePicker();
            this.btn_BuscarP = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtg_Reporte = new System.Windows.Forms.DataGridView();
            this.Btn_LimpiarBuscar = new FontAwesome.Sharp.IconButton();
            this.btn_Buscar = new FontAwesome.Sharp.IconButton();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbx_Buscar = new System.Windows.Forms.ComboBox();
            this.cbx_Proveedor = new System.Windows.Forms.ComboBox();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Reporte)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(888, 66);
            this.label11.TabIndex = 24;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Reporte Compras";
            // 
            // txt_FechaInicio
            // 
            this.txt_FechaInicio.CustomFormat = "dd/MM/yyyy";
            this.txt_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_FechaInicio.Location = new System.Drawing.Point(96, 46);
            this.txt_FechaInicio.Name = "txt_FechaInicio";
            this.txt_FechaInicio.Size = new System.Drawing.Size(98, 20);
            this.txt_FechaInicio.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Fecha Inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(209, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Fecha Fin\r\n";
            // 
            // txt_fechaFin
            // 
            this.txt_fechaFin.CustomFormat = "dd/MM/yyyy";
            this.txt_fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_fechaFin.Location = new System.Drawing.Point(269, 46);
            this.txt_fechaFin.Name = "txt_fechaFin";
            this.txt_fechaFin.Size = new System.Drawing.Size(101, 20);
            this.txt_fechaFin.TabIndex = 28;
            // 
            // btn_BuscarP
            // 
            this.btn_BuscarP.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_BuscarP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BuscarP.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_BuscarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BuscarP.ForeColor = System.Drawing.Color.Black;
            this.btn_BuscarP.IconChar = FontAwesome.Sharp.IconChar.SearchLocation;
            this.btn_BuscarP.IconColor = System.Drawing.Color.Black;
            this.btn_BuscarP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_BuscarP.IconSize = 25;
            this.btn_BuscarP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BuscarP.Location = new System.Drawing.Point(589, 46);
            this.btn_BuscarP.Name = "btn_BuscarP";
            this.btn_BuscarP.Size = new System.Drawing.Size(74, 23);
            this.btn_BuscarP.TabIndex = 30;
            this.btn_BuscarP.Text = "Buscar";
            this.btn_BuscarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_BuscarP.UseVisualStyleBackColor = false;
            this.btn_BuscarP.Click += new System.EventHandler(this.btn_BuscarP_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(397, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Proveedor";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(888, 308);
            this.label5.TabIndex = 33;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtg_Reporte
            // 
            this.dtg_Reporte.AllowUserToAddRows = false;
            this.dtg_Reporte.AllowUserToOrderColumns = true;
            this.dtg_Reporte.BackgroundColor = System.Drawing.Color.White;
            this.dtg_Reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Reporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaRegistro,
            this.TipoDocumento,
            this.NumeroDocumento,
            this.MontoTotal,
            this.UsuarioRegistro,
            this.DocumentoProveedor,
            this.RazonSocial,
            this.CodigoProducto,
            this.NombreProducto,
            this.Categoria,
            this.PrecioCompra,
            this.PrecioVenta,
            this.Cantidad,
            this.SubTotal});
            this.dtg_Reporte.GridColor = System.Drawing.Color.Silver;
            this.dtg_Reporte.Location = new System.Drawing.Point(28, 143);
            this.dtg_Reporte.Name = "dtg_Reporte";
            this.dtg_Reporte.Size = new System.Drawing.Size(857, 229);
            this.dtg_Reporte.TabIndex = 34;
            // 
            // Btn_LimpiarBuscar
            // 
            this.Btn_LimpiarBuscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Btn_LimpiarBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_LimpiarBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_LimpiarBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_LimpiarBuscar.ForeColor = System.Drawing.Color.Black;
            this.Btn_LimpiarBuscar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.Btn_LimpiarBuscar.IconColor = System.Drawing.Color.Black;
            this.Btn_LimpiarBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_LimpiarBuscar.IconSize = 25;
            this.Btn_LimpiarBuscar.Location = new System.Drawing.Point(848, 103);
            this.Btn_LimpiarBuscar.Name = "Btn_LimpiarBuscar";
            this.Btn_LimpiarBuscar.Size = new System.Drawing.Size(35, 23);
            this.Btn_LimpiarBuscar.TabIndex = 39;
            this.Btn_LimpiarBuscar.UseVisualStyleBackColor = false;
            this.Btn_LimpiarBuscar.Click += new System.EventHandler(this.Btn_LimpiarBuscar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Buscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Buscar.ForeColor = System.Drawing.Color.Black;
            this.btn_Buscar.IconChar = FontAwesome.Sharp.IconChar.SearchLocation;
            this.btn_Buscar.IconColor = System.Drawing.Color.Black;
            this.btn_Buscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Buscar.IconSize = 25;
            this.btn_Buscar.Location = new System.Drawing.Point(803, 103);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(39, 23);
            this.btn_Buscar.TabIndex = 38;
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Location = new System.Drawing.Point(700, 103);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(97, 20);
            this.txt_Buscar.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(505, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Buscar Por :";
            // 
            // cbx_Buscar
            // 
            this.cbx_Buscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Buscar.FormattingEnabled = true;
            this.cbx_Buscar.Location = new System.Drawing.Point(567, 102);
            this.cbx_Buscar.Name = "cbx_Buscar";
            this.cbx_Buscar.Size = new System.Drawing.Size(127, 21);
            this.cbx_Buscar.TabIndex = 36;
            // 
            // cbx_Proveedor
            // 
            this.cbx_Proveedor.FormattingEnabled = true;
            this.cbx_Proveedor.Location = new System.Drawing.Point(459, 46);
            this.cbx_Proveedor.Name = "cbx_Proveedor";
            this.cbx_Proveedor.Size = new System.Drawing.Size(121, 21);
            this.cbx_Proveedor.TabIndex = 40;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.HeaderText = "Fecha Registro";
            this.FechaRegistro.Name = "FechaRegistro";
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.HeaderText = "Tipo Documento";
            this.TipoDocumento.Name = "TipoDocumento";
            // 
            // NumeroDocumento
            // 
            this.NumeroDocumento.HeaderText = "Numero Documento";
            this.NumeroDocumento.Name = "NumeroDocumento";
            // 
            // MontoTotal
            // 
            this.MontoTotal.HeaderText = "Monto Total";
            this.MontoTotal.Name = "MontoTotal";
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.HeaderText = "Usuario Registro";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            // 
            // DocumentoProveedor
            // 
            this.DocumentoProveedor.HeaderText = "Documento Proveedor";
            this.DocumentoProveedor.Name = "DocumentoProveedor";
            // 
            // RazonSocial
            // 
            this.RazonSocial.HeaderText = "Razon Social";
            this.RazonSocial.Name = "RazonSocial";
            // 
            // CodigoProducto
            // 
            this.CodigoProducto.HeaderText = "Codigo Producto";
            this.CodigoProducto.Name = "CodigoProducto";
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "Nombre Producto";
            this.NombreProducto.Name = "NombreProducto";
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio Compra";
            this.PrecioCompra.Name = "PrecioCompra";
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.Name = "PrecioVenta";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.Name = "SubTotal";
            // 
            // Frm_ReporteCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 450);
            this.Controls.Add(this.cbx_Proveedor);
            this.Controls.Add(this.Btn_LimpiarBuscar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.txt_Buscar);
            this.Controls.Add(this.cbx_Buscar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtg_Reporte);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_BuscarP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_fechaFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_FechaInicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Name = "Frm_ReporteCompra";
            this.Text = "Frm_ReporteCompra";
            this.Load += new System.EventHandler(this.Frm_ReporteCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Reporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txt_FechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txt_fechaFin;
        private FontAwesome.Sharp.IconButton btn_BuscarP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtg_Reporte;
        private FontAwesome.Sharp.IconButton Btn_LimpiarBuscar;
        private FontAwesome.Sharp.IconButton btn_Buscar;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbx_Buscar;
        private System.Windows.Forms.ComboBox cbx_Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
    }
}