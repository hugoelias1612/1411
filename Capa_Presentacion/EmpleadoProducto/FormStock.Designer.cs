namespace ArimaERP.EmpleadoProducto
{
    partial class FormStock
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
            this.CbProveedor = new System.Windows.Forms.ComboBox();
            this.LProveedor = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CbFamilia = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TNombreContiene = new System.Windows.Forms.TextBox();
            this.LMarca = new System.Windows.Forms.Label();
            this.CbMarca = new System.Windows.Forms.ComboBox();
            this.BFiltrar = new System.Windows.Forms.Button();
            this.BVertodos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TLPFooter = new System.Windows.Forms.TableLayoutPanel();
            this.BHistorial = new System.Windows.Forms.Button();
            this.BMasvendidos = new System.Windows.Forms.Button();
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
            this.TLPBase.Location = new System.Drawing.Point(1, 0);
            this.TLPBase.Name = "TLPBase";
            this.TLPBase.RowCount = 3;
            this.TLPBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TLPBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLPBase.Size = new System.Drawing.Size(1265, 571);
            this.TLPBase.TabIndex = 1;
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
            this.TLPHeader.Size = new System.Drawing.Size(1265, 142);
            this.TLPHeader.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.62846F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.93676F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.09881F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.16996F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.616601F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.47036F));
            this.tableLayoutPanel2.Controls.Add(this.CbProveedor, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.LProveedor, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.CbFamilia, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.TNombreContiene, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.LMarca, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.CbMarca, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.BFiltrar, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.BVertodos, 5, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 68);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.89189F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.10811F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1265, 74);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // CbProveedor
            // 
            this.CbProveedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbProveedor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbProveedor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbProveedor.FormattingEnabled = true;
            this.CbProveedor.Location = new System.Drawing.Point(377, 42);
            this.CbProveedor.Name = "CbProveedor";
            this.CbProveedor.Size = new System.Drawing.Size(120, 21);
            this.CbProveedor.TabIndex = 11;
            this.CbProveedor.Visible = false;
            // 
            // LProveedor
            // 
            this.LProveedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LProveedor.AutoSize = true;
            this.LProveedor.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProveedor.Location = new System.Drawing.Point(387, 3);
            this.LProveedor.Name = "LProveedor";
            this.LProveedor.Size = new System.Drawing.Size(99, 25);
            this.LProveedor.TabIndex = 3;
            this.LProveedor.Text = "Proveedor";
            this.LProveedor.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(263, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 25);
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
            this.CbFamilia.Location = new System.Drawing.Point(238, 42);
            this.CbFamilia.Name = "CbFamilia";
            this.CbFamilia.Size = new System.Drawing.Size(120, 21);
            this.CbFamilia.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(681, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "Nombre";
            // 
            // TNombreContiene
            // 
            this.TNombreContiene.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TNombreContiene.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TNombreContiene.Location = new System.Drawing.Point(639, 41);
            this.TNombreContiene.Name = "TNombreContiene";
            this.TNombreContiene.Size = new System.Drawing.Size(165, 22);
            this.TNombreContiene.TabIndex = 18;
            // 
            // LMarca
            // 
            this.LMarca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LMarca.AutoSize = true;
            this.LMarca.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMarca.Location = new System.Drawing.Point(530, 3);
            this.LMarca.Name = "LMarca";
            this.LMarca.Size = new System.Drawing.Size(65, 25);
            this.LMarca.TabIndex = 19;
            this.LMarca.Text = "Marca";
            // 
            // CbMarca
            // 
            this.CbMarca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbMarca.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMarca.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbMarca.FormattingEnabled = true;
            this.CbMarca.Location = new System.Drawing.Point(503, 42);
            this.CbMarca.Name = "CbMarca";
            this.CbMarca.Size = new System.Drawing.Size(120, 21);
            this.CbMarca.TabIndex = 20;
            // 
            // BFiltrar
            // 
            this.BFiltrar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BFiltrar.BackColor = System.Drawing.Color.LightSlateGray;
            this.BFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BFiltrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BFiltrar.Location = new System.Drawing.Point(943, 36);
            this.BFiltrar.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.BFiltrar.Name = "BFiltrar";
            this.BFiltrar.Size = new System.Drawing.Size(96, 32);
            this.BFiltrar.TabIndex = 23;
            this.BFiltrar.Text = "Filtrar 🔍";
            this.BFiltrar.UseVisualStyleBackColor = false;
            // 
            // BVertodos
            // 
            this.BVertodos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BVertodos.BackColor = System.Drawing.Color.LightSlateGray;
            this.BVertodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVertodos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVertodos.Location = new System.Drawing.Point(827, 36);
            this.BVertodos.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.BVertodos.Name = "BVertodos";
            this.BVertodos.Size = new System.Drawing.Size(103, 32);
            this.BVertodos.TabIndex = 24;
            this.BVertodos.Text = "Ver todos";
            this.BVertodos.UseVisualStyleBackColor = false;
            this.BVertodos.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(502, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 45);
            this.label1.TabIndex = 7;
            this.label1.Text = "Gestion de Stock";
            // 
            // TLPFooter
            // 
            this.TLPFooter.AutoSize = true;
            this.TLPFooter.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TLPFooter.ColumnCount = 7;
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLPFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLPFooter.Controls.Add(this.BHistorial, 4, 0);
            this.TLPFooter.Controls.Add(this.BBuscar, 1, 0);
            this.TLPFooter.Controls.Add(this.BComprar, 5, 0);
            this.TLPFooter.Controls.Add(this.BMasvendidos, 3, 0);
            this.TLPFooter.Controls.Add(this.BLimpiar, 2, 0);
            this.TLPFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPFooter.Location = new System.Drawing.Point(0, 484);
            this.TLPFooter.Margin = new System.Windows.Forms.Padding(0);
            this.TLPFooter.Name = "TLPFooter";
            this.TLPFooter.RowCount = 1;
            this.TLPFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPFooter.Size = new System.Drawing.Size(1265, 87);
            this.TLPFooter.TabIndex = 1;
            // 
            // BHistorial
            // 
            this.BHistorial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BHistorial.BackColor = System.Drawing.Color.LightSlateGray;
            this.BHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BHistorial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BHistorial.ForeColor = System.Drawing.SystemColors.Window;
            this.BHistorial.Location = new System.Drawing.Point(737, 29);
            this.BHistorial.Margin = new System.Windows.Forms.Padding(0);
            this.BHistorial.Name = "BHistorial";
            this.BHistorial.Size = new System.Drawing.Size(165, 28);
            this.BHistorial.TabIndex = 6;
            this.BHistorial.Text = "Historial de ingresos";
            this.BHistorial.UseVisualStyleBackColor = false;
            this.BHistorial.Visible = false;
            // 
            // BMasvendidos
            // 
            this.BMasvendidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BMasvendidos.BackColor = System.Drawing.Color.LightSlateGray;
            this.BMasvendidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMasvendidos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BMasvendidos.ForeColor = System.Drawing.SystemColors.Window;
            this.BMasvendidos.Location = new System.Drawing.Point(548, 29);
            this.BMasvendidos.Margin = new System.Windows.Forms.Padding(0);
            this.BMasvendidos.Name = "BMasvendidos";
            this.BMasvendidos.Size = new System.Drawing.Size(165, 28);
            this.BMasvendidos.TabIndex = 5;
            this.BMasvendidos.Text = "Ver productos mas vendidos";
            this.BMasvendidos.UseVisualStyleBackColor = false;
            this.BMasvendidos.Visible = false;
            // 
            // BLimpiar
            // 
            this.BLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BLimpiar.BackColor = System.Drawing.Color.LightSlateGray;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.ForeColor = System.Drawing.SystemColors.Window;
            this.BLimpiar.Location = new System.Drawing.Point(359, 29);
            this.BLimpiar.Margin = new System.Windows.Forms.Padding(0);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(165, 28);
            this.BLimpiar.TabIndex = 2;
            this.BLimpiar.Text = "Alertas Stock Bajo";
            this.BLimpiar.UseVisualStyleBackColor = false;
            // 
            // BBuscar
            // 
            this.BBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BBuscar.BackColor = System.Drawing.Color.LightSlateGray;
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.ForeColor = System.Drawing.SystemColors.Window;
            this.BBuscar.Location = new System.Drawing.Point(202, 29);
            this.BBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(100, 28);
            this.BBuscar.TabIndex = 0;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            this.BBuscar.Visible = false;
            // 
            // BComprar
            // 
            this.BComprar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BComprar.BackColor = System.Drawing.Color.LightSlateGray;
            this.BComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BComprar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BComprar.ForeColor = System.Drawing.SystemColors.Window;
            this.BComprar.Location = new System.Drawing.Point(956, 30);
            this.BComprar.Margin = new System.Windows.Forms.Padding(0);
            this.BComprar.Name = "BComprar";
            this.BComprar.Size = new System.Drawing.Size(105, 27);
            this.BComprar.TabIndex = 3;
            this.BComprar.Text = "Comprar";
            this.BComprar.UseVisualStyleBackColor = false;
            // 
            // TLPGrid
            // 
            this.TLPGrid.ColumnCount = 1;
            this.TLPGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGrid.Controls.Add(this.DGResultados, 0, 0);
            this.TLPGrid.Controls.Add(this.PEstado, 0, 1);
            this.TLPGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGrid.Location = new System.Drawing.Point(0, 142);
            this.TLPGrid.Margin = new System.Windows.Forms.Padding(0);
            this.TLPGrid.Name = "TLPGrid";
            this.TLPGrid.RowCount = 2;
            this.TLPGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.TLPGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLPGrid.Size = new System.Drawing.Size(1265, 342);
            this.TLPGrid.TabIndex = 2;
            // 
            // DGResultados
            // 
            this.DGResultados.AllowUserToAddRows = false;
            this.DGResultados.AllowUserToDeleteRows = false;
            this.DGResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.DGResultados.Size = new System.Drawing.Size(1265, 297);
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
            this.PEstado.Location = new System.Drawing.Point(3, 310);
            this.PEstado.Name = "PEstado";
            this.PEstado.Padding = new System.Windows.Forms.Padding(4);
            this.PEstado.Size = new System.Drawing.Size(1259, 29);
            this.PEstado.TabIndex = 1;
            // 
            // LEstado
            // 
            this.LEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.LEstado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEstado.Location = new System.Drawing.Point(4, 4);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(1251, 25);
            this.LEstado.TabIndex = 0;
            this.LEstado.Text = "0 Productos";
            this.LEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 569);
            this.Controls.Add(this.TLPBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormStock";
            this.TLPBase.ResumeLayout(false);
            this.TLPBase.PerformLayout();
            this.TLPHeader.ResumeLayout(false);
            this.TLPHeader.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.TLPFooter.ResumeLayout(false);
            this.TLPGrid.ResumeLayout(false);
            this.TLPGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).EndInit();
            this.PEstado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPBase;
        private System.Windows.Forms.TableLayoutPanel TLPHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox CbProveedor;
        private System.Windows.Forms.Label LProveedor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CbFamilia;
        private System.Windows.Forms.TextBox TNombreContiene;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel TLPFooter;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Button BComprar;
        private System.Windows.Forms.TableLayoutPanel TLPGrid;
        private System.Windows.Forms.DataGridView DGResultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUStockMinimo;
        private System.Windows.Forms.Panel PEstado;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.Label LMarca;
        private System.Windows.Forms.ComboBox CbMarca;
        private System.Windows.Forms.Button BFiltrar;
        private System.Windows.Forms.Button BVertodos;
        private System.Windows.Forms.Button BHistorial;
        private System.Windows.Forms.Button BMasvendidos;
    }
}