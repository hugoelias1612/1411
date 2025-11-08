namespace ArimaERP.Administrador
{
    partial class FormReportes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxGrafico = new System.Windows.Forms.GroupBox();
            this.tabGraficos = new System.Windows.Forms.TabControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.lblMes = new System.Windows.Forms.Label();
            this.dateTimePickerMes = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewDatos = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbxGrafico.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gbxGrafico, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewDatos, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 424F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1672, 814);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(664, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Reporte de ventas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxGrafico
            // 
            this.gbxGrafico.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxGrafico.Controls.Add(this.dateTimePickerMes);
            this.gbxGrafico.Controls.Add(this.tabGraficos);
            this.gbxGrafico.Controls.Add(this.lblMes);
            this.gbxGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxGrafico.Location = new System.Drawing.Point(4, 60);
            this.gbxGrafico.Margin = new System.Windows.Forms.Padding(4);
            this.gbxGrafico.Name = "gbxGrafico";
            this.gbxGrafico.Padding = new System.Windows.Forms.Padding(4);
            this.gbxGrafico.Size = new System.Drawing.Size(1664, 416);
            this.gbxGrafico.TabIndex = 0;
            this.gbxGrafico.TabStop = false;
            this.gbxGrafico.Text = "Analisis Gráfico";
            // 
            // tabGraficos
            // 
            this.tabGraficos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabGraficos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabGraficos.Location = new System.Drawing.Point(4, 67);
            this.tabGraficos.Margin = new System.Windows.Forms.Padding(4);
            this.tabGraficos.Name = "tabGraficos";
            this.tabGraficos.SelectedIndex = 0;
            this.tabGraficos.Size = new System.Drawing.Size(1656, 341);
            this.tabGraficos.TabIndex = 0;
            this.tabGraficos.SelectedIndexChanged += new System.EventHandler(this.tabGraficos_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5122F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.19512F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.19512F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.19512F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.19512F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.19512F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5122F));
            this.tableLayoutPanel2.Controls.Add(this.button6, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExportarPDF, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExportarExcel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 732);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1664, 78);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Location = new System.Drawing.Point(1136, 17);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(194, 43);
            this.button6.TabIndex = 6;
            this.button6.Text = "Volver al Panel";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExportarPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportarPDF.Location = new System.Drawing.Point(732, 17);
            this.btnExportarPDF.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(194, 43);
            this.btnExportarPDF.TabIndex = 3;
            this.btnExportarPDF.Text = "Guardar PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportarExcel.Location = new System.Drawing.Point(328, 17);
            this.btnExportarExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(194, 43);
            this.btnExportarExcel.TabIndex = 0;
            this.btnExportarExcel.Text = "Exportar a Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(17, 31);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(186, 29);
            this.lblMes.TabIndex = 7;
            this.lblMes.Text = "Seleccione mes";
            // 
            // dateTimePickerMes
            // 
            this.dateTimePickerMes.CustomFormat = "\"MM/yyyy\"";
            this.dateTimePickerMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMes.Location = new System.Drawing.Point(284, 26);
            this.dateTimePickerMes.Name = "dateTimePickerMes";
            this.dateTimePickerMes.ShowUpDown = true;
            this.dateTimePickerMes.Size = new System.Drawing.Size(200, 34);
            this.dateTimePickerMes.TabIndex = 8;
            this.dateTimePickerMes.ValueChanged += new System.EventHandler(this.dateTimePickerMes_ValueChanged);
            // 
            // dataGridViewDatos
            // 
            this.dataGridViewDatos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridViewDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDatos.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDatos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewDatos.GridColor = System.Drawing.Color.White;
            this.dataGridViewDatos.Location = new System.Drawing.Point(441, 483);
            this.dataGridViewDatos.Name = "dataGridViewDatos";
            this.dataGridViewDatos.ReadOnly = true;
            this.dataGridViewDatos.RowHeadersVisible = false;
            this.dataGridViewDatos.RowHeadersWidth = 51;
            this.dataGridViewDatos.RowTemplate.Height = 24;
            this.dataGridViewDatos.Size = new System.Drawing.Size(790, 239);
            this.dataGridViewDatos.TabIndex = 5;
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1672, 814);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormReportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbxGrafico.ResumeLayout(false);
            this.gbxGrafico.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbxGrafico;
        private System.Windows.Forms.TabControl tabGraficos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.DateTimePicker dateTimePickerMes;
        private System.Windows.Forms.DataGridView dataGridViewDatos;
    }
}