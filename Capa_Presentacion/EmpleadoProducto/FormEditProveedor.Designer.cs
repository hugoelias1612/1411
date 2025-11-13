namespace ArimaERP.EmpleadoProducto
{
    partial class FormEditProveedor
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
            this.cbxProveedores = new System.Windows.Forms.ComboBox();
            this.lblEditar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxProveedores
            // 
            this.cbxProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProveedores.FormattingEnabled = true;
            this.cbxProveedores.Location = new System.Drawing.Point(51, 47);
            this.cbxProveedores.Name = "cbxProveedores";
            this.cbxProveedores.Size = new System.Drawing.Size(259, 21);
            this.cbxProveedores.TabIndex = 0;
            // 
            // lblEditar
            // 
            this.lblEditar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEditar.Location = new System.Drawing.Point(146, 91);
            this.lblEditar.Name = "lblEditar";
            this.lblEditar.Size = new System.Drawing.Size(75, 23);
            this.lblEditar.TabIndex = 1;
            this.lblEditar.Text = "Editar";
            this.lblEditar.UseVisualStyleBackColor = false;
            this.lblEditar.Click += new System.EventHandler(this.lblEditar_Click);
            // 
            // FormEditProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 137);
            this.Controls.Add(this.lblEditar);
            this.Controls.Add(this.cbxProveedores);
            this.Name = "FormEditProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccione el proveedor a editar.";
            this.Load += new System.EventHandler(this.FormEditProveedor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxProveedores;
        private System.Windows.Forms.Button lblEditar;
    }
}