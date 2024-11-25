namespace Presentacion.Modales
{
    partial class MdProveedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.cbx_Buscar = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Dtg_MDP = new System.Windows.Forms.DataGridView();
            this.Btn_LimpiarBuscar = new FontAwesome.Sharp.IconButton();
            this.btn_Buscar = new FontAwesome.Sharp.IconButton();
            this.Btn_Seleccionar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R_Social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_MDP)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Location = new System.Drawing.Point(247, 46);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(97, 20);
            this.txt_Buscar.TabIndex = 33;
            // 
            // cbx_Buscar
            // 
            this.cbx_Buscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Buscar.FormattingEnabled = true;
            this.cbx_Buscar.Location = new System.Drawing.Point(136, 45);
            this.cbx_Buscar.Name = "cbx_Buscar";
            this.cbx_Buscar.Size = new System.Drawing.Size(105, 21);
            this.cbx_Buscar.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(65, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Buscar Por :";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(472, 68);
            this.label11.TabIndex = 30;
            this.label11.Text = "Lista de Proveedores";
            // 
            // Dtg_MDP
            // 
            this.Dtg_MDP.AllowUserToAddRows = false;
            this.Dtg_MDP.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dtg_MDP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Dtg_MDP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_MDP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Btn_Seleccionar,
            this.Documento,
            this.R_Social});
            this.Dtg_MDP.Location = new System.Drawing.Point(12, 92);
            this.Dtg_MDP.MultiSelect = false;
            this.Dtg_MDP.Name = "Dtg_MDP";
            this.Dtg_MDP.ReadOnly = true;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.Dtg_MDP.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Dtg_MDP.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Dtg_MDP.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.Dtg_MDP.RowTemplate.Height = 28;
            this.Dtg_MDP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dtg_MDP.Size = new System.Drawing.Size(467, 315);
            this.Dtg_MDP.TabIndex = 29;
            this.Dtg_MDP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_MDP_CellDoubleClick);
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
            this.Btn_LimpiarBuscar.Location = new System.Drawing.Point(395, 46);
            this.Btn_LimpiarBuscar.Name = "Btn_LimpiarBuscar";
            this.Btn_LimpiarBuscar.Size = new System.Drawing.Size(35, 23);
            this.Btn_LimpiarBuscar.TabIndex = 35;
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
            this.btn_Buscar.Location = new System.Drawing.Point(350, 46);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(39, 23);
            this.btn_Buscar.TabIndex = 34;
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // Btn_Seleccionar
            // 
            this.Btn_Seleccionar.HeaderText = "";
            this.Btn_Seleccionar.Name = "Btn_Seleccionar";
            this.Btn_Seleccionar.ReadOnly = true;
            this.Btn_Seleccionar.Width = 30;
            // 
            // Documento
            // 
            this.Documento.HeaderText = "Nro Documento";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            this.Documento.Width = 150;
            // 
            // R_Social
            // 
            this.R_Social.HeaderText = "Razón Social";
            this.R_Social.Name = "R_Social";
            this.R_Social.ReadOnly = true;
            this.R_Social.Width = 150;
            // 
            // MdProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 422);
            this.Controls.Add(this.Btn_LimpiarBuscar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.txt_Buscar);
            this.Controls.Add(this.cbx_Buscar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Dtg_MDP);
            this.Name = "MdProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MdProveedor";
            this.Load += new System.EventHandler(this.MdProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_MDP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton Btn_LimpiarBuscar;
        private FontAwesome.Sharp.IconButton btn_Buscar;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.ComboBox cbx_Buscar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView Dtg_MDP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Btn_Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn R_Social;
    }
}