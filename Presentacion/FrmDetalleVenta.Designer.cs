namespace Presentacion
{
    partial class FrmDetalleVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_documenC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Dtg_D_Venta = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Apellido = new System.Windows.Forms.TextBox();
            this.txt_TipoDocumento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fecha = new System.Windows.Forms.TextBox();
            this.txt_TP = new System.Windows.Forms.TextBox();
            this.Btn_Dpdf = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_NumeroDocu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_NombreC = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_LimpiarBuscar = new FontAwesome.Sharp.IconButton();
            this.btn_Buscar = new FontAwesome.Sharp.IconButton();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_MCambio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Mpago = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_D_Venta)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nombre";
            // 
            // txt_documenC
            // 
            this.txt_documenC.Location = new System.Drawing.Point(20, 42);
            this.txt_documenC.Name = "txt_documenC";
            this.txt_documenC.Size = new System.Drawing.Size(125, 20);
            this.txt_documenC.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Numero Documento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(436, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Apellido";
            // 
            // Dtg_D_Venta
            // 
            this.Dtg_D_Venta.AllowUserToAddRows = false;
            this.Dtg_D_Venta.AllowUserToOrderColumns = true;
            this.Dtg_D_Venta.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dtg_D_Venta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dtg_D_Venta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_D_Venta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioC,
            this.Cantidad,
            this.SubT});
            this.Dtg_D_Venta.Location = new System.Drawing.Point(131, 205);
            this.Dtg_D_Venta.MultiSelect = false;
            this.Dtg_D_Venta.Name = "Dtg_D_Venta";
            this.Dtg_D_Venta.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Dtg_D_Venta.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Dtg_D_Venta.RowTemplate.Height = 28;
            this.Dtg_D_Venta.Size = new System.Drawing.Size(534, 210);
            this.Dtg_D_Venta.TabIndex = 76;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 150;
            // 
            // PrecioC
            // 
            this.PrecioC.HeaderText = "Precio";
            this.PrecioC.Name = "PrecioC";
            this.PrecioC.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // SubT
            // 
            this.SubT.HeaderText = "Sub Total";
            this.SubT.Name = "SubT";
            this.SubT.ReadOnly = true;
            // 
            // txt_Apellido
            // 
            this.txt_Apellido.Location = new System.Drawing.Point(439, 42);
            this.txt_Apellido.Name = "txt_Apellido";
            this.txt_Apellido.Size = new System.Drawing.Size(82, 20);
            this.txt_Apellido.TabIndex = 7;
            // 
            // txt_TipoDocumento
            // 
            this.txt_TipoDocumento.Location = new System.Drawing.Point(184, 42);
            this.txt_TipoDocumento.Name = "txt_TipoDocumento";
            this.txt_TipoDocumento.Size = new System.Drawing.Size(144, 20);
            this.txt_TipoDocumento.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(348, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nombre";
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Location = new System.Drawing.Point(351, 42);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(82, 20);
            this.txt_Usuario.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Documento";
            // 
            // txt_fecha
            // 
            this.txt_fecha.Location = new System.Drawing.Point(20, 42);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.Size = new System.Drawing.Size(142, 20);
            this.txt_fecha.TabIndex = 1;
            // 
            // txt_TP
            // 
            this.txt_TP.Location = new System.Drawing.Point(193, 421);
            this.txt_TP.Name = "txt_TP";
            this.txt_TP.Size = new System.Drawing.Size(57, 20);
            this.txt_TP.TabIndex = 78;
            this.txt_TP.Text = "0";
            // 
            // Btn_Dpdf
            // 
            this.Btn_Dpdf.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Btn_Dpdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Dpdf.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Dpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Dpdf.ForeColor = System.Drawing.Color.Black;
            this.Btn_Dpdf.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.Btn_Dpdf.IconColor = System.Drawing.Color.Black;
            this.Btn_Dpdf.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_Dpdf.IconSize = 25;
            this.Btn_Dpdf.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Dpdf.Location = new System.Drawing.Point(536, 418);
            this.Btn_Dpdf.Name = "Btn_Dpdf";
            this.Btn_Dpdf.Size = new System.Drawing.Size(129, 23);
            this.Btn_Dpdf.TabIndex = 79;
            this.Btn_Dpdf.Text = "Descargar PDF";
            this.Btn_Dpdf.UseVisualStyleBackColor = false;
            this.Btn_Dpdf.Click += new System.EventHandler(this.Btn_Dpdf_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha";
            // 
            // txt_NumeroDocu
            // 
            this.txt_NumeroDocu.Location = new System.Drawing.Point(425, 42);
            this.txt_NumeroDocu.Name = "txt_NumeroDocu";
            this.txt_NumeroDocu.Size = new System.Drawing.Size(93, 20);
            this.txt_NumeroDocu.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(128, 424);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 77;
            this.label12.Text = "Monto Total";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txt_NumeroDocu);
            this.groupBox2.Controls.Add(this.txt_NombreC);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_documenC);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(131, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 77);
            this.groupBox2.TabIndex = 75;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacion Cliente";
            // 
            // txt_NombreC
            // 
            this.txt_NombreC.Location = new System.Drawing.Point(176, 42);
            this.txt_NombreC.Name = "txt_NombreC";
            this.txt_NombreC.Size = new System.Drawing.Size(152, 20);
            this.txt_NombreC.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_Apellido);
            this.groupBox1.Controls.Add(this.txt_TipoDocumento);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_Usuario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_fecha);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(131, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 77);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion Venta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(332, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 18);
            this.label2.TabIndex = 73;
            this.label2.Text = "Numero Documento";
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
            this.Btn_LimpiarBuscar.Location = new System.Drawing.Point(630, 11);
            this.Btn_LimpiarBuscar.Name = "Btn_LimpiarBuscar";
            this.Btn_LimpiarBuscar.Size = new System.Drawing.Size(35, 23);
            this.Btn_LimpiarBuscar.TabIndex = 72;
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
            this.btn_Buscar.Location = new System.Drawing.Point(585, 11);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(39, 23);
            this.btn_Buscar.TabIndex = 71;
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Location = new System.Drawing.Point(482, 13);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(97, 20);
            this.txt_Buscar.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 69;
            this.label1.Text = "Detalle Venta";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(115, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(570, 449);
            this.label11.TabIndex = 68;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_MCambio
            // 
            this.txt_MCambio.Location = new System.Drawing.Point(461, 421);
            this.txt_MCambio.Name = "txt_MCambio";
            this.txt_MCambio.Size = new System.Drawing.Size(48, 20);
            this.txt_MCambio.TabIndex = 83;
            this.txt_MCambio.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(387, 424);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 82;
            this.label10.Text = "Monto Cambio";
            // 
            // txt_Mpago
            // 
            this.txt_Mpago.Location = new System.Drawing.Point(321, 421);
            this.txt_Mpago.Name = "txt_Mpago";
            this.txt_Mpago.Size = new System.Drawing.Size(63, 20);
            this.txt_Mpago.TabIndex = 81;
            this.txt_Mpago.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(256, 424);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 80;
            this.label9.Text = "Monto Pago";
            // 
            // FrmDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_MCambio);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Mpago);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Dtg_D_Venta);
            this.Controls.Add(this.txt_TP);
            this.Controls.Add(this.Btn_Dpdf);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_LimpiarBuscar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.txt_Buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Name = "FrmDetalleVenta";
            this.Text = "FrmDetalleVenta";
            this.Load += new System.EventHandler(this.FrmDetalleVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_D_Venta)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_documenC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView Dtg_D_Venta;
        private System.Windows.Forms.TextBox txt_Apellido;
        private System.Windows.Forms.TextBox txt_TipoDocumento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_fecha;
        private System.Windows.Forms.TextBox txt_TP;
        private FontAwesome.Sharp.IconButton Btn_Dpdf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_NumeroDocu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_NombreC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton Btn_LimpiarBuscar;
        private FontAwesome.Sharp.IconButton btn_Buscar;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_MCambio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Mpago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubT;
    }
}