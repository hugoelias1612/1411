namespace ArimaERP
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.TLPBase = new System.Windows.Forms.TableLayoutPanel();
            this.PHeader = new System.Windows.Forms.Panel();
            this.LSubtitulo = new System.Windows.Forms.Label();
            this.LTitulo = new System.Windows.Forms.Label();
            this.TLPBody = new System.Windows.Forms.TableLayoutPanel();
            this.PBody = new System.Windows.Forms.Panel();
            this.CMostrar = new System.Windows.Forms.CheckBox();
            this.TContrasena = new System.Windows.Forms.TextBox();
            this.LContraseña = new System.Windows.Forms.Label();
            this.TCorreo = new System.Windows.Forms.TextBox();
            this.LCorreo = new System.Windows.Forms.Label();
            this.BIngresar = new System.Windows.Forms.Button();
            this.TLPBase.SuspendLayout();
            this.PHeader.SuspendLayout();
            this.TLPBody.SuspendLayout();
            this.PBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPBase
            // 
            this.TLPBase.BackColor = System.Drawing.Color.Transparent;
            this.TLPBase.ColumnCount = 3;
            this.TLPBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.TLPBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66F));
            this.TLPBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.TLPBase.Controls.Add(this.PHeader, 1, 0);
            this.TLPBase.Controls.Add(this.TLPBody, 1, 1);
            this.TLPBase.Controls.Add(this.BIngresar, 1, 2);
            this.TLPBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPBase.Location = new System.Drawing.Point(0, 0);
            this.TLPBase.Margin = new System.Windows.Forms.Padding(4);
            this.TLPBase.Name = "TLPBase";
            this.TLPBase.RowCount = 3;
            this.TLPBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.TLPBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.63158F));
            this.TLPBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.TLPBase.Size = new System.Drawing.Size(779, 444);
            this.TLPBase.TabIndex = 0;
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.Transparent;
            this.PHeader.Controls.Add(this.LSubtitulo);
            this.PHeader.Controls.Add(this.LTitulo);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PHeader.Location = new System.Drawing.Point(136, 4);
            this.PHeader.Margin = new System.Windows.Forms.Padding(4);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(506, 108);
            this.PHeader.TabIndex = 0;
            // 
            // LSubtitulo
            // 
            this.LSubtitulo.AutoSize = true;
            this.LSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSubtitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LSubtitulo.Location = new System.Drawing.Point(4, 76);
            this.LSubtitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LSubtitulo.Name = "LSubtitulo";
            this.LSubtitulo.Size = new System.Drawing.Size(461, 25);
            this.LSubtitulo.TabIndex = 1;
            this.LSubtitulo.Text = "Los datos de tu empresa, ordenados de la mejor manera";
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.BackColor = System.Drawing.Color.Transparent;
            this.LTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LTitulo.Location = new System.Drawing.Point(146, 22);
            this.LTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(204, 54);
            this.LTitulo.TabIndex = 0;
            this.LTitulo.Text = "Arima ERP";
            // 
            // TLPBody
            // 
            this.TLPBody.ColumnCount = 3;
            this.TLPBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TLPBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPBody.Controls.Add(this.PBody, 1, 0);
            this.TLPBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPBody.Location = new System.Drawing.Point(136, 120);
            this.TLPBody.Margin = new System.Windows.Forms.Padding(4);
            this.TLPBody.Name = "TLPBody";
            this.TLPBody.RowCount = 1;
            this.TLPBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.TLPBody.Size = new System.Drawing.Size(506, 225);
            this.TLPBody.TabIndex = 1;
            // 
            // PBody
            // 
            this.PBody.Controls.Add(this.CMostrar);
            this.PBody.Controls.Add(this.TContrasena);
            this.PBody.Controls.Add(this.LContraseña);
            this.PBody.Controls.Add(this.TCorreo);
            this.PBody.Controls.Add(this.LCorreo);
            this.PBody.Location = new System.Drawing.Point(105, 4);
            this.PBody.Margin = new System.Windows.Forms.Padding(4);
            this.PBody.Name = "PBody";
            this.PBody.Size = new System.Drawing.Size(295, 217);
            this.PBody.TabIndex = 0;
            // 
            // CMostrar
            // 
            this.CMostrar.AutoSize = true;
            this.CMostrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CMostrar.Location = new System.Drawing.Point(100, 175);
            this.CMostrar.Margin = new System.Windows.Forms.Padding(4);
            this.CMostrar.Name = "CMostrar";
            this.CMostrar.Size = new System.Drawing.Size(74, 20);
            this.CMostrar.TabIndex = 4;
            this.CMostrar.Text = "Mostrar";
            this.CMostrar.UseVisualStyleBackColor = true;
            this.CMostrar.CheckedChanged += new System.EventHandler(this.CMostrar_CheckedChanged);
            // 
            // TContrasena
            // 
            this.TContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TContrasena.Location = new System.Drawing.Point(4, 143);
            this.TContrasena.Margin = new System.Windows.Forms.Padding(4);
            this.TContrasena.Name = "TContrasena";
            this.TContrasena.Size = new System.Drawing.Size(285, 30);
            this.TContrasena.TabIndex = 3;
            this.TContrasena.UseSystemPasswordChar = true;
            // 
            // LContraseña
            // 
            this.LContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LContraseña.AutoSize = true;
            this.LContraseña.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContraseña.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LContraseña.Location = new System.Drawing.Point(72, 101);
            this.LContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LContraseña.Name = "LContraseña";
            this.LContraseña.Size = new System.Drawing.Size(156, 38);
            this.LContraseña.TabIndex = 2;
            this.LContraseña.Text = "Contraseña";
            this.LContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TCorreo
            // 
            this.TCorreo.BackColor = System.Drawing.SystemColors.Window;
            this.TCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCorreo.Location = new System.Drawing.Point(4, 57);
            this.TCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.TCorreo.Name = "TCorreo";
            this.TCorreo.Size = new System.Drawing.Size(285, 30);
            this.TCorreo.TabIndex = 1;
            // 
            // LCorreo
            // 
            this.LCorreo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LCorreo.AutoSize = true;
            this.LCorreo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCorreo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LCorreo.Location = new System.Drawing.Point(93, 15);
            this.LCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(101, 38);
            this.LCorreo.TabIndex = 0;
            this.LCorreo.Text = "Correo";
            this.LCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BIngresar
            // 
            this.BIngresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BIngresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BIngresar.Location = new System.Drawing.Point(309, 372);
            this.BIngresar.Margin = new System.Windows.Forms.Padding(4);
            this.BIngresar.Name = "BIngresar";
            this.BIngresar.Size = new System.Drawing.Size(160, 49);
            this.BIngresar.TabIndex = 2;
            this.BIngresar.Text = "Iniciar Sesión";
            this.BIngresar.UseVisualStyleBackColor = true;
            this.BIngresar.Click += new System.EventHandler(this.BIngresar_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.BIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(779, 444);
            this.Controls.Add(this.TLPBase);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arima ERP - Login";
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            this.TLPBase.ResumeLayout(false);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.TLPBody.ResumeLayout(false);
            this.PBody.ResumeLayout(false);
            this.PBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPBase;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LSubtitulo;
        private System.Windows.Forms.TableLayoutPanel TLPBody;
        private System.Windows.Forms.Panel PBody;
        private System.Windows.Forms.Label LCorreo;
        private System.Windows.Forms.TextBox TCorreo;
        private System.Windows.Forms.CheckBox CMostrar;
        private System.Windows.Forms.TextBox TContrasena;
        private System.Windows.Forms.Label LContraseña;
        private System.Windows.Forms.Button BIngresar;
    }
}