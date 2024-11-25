namespace Presentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Menuu = new System.Windows.Forms.MenuStrip();
            this.MuDashboard = new FontAwesome.Sharp.IconMenuItem();
            this.Musuarios = new FontAwesome.Sharp.IconMenuItem();
            this.Mmantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.subCateg = new FontAwesome.Sharp.IconMenuItem();
            this.subProd = new FontAwesome.Sharp.IconMenuItem();
            this.SubNegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.Mventas = new FontAwesome.Sharp.IconMenuItem();
            this.subRegistrarV = new FontAwesome.Sharp.IconMenuItem();
            this.subDventa = new FontAwesome.Sharp.IconMenuItem();
            this.Mcompras = new FontAwesome.Sharp.IconMenuItem();
            this.subRegistrarC = new FontAwesome.Sharp.IconMenuItem();
            this.subRegistarDcompra = new FontAwesome.Sharp.IconMenuItem();
            this.Mclientes = new FontAwesome.Sharp.IconMenuItem();
            this.Mproveedores = new FontAwesome.Sharp.IconMenuItem();
            this.Mreportes = new FontAwesome.Sharp.IconMenuItem();
            this.Sub_RCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_RVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.Macercade = new FontAwesome.Sharp.IconMenuItem();
            this.MenuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.txt_Rol = new System.Windows.Forms.Label();
            this.HoraFecha = new System.Windows.Forms.Timer(this.components);
            this.iconmaximizar = new System.Windows.Forms.PictureBox();
            this.iconRestaurar = new System.Windows.Forms.PictureBox();
            this.iconminimizar = new System.Windows.Forms.PictureBox();
            this.Pcontenedor = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Menuu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconmaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconminimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Menuu
            // 
            this.Menuu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Menuu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MuDashboard,
            this.Musuarios,
            this.Mmantenedor,
            this.Mventas,
            this.Mcompras,
            this.Mclientes,
            this.Mproveedores,
            this.Mreportes,
            this.Macercade});
            this.Menuu.Location = new System.Drawing.Point(0, 62);
            this.Menuu.Name = "Menuu";
            this.Menuu.Size = new System.Drawing.Size(1068, 73);
            this.Menuu.TabIndex = 0;
            // 
            // MuDashboard
            // 
            this.MuDashboard.AutoSize = false;
            this.MuDashboard.ForeColor = System.Drawing.Color.Black;
            this.MuDashboard.IconChar = FontAwesome.Sharp.IconChar.Gauge;
            this.MuDashboard.IconColor = System.Drawing.Color.Black;
            this.MuDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MuDashboard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MuDashboard.Name = "MuDashboard";
            this.MuDashboard.Size = new System.Drawing.Size(80, 69);
            this.MuDashboard.Text = "Dashboard";
            this.MuDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MuDashboard.Click += new System.EventHandler(this.MuDashboard_Click);
            // 
            // Musuarios
            // 
            this.Musuarios.AutoSize = false;
            this.Musuarios.ForeColor = System.Drawing.Color.Black;
            this.Musuarios.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.Musuarios.IconColor = System.Drawing.Color.Black;
            this.Musuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Musuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Musuarios.Name = "Musuarios";
            this.Musuarios.Size = new System.Drawing.Size(80, 69);
            this.Musuarios.Text = "Usuarios";
            this.Musuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Musuarios.Click += new System.EventHandler(this.Musuarios_Click);
            // 
            // Mmantenedor
            // 
            this.Mmantenedor.AutoSize = false;
            this.Mmantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subCateg,
            this.subProd,
            this.SubNegocio});
            this.Mmantenedor.ForeColor = System.Drawing.Color.Black;
            this.Mmantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.Mmantenedor.IconColor = System.Drawing.Color.Black;
            this.Mmantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Mmantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Mmantenedor.Name = "Mmantenedor";
            this.Mmantenedor.Size = new System.Drawing.Size(80, 69);
            this.Mmantenedor.Text = "Mantenedor";
            this.Mmantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // subCateg
            // 
            this.subCateg.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subCateg.IconColor = System.Drawing.Color.Black;
            this.subCateg.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subCateg.Name = "subCateg";
            this.subCateg.Size = new System.Drawing.Size(128, 22);
            this.subCateg.Text = "Categoria";
            this.subCateg.Click += new System.EventHandler(this.subCateg_Click);
            // 
            // subProd
            // 
            this.subProd.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subProd.IconColor = System.Drawing.Color.Black;
            this.subProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subProd.Name = "subProd";
            this.subProd.Size = new System.Drawing.Size(128, 22);
            this.subProd.Text = "Productos";
            this.subProd.Click += new System.EventHandler(this.subProd_Click);
            // 
            // SubNegocio
            // 
            this.SubNegocio.Name = "SubNegocio";
            this.SubNegocio.Size = new System.Drawing.Size(128, 22);
            this.SubNegocio.Text = "Negocio";
            this.SubNegocio.Click += new System.EventHandler(this.SubNegocio_Click);
            // 
            // Mventas
            // 
            this.Mventas.AutoSize = false;
            this.Mventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subRegistrarV,
            this.subDventa});
            this.Mventas.ForeColor = System.Drawing.Color.Black;
            this.Mventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.Mventas.IconColor = System.Drawing.Color.Black;
            this.Mventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Mventas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Mventas.Name = "Mventas";
            this.Mventas.Size = new System.Drawing.Size(80, 69);
            this.Mventas.Text = "Ventas";
            this.Mventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // subRegistrarV
            // 
            this.subRegistrarV.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subRegistrarV.IconColor = System.Drawing.Color.Black;
            this.subRegistrarV.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subRegistrarV.Name = "subRegistrarV";
            this.subRegistrarV.Size = new System.Drawing.Size(129, 22);
            this.subRegistrarV.Text = "Registrar";
            this.subRegistrarV.Click += new System.EventHandler(this.subRegistrar_Click);
            // 
            // subDventa
            // 
            this.subDventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subDventa.IconColor = System.Drawing.Color.Black;
            this.subDventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subDventa.Name = "subDventa";
            this.subDventa.Size = new System.Drawing.Size(129, 22);
            this.subDventa.Text = "Ver Detalle";
            this.subDventa.Click += new System.EventHandler(this.subDventa_Click);
            // 
            // Mcompras
            // 
            this.Mcompras.AutoSize = false;
            this.Mcompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subRegistrarC,
            this.subRegistarDcompra});
            this.Mcompras.ForeColor = System.Drawing.Color.Black;
            this.Mcompras.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.Mcompras.IconColor = System.Drawing.Color.Black;
            this.Mcompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Mcompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Mcompras.Name = "Mcompras";
            this.Mcompras.Size = new System.Drawing.Size(80, 69);
            this.Mcompras.Text = "Compras";
            this.Mcompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // subRegistrarC
            // 
            this.subRegistrarC.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subRegistrarC.IconColor = System.Drawing.Color.Black;
            this.subRegistrarC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subRegistrarC.Name = "subRegistrarC";
            this.subRegistrarC.Size = new System.Drawing.Size(129, 22);
            this.subRegistrarC.Text = "Registrar";
            this.subRegistrarC.Click += new System.EventHandler(this.subRegistrarC_Click);
            // 
            // subRegistarDcompra
            // 
            this.subRegistarDcompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subRegistarDcompra.IconColor = System.Drawing.Color.Black;
            this.subRegistarDcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subRegistarDcompra.Name = "subRegistarDcompra";
            this.subRegistarDcompra.Size = new System.Drawing.Size(129, 22);
            this.subRegistarDcompra.Text = "Ver Detalle";
            this.subRegistarDcompra.Click += new System.EventHandler(this.subRegistarDcompra_Click);
            // 
            // Mclientes
            // 
            this.Mclientes.AutoSize = false;
            this.Mclientes.ForeColor = System.Drawing.Color.Black;
            this.Mclientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.Mclientes.IconColor = System.Drawing.Color.Black;
            this.Mclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Mclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Mclientes.Name = "Mclientes";
            this.Mclientes.Size = new System.Drawing.Size(80, 69);
            this.Mclientes.Text = "Clientes";
            this.Mclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Mclientes.Click += new System.EventHandler(this.Mclientes_Click);
            // 
            // Mproveedores
            // 
            this.Mproveedores.AutoSize = false;
            this.Mproveedores.ForeColor = System.Drawing.Color.Black;
            this.Mproveedores.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.Mproveedores.IconColor = System.Drawing.Color.Black;
            this.Mproveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Mproveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Mproveedores.Name = "Mproveedores";
            this.Mproveedores.Size = new System.Drawing.Size(80, 69);
            this.Mproveedores.Text = "Proveedores";
            this.Mproveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Mproveedores.Click += new System.EventHandler(this.Mproveedores_Click);
            // 
            // Mreportes
            // 
            this.Mreportes.AutoSize = false;
            this.Mreportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sub_RCompras,
            this.Sub_RVentas});
            this.Mreportes.ForeColor = System.Drawing.Color.Black;
            this.Mreportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.Mreportes.IconColor = System.Drawing.Color.Black;
            this.Mreportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Mreportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Mreportes.Name = "Mreportes";
            this.Mreportes.Size = new System.Drawing.Size(80, 69);
            this.Mreportes.Text = "Reportes";
            this.Mreportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Sub_RCompras
            // 
            this.Sub_RCompras.Name = "Sub_RCompras";
            this.Sub_RCompras.Size = new System.Drawing.Size(166, 22);
            this.Sub_RCompras.Text = "Reporte Compras";
            this.Sub_RCompras.Click += new System.EventHandler(this.Sub_RCompras_Click);
            // 
            // Sub_RVentas
            // 
            this.Sub_RVentas.Name = "Sub_RVentas";
            this.Sub_RVentas.Size = new System.Drawing.Size(166, 22);
            this.Sub_RVentas.Text = "Reporte Ventas";
            this.Sub_RVentas.Click += new System.EventHandler(this.Sub_RVentas_Click);
            // 
            // Macercade
            // 
            this.Macercade.AutoSize = false;
            this.Macercade.ForeColor = System.Drawing.Color.Black;
            this.Macercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.Macercade.IconColor = System.Drawing.Color.Black;
            this.Macercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Macercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Macercade.Name = "Macercade";
            this.Macercade.Size = new System.Drawing.Size(80, 69);
            this.Macercade.Text = "Acerca de";
            this.Macercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Macercade.Click += new System.EventHandler(this.Macercade_Click);
            // 
            // MenuTitulo
            // 
            this.MenuTitulo.AutoSize = false;
            this.MenuTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(64)))), ((int)(((byte)(146)))));
            this.MenuTitulo.Location = new System.Drawing.Point(0, 0);
            this.MenuTitulo.Name = "MenuTitulo";
            this.MenuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MenuTitulo.Size = new System.Drawing.Size(1068, 62);
            this.MenuTitulo.TabIndex = 1;
            this.MenuTitulo.Text = "menuStrip2";
            this.MenuTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuTitulo_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(64)))), ((int)(((byte)(146)))));
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock One";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(64)))), ((int)(((byte)(146)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(764, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lbUsuario
            // 
            this.lbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(64)))), ((int)(((byte)(146)))));
            this.lbUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.ForeColor = System.Drawing.Color.White;
            this.lbUsuario.Location = new System.Drawing.Point(823, 32);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(60, 15);
            this.lbUsuario.TabIndex = 5;
            this.lbUsuario.Text = "Usuario";
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.LimeGreen;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(981, 12);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(75, 38);
            this.iconButton1.TabIndex = 6;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // txt_Rol
            // 
            this.txt_Rol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Rol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(64)))), ((int)(((byte)(146)))));
            this.txt_Rol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_Rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Rol.ForeColor = System.Drawing.Color.White;
            this.txt_Rol.Location = new System.Drawing.Point(872, 32);
            this.txt_Rol.Name = "txt_Rol";
            this.txt_Rol.Size = new System.Drawing.Size(60, 15);
            this.txt_Rol.TabIndex = 7;
            this.txt_Rol.Text = "idRol";
            // 
            // HoraFecha
            // 
            this.HoraFecha.Enabled = true;
            // 
            // iconmaximizar
            // 
            this.iconmaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconmaximizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(64)))), ((int)(((byte)(146)))));
            this.iconmaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconmaximizar.Image = global::Presentacion.Properties.Resources.maximizar__1_;
            this.iconmaximizar.Location = new System.Drawing.Point(959, 24);
            this.iconmaximizar.Name = "iconmaximizar";
            this.iconmaximizar.Size = new System.Drawing.Size(16, 16);
            this.iconmaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconmaximizar.TabIndex = 9;
            this.iconmaximizar.TabStop = false;
            this.iconmaximizar.Click += new System.EventHandler(this.iconmaximizar_Click);
            // 
            // iconRestaurar
            // 
            this.iconRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconRestaurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(64)))), ((int)(((byte)(146)))));
            this.iconRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconRestaurar.Image = global::Presentacion.Properties.Resources.expandir;
            this.iconRestaurar.Location = new System.Drawing.Point(959, 24);
            this.iconRestaurar.Name = "iconRestaurar";
            this.iconRestaurar.Size = new System.Drawing.Size(16, 16);
            this.iconRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconRestaurar.TabIndex = 9;
            this.iconRestaurar.TabStop = false;
            this.iconRestaurar.Visible = false;
            this.iconRestaurar.Click += new System.EventHandler(this.iconRestaurar_Click);
            // 
            // iconminimizar
            // 
            this.iconminimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconminimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(64)))), ((int)(((byte)(146)))));
            this.iconminimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconminimizar.Image = global::Presentacion.Properties.Resources.minimizar_signo;
            this.iconminimizar.Location = new System.Drawing.Point(937, 24);
            this.iconminimizar.Name = "iconminimizar";
            this.iconminimizar.Size = new System.Drawing.Size(16, 16);
            this.iconminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconminimizar.TabIndex = 10;
            this.iconminimizar.TabStop = false;
            this.iconminimizar.Click += new System.EventHandler(this.iconminimizar_Click);
            // 
            // Pcontenedor
            // 
            this.Pcontenedor.BackColor = System.Drawing.Color.Black;
            this.Pcontenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pcontenedor.Location = new System.Drawing.Point(0, 135);
            this.Pcontenedor.Name = "Pcontenedor";
            this.Pcontenedor.Size = new System.Drawing.Size(1068, 486);
            this.Pcontenedor.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Presentacion.Properties.Resources.Preview;
            this.pictureBox1.Location = new System.Drawing.Point(959, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1068, 621);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Pcontenedor);
            this.Controls.Add(this.iconRestaurar);
            this.Controls.Add(this.iconminimizar);
            this.Controls.Add(this.txt_Rol);
            this.Controls.Add(this.iconmaximizar);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Menuu);
            this.Controls.Add(this.MenuTitulo);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.Menuu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.Menuu.ResumeLayout(false);
            this.Menuu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconmaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconminimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menuu;
        private System.Windows.Forms.MenuStrip MenuTitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem Macercade;
        private FontAwesome.Sharp.IconMenuItem Mmantenedor;
        private FontAwesome.Sharp.IconMenuItem Mclientes;
        private FontAwesome.Sharp.IconMenuItem Mreportes;
        private FontAwesome.Sharp.IconMenuItem Mventas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUsuario;
        private FontAwesome.Sharp.IconMenuItem subCateg;
        private FontAwesome.Sharp.IconMenuItem subProd;
        private FontAwesome.Sharp.IconMenuItem subRegistrarV;
        private FontAwesome.Sharp.IconMenuItem subDventa;
        private FontAwesome.Sharp.IconMenuItem subRegistrarC;
        private FontAwesome.Sharp.IconMenuItem subRegistarDcompra;
        private System.Windows.Forms.ToolStripMenuItem SubNegocio;
        private System.Windows.Forms.ToolStripMenuItem Sub_RCompras;
        private System.Windows.Forms.ToolStripMenuItem Sub_RVentas;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label txt_Rol;
        internal FontAwesome.Sharp.IconMenuItem Musuarios;
        internal FontAwesome.Sharp.IconMenuItem Mcompras;
        internal FontAwesome.Sharp.IconMenuItem Mproveedores;
        private System.Windows.Forms.Timer HoraFecha;
        private FontAwesome.Sharp.IconMenuItem MuDashboard;
        private System.Windows.Forms.PictureBox iconmaximizar;
        private System.Windows.Forms.PictureBox iconRestaurar;
        private System.Windows.Forms.PictureBox iconminimizar;
        private System.Windows.Forms.Panel Pcontenedor;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

