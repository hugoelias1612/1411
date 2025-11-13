namespace ArimaERP.EmpleadoProducto
{
    partial class FormAlerta
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
            this.TLPBase = new System.Windows.Forms.TableLayoutPanel();
            this.TLPHeader = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CbOrden = new System.Windows.Forms.ComboBox();
            this.lblMenorUmbral = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NStockMax = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxUmbral = new System.Windows.Forms.CheckBox();
            this.TNombreContiene = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CbFamilia = new System.Windows.Forms.ComboBox();
            this.CbProveedor = new System.Windows.Forms.ComboBox();
            this.LProveedor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TLPFooter = new System.Windows.Forms.TableLayoutPanel();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.BBuscar = new System.Windows.Forms.Button();
            this.BComprar = new System.Windows.Forms.Button();
            this.TLPGrid = new System.Windows.Forms.TableLayoutPanel();
            this.DGResultados = new System.Windows.Forms.DataGridView();
            this.ColumnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUStockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PEstado = new System.Windows.Forms.Panel();
            this.LEstado = new System.Windows.Forms.Label();
            this.TLPBase.SuspendLayout();
            this.TLPHeader.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NStockMax)).BeginInit();
            this.TLPFooter.SuspendLayout();
            this.TLPGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).BeginInit();
            this.PEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLPBase
            // 
            this.TLPBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TLPBase.ColumnCount = 1;
            this.TLPBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPBase.Controls.Add(this.TLPHeader, 0, 0);
            this.TLPBase.Controls.Add(this.TLPFooter, 0, 2);
            this.TLPBase.Controls.Add(this.TLPGrid, 0, 1);
            this.TLPBase.Location = new System.Drawing.Point(0, 0);
            this.TLPBase.Name = "TLPBase";
            this.TLPBase.RowCount = 3;
            this.TLPBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLPBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.TLPBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLPBase.Size = new System.Drawing.Size(1264, 569);
            this.TLPBase.TabIndex = 0;
            // 
            // TLPHeader
            // 
            this.TLPHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TLPHeader.ColumnCount = 1;
            this.TLPHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPHeader.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.TLPHeader.Controls.Add(this.label1, 0, 0);
            this.TLPHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPHeader.Location = new System.Drawing.Point(0, 0);
            this.TLPHeader.Margin = new System.Windows.Forms.Padding(0);
            this.TLPHeader.Name = "TLPHeader";
            this.TLPHeader.RowCount = 2;
            this.TLPHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.27586F));
            this.TLPHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.72414F));
            this.TLPHeader.Size = new System.Drawing.Size(1264, 113);
            this.TLPHeader.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.CbOrden, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblMenorUmbral, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.NStockMax, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.CheckBoxUmbral, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.TNombreContiene, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label12, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.CbFamilia, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.CbProveedor, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.LProveedor, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 54);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.26087F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.73913F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1264, 59);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // CbOrden
            // 
            this.CbOrden.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbOrden.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbOrden.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbOrden.FormattingEnabled = true;
            this.CbOrden.Items.AddRange(new object[] {
            "Stock",
            "Precio",
            "Nombre"});
            this.CbOrden.Location = new System.Drawing.Point(887, 34);
            this.CbOrden.Name = "CbOrden";
            this.CbOrden.Size = new System.Drawing.Size(115, 27);
            this.CbOrden.TabIndex = 15;
            // 
            // lblMenorUmbral
            // 
            this.lblMenorUmbral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMenorUmbral.AutoSize = true;
            this.lblMenorUmbral.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenorUmbral.Location = new System.Drawing.Point(761, 0);
            this.lblMenorUmbral.Name = "lblMenorUmbral";
            this.lblMenorUmbral.Size = new System.Drawing.Size(116, 31);
            this.lblMenorUmbral.TabIndex = 6;
            this.lblMenorUmbral.Text = "Insuficiente";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(635, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 31);
            this.label8.TabIndex = 5;
            this.label8.Text = "StockMax";
            // 
            // NStockMax
            // 
            this.NStockMax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NStockMax.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NStockMax.Location = new System.Drawing.Point(665, 34);
            this.NStockMax.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.NStockMax.Name = "NStockMax";
            this.NStockMax.Size = new System.Drawing.Size(56, 26);
            this.NStockMax.TabIndex = 16;
            this.NStockMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // CheckBoxUmbral
            // 
            this.CheckBoxUmbral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckBoxUmbral.AutoSize = true;
            this.CheckBoxUmbral.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxUmbral.Location = new System.Drawing.Point(759, 34);
            this.CheckBoxUmbral.Name = "CheckBoxUmbral";
            this.CheckBoxUmbral.Size = new System.Drawing.Size(120, 22);
            this.CheckBoxUmbral.TabIndex = 17;
            this.CheckBoxUmbral.Text = "Stock < Umbral ";
            this.CheckBoxUmbral.UseVisualStyleBackColor = true;
            // 
            // TNombreContiene
            // 
            this.TNombreContiene.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TNombreContiene.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TNombreContiene.Location = new System.Drawing.Point(507, 34);
            this.TNombreContiene.Name = "TNombreContiene";
            this.TNombreContiene.Size = new System.Drawing.Size(120, 26);
            this.TNombreContiene.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(899, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 31);
            this.label12.TabIndex = 7;
            this.label12.Text = "Criterio";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(516, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 31);
            this.label9.TabIndex = 4;
            this.label9.Text = "Nombre";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(397, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 31);
            this.label11.TabIndex = 0;
            this.label11.Text = "Familia";
            // 
            // CbFamilia
            // 
            this.CbFamilia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbFamilia.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFamilia.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbFamilia.FormattingEnabled = true;
            this.CbFamilia.Location = new System.Drawing.Point(381, 34);
            this.CbFamilia.Name = "CbFamilia";
            this.CbFamilia.Size = new System.Drawing.Size(120, 27);
            this.CbFamilia.TabIndex = 1;
            // 
            // CbProveedor
            // 
            this.CbProveedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbProveedor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbProveedor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbProveedor.FormattingEnabled = true;
            this.CbProveedor.Location = new System.Drawing.Point(255, 34);
            this.CbProveedor.Name = "CbProveedor";
            this.CbProveedor.Size = new System.Drawing.Size(120, 27);
            this.CbProveedor.TabIndex = 11;
            this.CbProveedor.Visible = false;
            // 
            // LProveedor
            // 
            this.LProveedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LProveedor.AutoSize = true;
            this.LProveedor.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProveedor.Location = new System.Drawing.Point(257, 0);
            this.LProveedor.Name = "LProveedor";
            this.LProveedor.Size = new System.Drawing.Size(115, 31);
            this.LProveedor.TabIndex = 3;
            this.LProveedor.Text = "Proveedor";
            this.LProveedor.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(425, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 54);
            this.label1.TabIndex = 7;
            this.label1.Text = "Control de stock bajo ";
            // 
            // TLPFooter
            // 
            this.TLPFooter.AutoSize = true;
            this.TLPFooter.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TLPFooter.ColumnCount = 5;
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.35294F));
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.76471F));
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.76471F));
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.76471F));
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.35294F));
            this.TLPFooter.Controls.Add(this.BLimpiar, 2, 0);
            this.TLPFooter.Controls.Add(this.BBuscar, 1, 0);
            this.TLPFooter.Controls.Add(this.BComprar, 3, 0);
            this.TLPFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPFooter.Location = new System.Drawing.Point(0, 482);
            this.TLPFooter.Margin = new System.Windows.Forms.Padding(0);
            this.TLPFooter.Name = "TLPFooter";
            this.TLPFooter.RowCount = 1;
            this.TLPFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPFooter.Size = new System.Drawing.Size(1264, 87);
            this.TLPFooter.TabIndex = 1;
            // 
            // BLimpiar
            // 
            this.BLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BLimpiar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.ForeColor = System.Drawing.SystemColors.Window;
            this.BLimpiar.Location = new System.Drawing.Point(580, 29);
            this.BLimpiar.Margin = new System.Windows.Forms.Padding(0);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(100, 28);
            this.BLimpiar.TabIndex = 2;
            this.BLimpiar.Text = "Limpiar";
            this.BLimpiar.UseVisualStyleBackColor = false;
            this.BLimpiar.Click += new System.EventHandler(this.BLimpiar_Click);
            // 
            // BBuscar
            // 
            this.BBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BBuscar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.ForeColor = System.Drawing.SystemColors.Window;
            this.BBuscar.Location = new System.Drawing.Point(432, 29);
            this.BBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(100, 28);
            this.BBuscar.TabIndex = 0;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // BComprar
            // 
            this.BComprar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BComprar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BComprar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BComprar.ForeColor = System.Drawing.SystemColors.Window;
            this.BComprar.Location = new System.Drawing.Point(725, 30);
            this.BComprar.Margin = new System.Windows.Forms.Padding(0);
            this.BComprar.Name = "BComprar";
            this.BComprar.Size = new System.Drawing.Size(105, 27);
            this.BComprar.TabIndex = 3;
            this.BComprar.Text = "Comprar";
            this.BComprar.UseCompatibleTextRendering = true;
            this.BComprar.UseVisualStyleBackColor = false;
            // 
            // TLPGrid
            // 
            this.TLPGrid.ColumnCount = 1;
            this.TLPGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGrid.Controls.Add(this.DGResultados, 0, 0);
            this.TLPGrid.Controls.Add(this.PEstado, 0, 1);
            this.TLPGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGrid.Location = new System.Drawing.Point(0, 113);
            this.TLPGrid.Margin = new System.Windows.Forms.Padding(0);
            this.TLPGrid.Name = "TLPGrid";
            this.TLPGrid.RowCount = 2;
            this.TLPGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.TLPGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLPGrid.Size = new System.Drawing.Size(1264, 369);
            this.TLPGrid.TabIndex = 2;
            // 
            // DGResultados
            // 
            this.DGResultados.AllowUserToAddRows = false;
            this.DGResultados.AllowUserToDeleteRows = false;
            this.DGResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGResultados.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DGResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaNombre,
            this.CFamilia,
            this.Proveedor,
            this.Precio,
            this.Stock,
            this.CUStockMinimo});
            this.DGResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGResultados.EnableHeadersVisualStyles = false;
            this.DGResultados.Location = new System.Drawing.Point(0, 10);
            this.DGResultados.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.DGResultados.Name = "DGResultados";
            this.DGResultados.ReadOnly = true;
            this.DGResultados.RowHeadersVisible = false;
            this.DGResultados.RowHeadersWidth = 51;
            this.DGResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGResultados.Size = new System.Drawing.Size(1264, 322);
            this.DGResultados.TabIndex = 0;
            // 
            // ColumnaNombre
            // 
            this.ColumnaNombre.DataPropertyName = "Producto";
            this.ColumnaNombre.FillWeight = 220F;
            this.ColumnaNombre.HeaderText = "Producto";
            this.ColumnaNombre.MinimumWidth = 6;
            this.ColumnaNombre.Name = "ColumnaNombre";
            this.ColumnaNombre.ReadOnly = true;
            // 
            // CFamilia
            // 
            this.CFamilia.DataPropertyName = "Familia";
            this.CFamilia.FillWeight = 120F;
            this.CFamilia.HeaderText = "Familia";
            this.CFamilia.MinimumWidth = 6;
            this.CFamilia.Name = "CFamilia";
            this.CFamilia.ReadOnly = true;
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "Proveedor";
            this.Proveedor.FillWeight = 120F;
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.MinimumWidth = 6;
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.FillWeight = 90F;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            this.Stock.FillWeight = 70F;
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // CUStockMinimo
            // 
            this.CUStockMinimo.DataPropertyName = "StockMinimo";
            this.CUStockMinimo.FillWeight = 90F;
            this.CUStockMinimo.HeaderText = "StockMinimo";
            this.CUStockMinimo.MinimumWidth = 6;
            this.CUStockMinimo.Name = "CUStockMinimo";
            this.CUStockMinimo.ReadOnly = true;
            // 
            // PEstado
            // 
            this.PEstado.AutoSize = true;
            this.PEstado.Controls.Add(this.LEstado);
            this.PEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PEstado.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PEstado.Location = new System.Drawing.Point(3, 335);
            this.PEstado.Name = "PEstado";
            this.PEstado.Padding = new System.Windows.Forms.Padding(4);
            this.PEstado.Size = new System.Drawing.Size(1258, 31);
            this.PEstado.TabIndex = 1;
            // 
            // LEstado
            // 
            this.LEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.LEstado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEstado.Location = new System.Drawing.Point(4, 4);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(1250, 25);
            this.LEstado.TabIndex = 0;
            this.LEstado.Text = "0 Productos";
            this.LEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LEstado.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // FormAlerta
            // 
            this.AcceptButton = this.BBuscar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1264, 569);
            this.Controls.Add(this.TLPBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAlerta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormAlerta";
            this.Load += new System.EventHandler(this.FormAlerta_Load);
            this.TLPBase.ResumeLayout(false);
            this.TLPBase.PerformLayout();
            this.TLPHeader.ResumeLayout(false);
            this.TLPHeader.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NStockMax)).EndInit();
            this.TLPFooter.ResumeLayout(false);
            this.TLPGrid.ResumeLayout(false);
            this.TLPGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).EndInit();
            this.PEstado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPBase;
        private System.Windows.Forms.TableLayoutPanel TLPFooter;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Button BComprar;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.TableLayoutPanel TLPHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox CbOrden;
        private System.Windows.Forms.ComboBox CbProveedor;
        private System.Windows.Forms.Label lblMenorUmbral;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LProveedor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CbFamilia;
        private System.Windows.Forms.NumericUpDown NStockMax;
        private System.Windows.Forms.CheckBox CheckBoxUmbral;
        private System.Windows.Forms.TextBox TNombreContiene;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel TLPGrid;
        private System.Windows.Forms.DataGridView DGResultados;
        private System.Windows.Forms.Panel PEstado;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUStockMinimo;
    }
}