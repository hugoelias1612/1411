namespace ArimaERP.Administrador
{
    partial class FormAuditoria
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelAuditoria = new System.Windows.Forms.TableLayoutPanel();
            this.lblAuditorias = new System.Windows.Forms.Label();
            this.dgvAuditoria = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.comboBoxAccion = new System.Windows.Forms.ComboBox();
            this.lblAccion = new System.Windows.Forms.Label();
            this.comboBoxEntidad = new System.Windows.Forms.ComboBox();
            this.lblEntidad = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBuscarxFecha = new System.Windows.Forms.Button();
            this.tableLayoutPanelAuditoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelAuditoria
            // 
            this.tableLayoutPanelAuditoria.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanelAuditoria.ColumnCount = 3;
            this.tableLayoutPanelAuditoria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelAuditoria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelAuditoria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelAuditoria.Controls.Add(this.lblAuditorias, 1, 0);
            this.tableLayoutPanelAuditoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelAuditoria.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelAuditoria.Name = "tableLayoutPanelAuditoria";
            this.tableLayoutPanelAuditoria.RowCount = 1;
            this.tableLayoutPanelAuditoria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAuditoria.Size = new System.Drawing.Size(1469, 60);
            this.tableLayoutPanelAuditoria.TabIndex = 0;
            // 
            // lblAuditorias
            // 
            this.lblAuditorias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAuditorias.AutoSize = true;
            this.lblAuditorias.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditorias.Location = new System.Drawing.Point(674, 14);
            this.lblAuditorias.Name = "lblAuditorias";
            this.lblAuditorias.Size = new System.Drawing.Size(119, 31);
            this.lblAuditorias.TabIndex = 0;
            this.lblAuditorias.Text = "Auditorias";
            // 
            // dgvAuditoria
            // 
            this.dgvAuditoria.AllowUserToAddRows = false;
            this.dgvAuditoria.AllowUserToResizeRows = false;
            this.dgvAuditoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAuditoria.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoria.Location = new System.Drawing.Point(32, 189);
            this.dgvAuditoria.Name = "dgvAuditoria";
            this.dgvAuditoria.ReadOnly = true;
            this.dgvAuditoria.RowHeadersVisible = false;
            this.dgvAuditoria.RowHeadersWidth = 51;
            this.dgvAuditoria.RowTemplate.Height = 24;
            this.dgvAuditoria.Size = new System.Drawing.Size(1409, 505);
            this.dgvAuditoria.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerHasta, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaDesde, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxAccion, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAccion, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxEntidad, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblEntidad, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUsuario, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUsuario, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaHasta, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerDesde, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarxFecha, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(136, 67);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1195, 100);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerHasta.Location = new System.Drawing.Point(600, 58);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(193, 34);
            this.dateTimePickerHasta.TabIndex = 9;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(39, 61);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(121, 28);
            this.lblFechaDesde.TabIndex = 6;
            this.lblFechaDesde.Text = "Fecha Desde";
            // 
            // comboBoxAccion
            // 
            this.comboBoxAccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxAccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAccion.FormattingEnabled = true;
            this.comboBoxAccion.Location = new System.Drawing.Point(600, 3);
            this.comboBoxAccion.Name = "comboBoxAccion";
            this.comboBoxAccion.Size = new System.Drawing.Size(193, 36);
            this.comboBoxAccion.TabIndex = 4;
            this.comboBoxAccion.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccion_SelectedIndexChanged);
            // 
            // lblAccion
            // 
            this.lblAccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAccion.AutoSize = true;
            this.lblAccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccion.Location = new System.Drawing.Point(410, 11);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(175, 28);
            this.lblAccion.TabIndex = 2;
            this.lblAccion.Text = "Seleccionar Acción";
            // 
            // comboBoxEntidad
            // 
            this.comboBoxEntidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxEntidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEntidad.FormattingEnabled = true;
            this.comboBoxEntidad.Location = new System.Drawing.Point(202, 3);
            this.comboBoxEntidad.Name = "comboBoxEntidad";
            this.comboBoxEntidad.Size = new System.Drawing.Size(193, 36);
            this.comboBoxEntidad.TabIndex = 0;
            this.comboBoxEntidad.SelectedIndexChanged += new System.EventHandler(this.comboBoxEntidad_SelectedIndexChanged);
            // 
            // lblEntidad
            // 
            this.lblEntidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntidad.Location = new System.Drawing.Point(8, 11);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(183, 28);
            this.lblEntidad.TabIndex = 1;
            this.lblEntidad.Text = "Seleccionar Entidad";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(818, 11);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(154, 28);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Ingresar Usuario";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsuario.Location = new System.Drawing.Point(998, 3);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(194, 34);
            this.textBoxUsuario.TabIndex = 5;
            this.textBoxUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUsuario_KeyDown);
            this.textBoxUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUsuario_KeyPress);
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(442, 61);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(111, 28);
            this.lblFechaHasta.TabIndex = 7;
            this.lblFechaHasta.Text = "FechaHasta";
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDesde.Location = new System.Drawing.Point(202, 58);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(193, 34);
            this.dateTimePickerDesde.TabIndex = 8;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnBuscarxFecha
            // 
            this.btnBuscarxFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscarxFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarxFecha.Location = new System.Drawing.Point(799, 53);
            this.btnBuscarxFecha.Name = "btnBuscarxFecha";
            this.btnBuscarxFecha.Size = new System.Drawing.Size(193, 44);
            this.btnBuscarxFecha.TabIndex = 10;
            this.btnBuscarxFecha.Text = "Buscar Periodo";
            this.btnBuscarxFecha.UseVisualStyleBackColor = true;
            this.btnBuscarxFecha.Click += new System.EventHandler(this.btnBuscarxFecha_Click);
            // 
            // FormAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 742);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvAuditoria);
            this.Controls.Add(this.tableLayoutPanelAuditoria);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAuditoria";
            this.Text = "Auditoria";
            this.Load += new System.EventHandler(this.FormAuditoria_Load);
            this.tableLayoutPanelAuditoria.ResumeLayout(false);
            this.tableLayoutPanelAuditoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAuditoria;
        private System.Windows.Forms.Label lblAuditorias;
        protected internal System.Windows.Forms.DataGridView dgvAuditoria;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.ComboBox comboBoxAccion;
        private System.Windows.Forms.Label lblAccion;
        private System.Windows.Forms.ComboBox comboBoxEntidad;
        private System.Windows.Forms.Label lblEntidad;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnBuscarxFecha;
    }
}