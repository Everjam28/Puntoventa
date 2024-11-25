namespace Presentacion
{
    partial class Login_Original
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Original));
            this.Panel_imagen = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pan_Titulo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.txt_Contraseña = new System.Windows.Forms.TextBox();
            this.Bt_Ingresar = new System.Windows.Forms.Button();
            this.Bt_Cancelar = new System.Windows.Forms.Button();
            this.Panel_imagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Pan_Titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_imagen
            // 
            this.Panel_imagen.BackColor = System.Drawing.Color.Black;
            this.Panel_imagen.Controls.Add(this.pictureBox1);
            this.Panel_imagen.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_imagen.Location = new System.Drawing.Point(0, 0);
            this.Panel_imagen.Name = "Panel_imagen";
            this.Panel_imagen.Size = new System.Drawing.Size(270, 359);
            this.Panel_imagen.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Pan_Titulo
            // 
            this.Pan_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(64)))), ((int)(((byte)(146)))));
            this.Pan_Titulo.Controls.Add(this.label3);
            this.Pan_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pan_Titulo.Location = new System.Drawing.Point(270, 0);
            this.Pan_Titulo.Name = "Pan_Titulo";
            this.Pan_Titulo.Size = new System.Drawing.Size(368, 62);
            this.Pan_Titulo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(84, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sistema de Ventas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(326, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Location = new System.Drawing.Point(330, 141);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(226, 20);
            this.txt_Usuario.TabIndex = 4;
            // 
            // txt_Contraseña
            // 
            this.txt_Contraseña.Location = new System.Drawing.Point(330, 194);
            this.txt_Contraseña.Name = "txt_Contraseña";
            this.txt_Contraseña.Size = new System.Drawing.Size(226, 20);
            this.txt_Contraseña.TabIndex = 5;
            this.txt_Contraseña.UseSystemPasswordChar = true;
            this.txt_Contraseña.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Bt_Ingresar
            // 
            this.Bt_Ingresar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Bt_Ingresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bt_Ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Ingresar.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Ingresar.ForeColor = System.Drawing.Color.Black;
            this.Bt_Ingresar.Location = new System.Drawing.Point(330, 245);
            this.Bt_Ingresar.Name = "Bt_Ingresar";
            this.Bt_Ingresar.Size = new System.Drawing.Size(112, 46);
            this.Bt_Ingresar.TabIndex = 6;
            this.Bt_Ingresar.Text = "Iniciar";
            this.Bt_Ingresar.UseVisualStyleBackColor = false;
            this.Bt_Ingresar.Click += new System.EventHandler(this.Bt_Ingresar_Click);
            // 
            // Bt_Cancelar
            // 
            this.Bt_Cancelar.BackColor = System.Drawing.Color.Red;
            this.Bt_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Cancelar.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Cancelar.ForeColor = System.Drawing.Color.Black;
            this.Bt_Cancelar.Location = new System.Drawing.Point(463, 245);
            this.Bt_Cancelar.Name = "Bt_Cancelar";
            this.Bt_Cancelar.Size = new System.Drawing.Size(113, 46);
            this.Bt_Cancelar.TabIndex = 7;
            this.Bt_Cancelar.Text = "Cancelar";
            this.Bt_Cancelar.UseVisualStyleBackColor = false;
            this.Bt_Cancelar.Click += new System.EventHandler(this.Bt_Cancelar_Click);
            // 
            // Login_Original
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(638, 359);
            this.Controls.Add(this.Bt_Cancelar);
            this.Controls.Add(this.Bt_Ingresar);
            this.Controls.Add(this.txt_Contraseña);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pan_Titulo);
            this.Controls.Add(this.Panel_imagen);
            this.Name = "Login_Original";
            this.Text = "Login_Original";
            this.Panel_imagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Pan_Titulo.ResumeLayout(false);
            this.Pan_Titulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_imagen;
        private System.Windows.Forms.Panel Pan_Titulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.TextBox txt_Contraseña;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Bt_Ingresar;
        private System.Windows.Forms.Button Bt_Cancelar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}