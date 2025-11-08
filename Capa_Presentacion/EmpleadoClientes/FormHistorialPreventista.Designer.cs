namespace ArimaERP.EmpleadoClientes
{
    partial class FormHistorialPreventista
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
            this.menuStripHistorialPreventista = new System.Windows.Forms.MenuStrip();
            this.listarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noConfiablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confiablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tamañoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pequeñosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grandesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entregadosToolStripMenuItemPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.últimoMesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conSaldosPendientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saldadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canceladosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mensualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efectivoToolStripMenuItemVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaCorrienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semanalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masVendidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarPagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewHistorial = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBuscarPreventista = new System.Windows.Forms.TextBox();
            this.btnBuscarPreventista = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblNombreApellido = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblnombre_usuario = new System.Windows.Forms.Label();
            this.menuStripHistorialPreventista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorial)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripHistorialPreventista
            // 
            this.menuStripHistorialPreventista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStripHistorialPreventista.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripHistorialPreventista.Enabled = false;
            this.menuStripHistorialPreventista.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripHistorialPreventista.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripHistorialPreventista.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarClientesToolStripMenuItem,
            this.pedidosToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.pagosToolStripMenuItem});
            this.menuStripHistorialPreventista.Location = new System.Drawing.Point(616, 12);
            this.menuStripHistorialPreventista.Name = "menuStripHistorialPreventista";
            this.menuStripHistorialPreventista.Size = new System.Drawing.Size(753, 39);
            this.menuStripHistorialPreventista.TabIndex = 0;
            this.menuStripHistorialPreventista.Text = "menuStrip1";
            // 
            // listarClientesToolStripMenuItem
            // 
            this.listarClientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noConfiablesToolStripMenuItem,
            this.confiablesToolStripMenuItem,
            this.tamañoToolStripMenuItem});
            this.listarClientesToolStripMenuItem.Name = "listarClientesToolStripMenuItem";
            this.listarClientesToolStripMenuItem.Size = new System.Drawing.Size(170, 32);
            this.listarClientesToolStripMenuItem.Text = "Listar Clientes";
            this.listarClientesToolStripMenuItem.Click += new System.EventHandler(this.listarClientesToolStripMenuItem_Click);
            // 
            // noConfiablesToolStripMenuItem
            // 
            this.noConfiablesToolStripMenuItem.Name = "noConfiablesToolStripMenuItem";
            this.noConfiablesToolStripMenuItem.Size = new System.Drawing.Size(242, 36);
            this.noConfiablesToolStripMenuItem.Text = "No confiables";
            this.noConfiablesToolStripMenuItem.Click += new System.EventHandler(this.noConfiablesToolStripMenuItem_Click);
            // 
            // confiablesToolStripMenuItem
            // 
            this.confiablesToolStripMenuItem.Name = "confiablesToolStripMenuItem";
            this.confiablesToolStripMenuItem.Size = new System.Drawing.Size(242, 36);
            this.confiablesToolStripMenuItem.Text = "Confiables";
            this.confiablesToolStripMenuItem.Click += new System.EventHandler(this.confiablesToolStripMenuItem_Click);
            // 
            // tamañoToolStripMenuItem
            // 
            this.tamañoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pequeñosToolStripMenuItem,
            this.medianosToolStripMenuItem,
            this.grandesToolStripMenuItem});
            this.tamañoToolStripMenuItem.Name = "tamañoToolStripMenuItem";
            this.tamañoToolStripMenuItem.Size = new System.Drawing.Size(242, 36);
            this.tamañoToolStripMenuItem.Text = "Tamaño";
            // 
            // pequeñosToolStripMenuItem
            // 
            this.pequeñosToolStripMenuItem.Name = "pequeñosToolStripMenuItem";
            this.pequeñosToolStripMenuItem.Size = new System.Drawing.Size(209, 36);
            this.pequeñosToolStripMenuItem.Text = "Pequeños";
            this.pequeñosToolStripMenuItem.Click += new System.EventHandler(this.pequeñosToolStripMenuItem_Click);
            // 
            // medianosToolStripMenuItem
            // 
            this.medianosToolStripMenuItem.Name = "medianosToolStripMenuItem";
            this.medianosToolStripMenuItem.Size = new System.Drawing.Size(209, 36);
            this.medianosToolStripMenuItem.Text = "Medianos ";
            this.medianosToolStripMenuItem.Click += new System.EventHandler(this.medianosToolStripMenuItem_Click);
            // 
            // grandesToolStripMenuItem
            // 
            this.grandesToolStripMenuItem.Name = "grandesToolStripMenuItem";
            this.grandesToolStripMenuItem.Size = new System.Drawing.Size(209, 36);
            this.grandesToolStripMenuItem.Text = "Grandes";
            this.grandesToolStripMenuItem.Click += new System.EventHandler(this.grandesToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendientesToolStripMenuItem,
            this.entregadosToolStripMenuItemPedidos,
            this.conSaldosPendientesToolStripMenuItem,
            this.saldadosToolStripMenuItem,
            this.canceladosToolStripMenuItem});
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(109, 35);
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            this.pedidosToolStripMenuItem.Click += new System.EventHandler(this.pedidosToolStripMenuItem_Click);
            // 
            // pendientesToolStripMenuItem
            // 
            this.pendientesToolStripMenuItem.Name = "pendientesToolStripMenuItem";
            this.pendientesToolStripMenuItem.Size = new System.Drawing.Size(331, 36);
            this.pendientesToolStripMenuItem.Text = "Pendientes";
            this.pendientesToolStripMenuItem.Click += new System.EventHandler(this.pendientesToolStripMenuItem_Click);
            // 
            // entregadosToolStripMenuItemPedidos
            // 
            this.entregadosToolStripMenuItemPedidos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.últimoMesToolStripMenuItem});
            this.entregadosToolStripMenuItemPedidos.Name = "entregadosToolStripMenuItemPedidos";
            this.entregadosToolStripMenuItemPedidos.Size = new System.Drawing.Size(331, 36);
            this.entregadosToolStripMenuItemPedidos.Text = "Entregados";
            this.entregadosToolStripMenuItemPedidos.Click += new System.EventHandler(this.entregadosToolStripMenuItem_Click);
            // 
            // últimoMesToolStripMenuItem
            // 
            this.últimoMesToolStripMenuItem.Name = "últimoMesToolStripMenuItem";
            this.últimoMesToolStripMenuItem.Size = new System.Drawing.Size(220, 36);
            this.últimoMesToolStripMenuItem.Text = "Último Mes";
            // 
            // conSaldosPendientesToolStripMenuItem
            // 
            this.conSaldosPendientesToolStripMenuItem.Name = "conSaldosPendientesToolStripMenuItem";
            this.conSaldosPendientesToolStripMenuItem.Size = new System.Drawing.Size(261, 36);
            this.conSaldosPendientesToolStripMenuItem.Text = "Pago Pendiente";
            // 
            // saldadosToolStripMenuItem
            // 
            this.saldadosToolStripMenuItem.Name = "saldadosToolStripMenuItem";
            this.saldadosToolStripMenuItem.Size = new System.Drawing.Size(261, 36);
            this.saldadosToolStripMenuItem.Text = "Pagados";
            // 
            // canceladosToolStripMenuItem
            // 
            this.canceladosToolStripMenuItem.Name = "canceladosToolStripMenuItem";
            this.canceladosToolStripMenuItem.Size = new System.Drawing.Size(331, 36);
            this.canceladosToolStripMenuItem.Text = "Cancelados";
            this.canceladosToolStripMenuItem.Click += new System.EventHandler(this.canceladosToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mensualToolStripMenuItem,
            this.semanalToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(96, 32);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // mensualToolStripMenuItem
            // 
            this.mensualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.efectivoToolStripMenuItemVentas,
            this.cuentaCorrienteToolStripMenuItem});
            this.mensualToolStripMenuItem.Name = "mensualToolStripMenuItem";
            this.mensualToolStripMenuItem.Size = new System.Drawing.Size(189, 36);
            this.mensualToolStripMenuItem.Text = "Mensual";
            // 
            // efectivoToolStripMenuItemVentas
            // 
            this.efectivoToolStripMenuItemVentas.Name = "efectivoToolStripMenuItemVentas";
            this.efectivoToolStripMenuItemVentas.Size = new System.Drawing.Size(274, 36);
            this.efectivoToolStripMenuItemVentas.Text = "Efectivo";
            // 
            // cuentaCorrienteToolStripMenuItem
            // 
            this.cuentaCorrienteToolStripMenuItem.Name = "cuentaCorrienteToolStripMenuItem";
            this.cuentaCorrienteToolStripMenuItem.Size = new System.Drawing.Size(274, 36);
            this.cuentaCorrienteToolStripMenuItem.Text = "Cuenta Corriente";
            // 
            // semanalToolStripMenuItem
            // 
            this.semanalToolStripMenuItem.Name = "semanalToolStripMenuItem";
            this.semanalToolStripMenuItem.Size = new System.Drawing.Size(189, 36);
            this.semanalToolStripMenuItem.Text = "Semanal";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masVendidosToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(131, 32);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // masVendidosToolStripMenuItem
            // 
            this.masVendidosToolStripMenuItem.Name = "masVendidosToolStripMenuItem";
            this.masVendidosToolStripMenuItem.Size = new System.Drawing.Size(244, 36);
            this.masVendidosToolStripMenuItem.Text = "Mas vendidos";
            // 
            // pagosToolStripMenuItem
            // 
            this.pagosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarPagoToolStripMenuItem,
            this.clientesToolStripMenuItem});
            this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            this.pagosToolStripMenuItem.Size = new System.Drawing.Size(89, 32);
            this.pagosToolStripMenuItem.Text = "Pagos";
            this.pagosToolStripMenuItem.Click += new System.EventHandler(this.pagosToolStripMenuItem_Click);
            // 
            // registrarPagoToolStripMenuItem
            // 
            this.registrarPagoToolStripMenuItem.Name = "registrarPagoToolStripMenuItem";
            this.registrarPagoToolStripMenuItem.Size = new System.Drawing.Size(219, 36);
            this.registrarPagoToolStripMenuItem.Text = "Último mes";
            this.registrarPagoToolStripMenuItem.Click += new System.EventHandler(this.registrarPagoToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(219, 36);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // dataGridViewHistorial
            // 
            this.dataGridViewHistorial.AllowUserToAddRows = false;
            this.dataGridViewHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHistorial.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorial.Location = new System.Drawing.Point(30, 140);
            this.dataGridViewHistorial.Name = "dataGridViewHistorial";
            this.dataGridViewHistorial.RowHeadersWidth = 51;
            this.dataGridViewHistorial.RowTemplate.Height = 24;
            this.dataGridViewHistorial.Size = new System.Drawing.Size(1323, 364);
            this.dataGridViewHistorial.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBuscarPreventista);
            this.panel1.Controls.Add(this.btnBuscarPreventista);
            this.panel1.Controls.Add(this.menuStripHistorialPreventista);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1381, 74);
            this.panel1.TabIndex = 2;
            // 
            // txtBuscarPreventista
            // 
            this.txtBuscarPreventista.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarPreventista.Location = new System.Drawing.Point(327, 17);
            this.txtBuscarPreventista.Name = "txtBuscarPreventista";
            this.txtBuscarPreventista.Size = new System.Drawing.Size(274, 31);
            this.txtBuscarPreventista.TabIndex = 1;
            this.txtBuscarPreventista.TextChanged += new System.EventHandler(this.txtBuscarPreventista_TextChanged);
            // 
            // btnBuscarPreventista
            // 
            this.btnBuscarPreventista.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPreventista.Location = new System.Drawing.Point(30, 15);
            this.btnBuscarPreventista.Name = "btnBuscarPreventista";
            this.btnBuscarPreventista.Size = new System.Drawing.Size(264, 35);
            this.btnBuscarPreventista.TabIndex = 0;
            this.btnBuscarPreventista.Text = "Buscar Preventista";
            this.btnBuscarPreventista.UseVisualStyleBackColor = true;
            this.btnBuscarPreventista.Click += new System.EventHandler(this.btnBuscarPreventista_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1052, 510);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(221, 42);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Volver";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.78121F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.78121F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.38549F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.105064F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.11716F));
            this.tableLayoutPanel1.Controls.Add(this.lblUsuario, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMail, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNombreApellido, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDni, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblnombre_usuario, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 80);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1323, 52);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(1037, 13);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(76, 25);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblMail
            // 
            this.lblMail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(791, 13);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(75, 25);
            this.lblMail.TabIndex = 2;
            this.lblMail.Text = "Correo: ";
            // 
            // lblNombreApellido
            // 
            this.lblNombreApellido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombreApellido.AutoSize = true;
            this.lblNombreApellido.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreApellido.Location = new System.Drawing.Point(113, 13);
            this.lblNombreApellido.Name = "lblNombreApellido";
            this.lblNombreApellido.Size = new System.Drawing.Size(87, 25);
            this.lblNombreApellido.TabIndex = 1;
            this.lblNombreApellido.Text = "Nombre: ";
            // 
            // lblDni
            // 
            this.lblDni.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.Location = new System.Drawing.Point(445, 13);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(52, 25);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI: ";
            // 
            // lblnombre_usuario
            // 
            this.lblnombre_usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblnombre_usuario.AutoSize = true;
            this.lblnombre_usuario.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre_usuario.Location = new System.Drawing.Point(1222, 13);
            this.lblnombre_usuario.Name = "lblnombre_usuario";
            this.lblnombre_usuario.Size = new System.Drawing.Size(0, 25);
            this.lblnombre_usuario.TabIndex = 3;
            // 
            // FormHistorialPreventista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 559);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewHistorial);
            this.MainMenuStrip = this.menuStripHistorialPreventista;
            this.Name = "FormHistorialPreventista";
            this.Text = "Historial Preventista";
            this.Load += new System.EventHandler(this.FormHistorialPreventista_Load);
            this.menuStripHistorialPreventista.ResumeLayout(false);
            this.menuStripHistorialPreventista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorial)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripHistorialPreventista;
        private System.Windows.Forms.ToolStripMenuItem listarClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entregadosToolStripMenuItemPedidos;
        private System.Windows.Forms.ToolStripMenuItem últimoMesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conSaldosPendientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saldadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mensualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efectivoToolStripMenuItemVentas;
        private System.Windows.Forms.ToolStripMenuItem cuentaCorrienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semanalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noConfiablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confiablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tamañoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pequeñosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grandesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canceladosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masVendidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarPagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewHistorial;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBuscarPreventista;
        private System.Windows.Forms.Button btnBuscarPreventista;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblNombreApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblnombre_usuario;
        private System.Windows.Forms.Label lblUsuario;
    }
}