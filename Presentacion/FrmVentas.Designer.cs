namespace Presentacion
{
    partial class FrmVentas
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
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_BuscarC = new FontAwesome.Sharp.IconButton();
            this.txt_Pnombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_documenC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_TipDocu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_Contador = new System.Windows.Forms.NumericUpDown();
            this.txt_idP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Stock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_precio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_BuscarCp = new FontAwesome.Sharp.IconButton();
            this.txt_Producto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_CodiP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Btn_Agregar = new FontAwesome.Sharp.IconButton();
            this.btn_Guardar = new FontAwesome.Sharp.IconButton();
            this.txt_TP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Dtg_Venta = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_Eliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_PagoCon = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_cambio = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbx_MetodoPago = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Contador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Venta)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(99, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(840, 439);
            this.label11.TabIndex = 24;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Registrar Venta";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txt_apellido);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btn_BuscarC);
            this.groupBox2.Controls.Add(this.txt_Pnombre);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_documenC);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(479, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 77);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacion Cliente";
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(300, 43);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(89, 20);
            this.txt_apellido.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(297, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Apellido";
            // 
            // btn_BuscarC
            // 
            this.btn_BuscarC.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_BuscarC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BuscarC.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_BuscarC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BuscarC.ForeColor = System.Drawing.Color.Black;
            this.btn_BuscarC.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassLocation;
            this.btn_BuscarC.IconColor = System.Drawing.Color.Black;
            this.btn_BuscarC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_BuscarC.IconSize = 25;
            this.btn_BuscarC.Location = new System.Drawing.Point(151, 40);
            this.btn_BuscarC.Name = "btn_BuscarC";
            this.btn_BuscarC.Size = new System.Drawing.Size(39, 23);
            this.btn_BuscarC.TabIndex = 28;
            this.btn_BuscarC.UseVisualStyleBackColor = false;
            this.btn_BuscarC.Click += new System.EventHandler(this.btn_BuscarC_Click);
            // 
            // txt_Pnombre
            // 
            this.txt_Pnombre.Location = new System.Drawing.Point(202, 43);
            this.txt_Pnombre.Name = "txt_Pnombre";
            this.txt_Pnombre.Size = new System.Drawing.Size(89, 20);
            this.txt_Pnombre.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombre";
            // 
            // txt_documenC
            // 
            this.txt_documenC.Location = new System.Drawing.Point(20, 42);
            this.txt_documenC.Name = "txt_documenC";
            this.txt_documenC.Size = new System.Drawing.Size(125, 20);
            this.txt_documenC.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Numero Documento";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cbx_TipDocu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_fecha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(147, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 77);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion Venta";
            // 
            // cbx_TipDocu
            // 
            this.cbx_TipDocu.FormattingEnabled = true;
            this.cbx_TipDocu.Location = new System.Drawing.Point(144, 42);
            this.cbx_TipDocu.Name = "cbx_TipDocu";
            this.cbx_TipDocu.Size = new System.Drawing.Size(121, 21);
            this.cbx_TipDocu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Documento";
            // 
            // txt_fecha
            // 
            this.txt_fecha.Location = new System.Drawing.Point(20, 42);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.Size = new System.Drawing.Size(100, 20);
            this.txt_fecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txt_Contador);
            this.groupBox3.Controls.Add(this.txt_idP);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txt_Stock);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txt_precio);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.Btn_BuscarCp);
            this.groupBox3.Controls.Add(this.txt_Producto);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txt_CodiP);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(147, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(643, 77);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informacion de Prducto";
            // 
            // txt_Contador
            // 
            this.txt_Contador.Location = new System.Drawing.Point(563, 47);
            this.txt_Contador.Name = "txt_Contador";
            this.txt_Contador.Size = new System.Drawing.Size(71, 20);
            this.txt_Contador.TabIndex = 28;
            this.txt_Contador.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txt_idP
            // 
            this.txt_idP.Location = new System.Drawing.Point(111, 20);
            this.txt_idP.Name = "txt_idP";
            this.txt_idP.Size = new System.Drawing.Size(47, 20);
            this.txt_idP.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(560, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Cantidad";
            // 
            // txt_Stock
            // 
            this.txt_Stock.Location = new System.Drawing.Point(457, 46);
            this.txt_Stock.Name = "txt_Stock";
            this.txt_Stock.Size = new System.Drawing.Size(100, 20);
            this.txt_Stock.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(454, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Stock";
            // 
            // txt_precio
            // 
            this.txt_precio.Location = new System.Drawing.Point(351, 45);
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.Size = new System.Drawing.Size(100, 20);
            this.txt_precio.TabIndex = 30;
            this.txt_precio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_precio_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Precio";
            // 
            // Btn_BuscarCp
            // 
            this.Btn_BuscarCp.BackColor = System.Drawing.Color.SpringGreen;
            this.Btn_BuscarCp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_BuscarCp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_BuscarCp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_BuscarCp.ForeColor = System.Drawing.Color.Black;
            this.Btn_BuscarCp.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassLocation;
            this.Btn_BuscarCp.IconColor = System.Drawing.Color.Black;
            this.Btn_BuscarCp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_BuscarCp.IconSize = 25;
            this.Btn_BuscarCp.Location = new System.Drawing.Point(164, 42);
            this.Btn_BuscarCp.Name = "Btn_BuscarCp";
            this.Btn_BuscarCp.Size = new System.Drawing.Size(39, 23);
            this.Btn_BuscarCp.TabIndex = 28;
            this.Btn_BuscarCp.UseVisualStyleBackColor = false;
            this.Btn_BuscarCp.Click += new System.EventHandler(this.Btn_BuscarCp_Click);
            // 
            // txt_Producto
            // 
            this.txt_Producto.Location = new System.Drawing.Point(226, 45);
            this.txt_Producto.Name = "txt_Producto";
            this.txt_Producto.Size = new System.Drawing.Size(100, 20);
            this.txt_Producto.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Producto";
            // 
            // txt_CodiP
            // 
            this.txt_CodiP.Location = new System.Drawing.Point(20, 42);
            this.txt_CodiP.Name = "txt_CodiP";
            this.txt_CodiP.Size = new System.Drawing.Size(138, 20);
            this.txt_CodiP.TabIndex = 1;
            this.txt_CodiP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_CodiP_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Cod. producto";
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.BackColor = System.Drawing.Color.SpringGreen;
            this.Btn_Agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Agregar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Agregar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Agregar.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.Btn_Agregar.IconColor = System.Drawing.Color.Black;
            this.Btn_Agregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_Agregar.IconSize = 25;
            this.Btn_Agregar.Location = new System.Drawing.Point(796, 150);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(98, 57);
            this.Btn_Agregar.TabIndex = 40;
            this.Btn_Agregar.Text = "Agregar";
            this.Btn_Agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Agregar.UseVisualStyleBackColor = false;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.ForeColor = System.Drawing.Color.Black;
            this.btn_Guardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btn_Guardar.IconColor = System.Drawing.Color.Black;
            this.btn_Guardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Guardar.Location = new System.Drawing.Point(796, 414);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(100, 23);
            this.btn_Guardar.TabIndex = 39;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // txt_TP
            // 
            this.txt_TP.Location = new System.Drawing.Point(794, 263);
            this.txt_TP.Name = "txt_TP";
            this.txt_TP.Size = new System.Drawing.Size(100, 20);
            this.txt_TP.TabIndex = 38;
            this.txt_TP.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(791, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Total a Pagar";
            // 
            // Dtg_Venta
            // 
            this.Dtg_Venta.AllowUserToAddRows = false;
            this.Dtg_Venta.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dtg_Venta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dtg_Venta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Venta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.SubT,
            this.Btn_Eliminar});
            this.Dtg_Venta.Location = new System.Drawing.Point(147, 227);
            this.Dtg_Venta.MultiSelect = false;
            this.Dtg_Venta.Name = "Dtg_Venta";
            this.Dtg_Venta.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Dtg_Venta.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Dtg_Venta.RowTemplate.Height = 28;
            this.Dtg_Venta.Size = new System.Drawing.Size(643, 210);
            this.Dtg_Venta.TabIndex = 41;
            this.Dtg_Venta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Venta_CellClick);
            this.Dtg_Venta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Venta_CellContentClick);
            this.Dtg_Venta.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.Dtg_Venta_CellPainting);
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 150;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
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
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.HeaderText = "";
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.ReadOnly = true;
            this.Btn_Eliminar.Width = 30;
            // 
            // txt_PagoCon
            // 
            this.txt_PagoCon.Location = new System.Drawing.Point(794, 349);
            this.txt_PagoCon.Name = "txt_PagoCon";
            this.txt_PagoCon.Size = new System.Drawing.Size(100, 20);
            this.txt_PagoCon.TabIndex = 43;
            this.txt_PagoCon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PagoCon_KeyDown);
            this.txt_PagoCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PagoCon_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(793, 333);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "Paga Con:";
            // 
            // txt_cambio
            // 
            this.txt_cambio.Location = new System.Drawing.Point(796, 388);
            this.txt_cambio.Name = "txt_cambio";
            this.txt_cambio.Size = new System.Drawing.Size(100, 20);
            this.txt_cambio.TabIndex = 45;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(793, 372);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "Cambio:";
            // 
            // cbx_MetodoPago
            // 
            this.cbx_MetodoPago.FormattingEnabled = true;
            this.cbx_MetodoPago.Location = new System.Drawing.Point(794, 309);
            this.cbx_MetodoPago.Name = "cbx_MetodoPago";
            this.cbx_MetodoPago.Size = new System.Drawing.Size(102, 21);
            this.cbx_MetodoPago.TabIndex = 46;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(793, 293);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 13);
            this.label16.TabIndex = 47;
            this.label16.Text = "Metodo de Pago";
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 544);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbx_MetodoPago);
            this.Controls.Add(this.txt_cambio);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_PagoCon);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Dtg_Venta);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.txt_TP);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Name = "FrmVentas";
            this.Text = "FrmVentas";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Contador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Venta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private FontAwesome.Sharp.IconButton btn_BuscarC;
        private System.Windows.Forms.TextBox txt_Pnombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_documenC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbx_TipDocu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown txt_Contador;
        private System.Windows.Forms.TextBox txt_idP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Stock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_precio;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton Btn_BuscarCp;
        private System.Windows.Forms.TextBox txt_Producto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_CodiP;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton Btn_Agregar;
        private FontAwesome.Sharp.IconButton btn_Guardar;
        private System.Windows.Forms.TextBox txt_TP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView Dtg_Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Btn_Eliminar;
        private System.Windows.Forms.TextBox txt_PagoCon;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_cambio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbx_MetodoPago;
        private System.Windows.Forms.Label label16;
    }
}