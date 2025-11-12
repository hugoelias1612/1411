namespace ArimaERP.EmpleadoClientes
{
    partial class FormClienteHistorial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TLPHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.tableLayoutPanelCliente = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxBUSCARGENERAL = new System.Windows.Forms.TextBox();
            this.pictureBoxBuscar = new System.Windows.Forms.PictureBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtBuscarEmail = new System.Windows.Forms.TextBox();
            this.txtBuscarDni = new System.Windows.Forms.TextBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblLetraApellido = new System.Windows.Forms.Label();
            this.txtNombreApellido = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelClientes = new System.Windows.Forms.TableLayoutPanel();
            this.lblPreventistas = new System.Windows.Forms.Label();
            this.lblZONA = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTamano = new System.Windows.Forms.Label();
            this.comboBoxZona = new System.Windows.Forms.ComboBox();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.comboBoxTamano = new System.Windows.Forms.ComboBox();
            this.comboBoxPreventista = new System.Windows.Forms.ComboBox();
            this.dataGridViewVerPedidos = new System.Windows.Forms.DataGridView();
            this.dataGridViewDetallePagos = new System.Windows.Forms.DataGridView();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewCuentaCorriente = new System.Windows.Forms.DataGridView();
            this.btnTodos = new System.Windows.Forms.Button();
            this.TLPHeader.SuspendLayout();
            this.tableLayoutPanelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuscar)).BeginInit();
            this.tableLayoutPanelClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetallePagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCuentaCorriente)).BeginInit();
            this.SuspendLayout();
            // 
            // TLPHeader
            // 
            this.TLPHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TLPHeader.ColumnCount = 1;
            this.TLPHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPHeader.Controls.Add(this.lblHistorial, 0, 0);
            this.TLPHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLPHeader.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLPHeader.Location = new System.Drawing.Point(0, 0);
            this.TLPHeader.Margin = new System.Windows.Forms.Padding(0);
            this.TLPHeader.Name = "TLPHeader";
            this.TLPHeader.RowCount = 1;
            this.TLPHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.27586F));
            this.TLPHeader.Size = new System.Drawing.Size(1325, 58);
            this.TLPHeader.TabIndex = 2;
            // 
            // lblHistorial
            // 
            this.lblHistorial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.Location = new System.Drawing.Point(526, 2);
            this.lblHistorial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(273, 54);
            this.lblHistorial.TabIndex = 7;
            this.lblHistorial.Text = "Buscar Cliente";
            // 
            // tableLayoutPanelCliente
            // 
            this.tableLayoutPanelCliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanelCliente.ColumnCount = 9;
            this.tableLayoutPanelCliente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.0093F));
            this.tableLayoutPanelCliente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.07116F));
            this.tableLayoutPanelCliente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.49057F));
            this.tableLayoutPanelCliente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.86792F));
            this.tableLayoutPanelCliente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.96226F));
            this.tableLayoutPanelCliente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.58491F));
            this.tableLayoutPanelCliente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.754717F));
            this.tableLayoutPanelCliente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.15262F));
            this.tableLayoutPanelCliente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.003839F));
            this.tableLayoutPanelCliente.Controls.Add(this.textBoxBUSCARGENERAL, 7, 1);
            this.tableLayoutPanelCliente.Controls.Add(this.pictureBoxBuscar, 6, 1);
            this.tableLayoutPanelCliente.Controls.Add(this.lblMail, 5, 0);
            this.tableLayoutPanelCliente.Controls.Add(this.txtBuscarEmail, 5, 1);
            this.tableLayoutPanelCliente.Controls.Add(this.txtBuscarDni, 4, 1);
            this.tableLayoutPanelCliente.Controls.Add(this.lblDNI, 4, 0);
            this.tableLayoutPanelCliente.Controls.Add(this.lblLetraApellido, 3, 0);
            this.tableLayoutPanelCliente.Controls.Add(this.txtNombreApellido, 3, 1);
            this.tableLayoutPanelCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelCliente.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanelCliente.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanelCliente.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelCliente.Name = "tableLayoutPanelCliente";
            this.tableLayoutPanelCliente.RowCount = 2;
            this.tableLayoutPanelCliente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelCliente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelCliente.Size = new System.Drawing.Size(1325, 89);
            this.tableLayoutPanelCliente.TabIndex = 6;
            // 
            // textBoxBUSCARGENERAL
            // 
            this.textBoxBUSCARGENERAL.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBUSCARGENERAL.Location = new System.Drawing.Point(1100, 48);
            this.textBoxBUSCARGENERAL.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxBUSCARGENERAL.Name = "textBoxBUSCARGENERAL";
            this.textBoxBUSCARGENERAL.Size = new System.Drawing.Size(166, 31);
            this.textBoxBUSCARGENERAL.TabIndex = 37;
            this.textBoxBUSCARGENERAL.TextChanged += new System.EventHandler(this.textBoxBUSCARGENERAL_TextChanged);
            // 
            // pictureBoxBuscar
            // 
            this.pictureBoxBuscar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxBuscar.Image = global::ArimaERP.Properties.Resources.BUSCAR_reducido20x20;
            this.pictureBoxBuscar.Location = new System.Drawing.Point(1053, 53);
            this.pictureBoxBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxBuscar.Name = "pictureBoxBuscar";
            this.pictureBoxBuscar.Size = new System.Drawing.Size(39, 26);
            this.pictureBoxBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxBuscar.TabIndex = 38;
            this.pictureBoxBuscar.TabStop = false;
            // 
            // lblMail
            // 
            this.lblMail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(856, 9);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(62, 25);
            this.lblMail.TabIndex = 33;
            this.lblMail.Text = "EMAIL";
            this.lblMail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBuscarEmail
            // 
            this.txtBuscarEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarEmail.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarEmail.Location = new System.Drawing.Point(856, 51);
            this.txtBuscarEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscarEmail.Name = "txtBuscarEmail";
            this.txtBuscarEmail.Size = new System.Drawing.Size(174, 31);
            this.txtBuscarEmail.TabIndex = 25;
            this.txtBuscarEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarEmail_KeyDown);
            this.txtBuscarEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusacarEmail_KeyPress);
            // 
            // txtBuscarDni
            // 
            this.txtBuscarDni.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBuscarDni.Location = new System.Drawing.Point(672, 51);
            this.txtBuscarDni.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarDni.Name = "txtBuscarDni";
            this.txtBuscarDni.Size = new System.Drawing.Size(177, 31);
            this.txtBuscarDni.TabIndex = 21;
            this.txtBuscarDni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarDni_KeyDown);
            this.txtBuscarDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarDni_KeyPress);
            // 
            // lblDNI
            // 
            this.lblDNI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNI.Location = new System.Drawing.Point(672, 9);
            this.lblDNI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(43, 25);
            this.lblDNI.TabIndex = 31;
            this.lblDNI.Text = "DNI";
            this.lblDNI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLetraApellido
            // 
            this.lblLetraApellido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLetraApellido.AutoSize = true;
            this.lblLetraApellido.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetraApellido.Location = new System.Drawing.Point(475, 9);
            this.lblLetraApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLetraApellido.Name = "lblLetraApellido";
            this.lblLetraApellido.Size = new System.Drawing.Size(165, 25);
            this.lblLetraApellido.TabIndex = 4;
            this.lblLetraApellido.Text = "Nombre o Apellido";
            this.lblLetraApellido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombreApellido
            // 
            this.txtNombreApellido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNombreApellido.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreApellido.Location = new System.Drawing.Point(475, 51);
            this.txtNombreApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreApellido.Name = "txtNombreApellido";
            this.txtNombreApellido.Size = new System.Drawing.Size(189, 31);
            this.txtNombreApellido.TabIndex = 36;
            this.txtNombreApellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombreApellido_KeyDown);
            this.txtNombreApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreApellido_KeyPress);
            // 
            // tableLayoutPanelClientes
            // 
            this.tableLayoutPanelClientes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanelClientes.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanelClientes.ColumnCount = 8;
            this.tableLayoutPanelClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.60255F));
            this.tableLayoutPanelClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.02704F));
            this.tableLayoutPanelClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.26639F));
            this.tableLayoutPanelClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.26639F));
            this.tableLayoutPanelClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.26639F));
            this.tableLayoutPanelClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.26639F));
            this.tableLayoutPanelClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.26639F));
            this.tableLayoutPanelClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.038473F));
            this.tableLayoutPanelClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelClientes.Controls.Add(this.lblPreventistas, 3, 0);
            this.tableLayoutPanelClientes.Controls.Add(this.lblZONA, 2, 0);
            this.tableLayoutPanelClientes.Controls.Add(this.lblTipo, 1, 0);
            this.tableLayoutPanelClientes.Controls.Add(this.comboBoxTipo, 1, 1);
            this.tableLayoutPanelClientes.Controls.Add(this.lblEstado, 4, 0);
            this.tableLayoutPanelClientes.Controls.Add(this.lblTamano, 5, 0);
            this.tableLayoutPanelClientes.Controls.Add(this.comboBoxZona, 2, 1);
            this.tableLayoutPanelClientes.Controls.Add(this.comboBoxEstado, 4, 1);
            this.tableLayoutPanelClientes.Controls.Add(this.comboBoxTamano, 5, 1);
            this.tableLayoutPanelClientes.Controls.Add(this.comboBoxPreventista, 3, 1);
            this.tableLayoutPanelClientes.Controls.Add(this.btnTodos, 0, 1);
            this.tableLayoutPanelClientes.Location = new System.Drawing.Point(13, 154);
            this.tableLayoutPanelClientes.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelClientes.Name = "tableLayoutPanelClientes";
            this.tableLayoutPanelClientes.RowCount = 2;
            this.tableLayoutPanelClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanelClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanelClientes.Size = new System.Drawing.Size(1300, 84);
            this.tableLayoutPanelClientes.TabIndex = 39;
            // 
            // lblPreventistas
            // 
            this.lblPreventistas.AutoSize = true;
            this.lblPreventistas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreventistas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreventistas.Location = new System.Drawing.Point(559, 0);
            this.lblPreventistas.Name = "lblPreventistas";
            this.lblPreventistas.Size = new System.Drawing.Size(166, 42);
            this.lblPreventistas.TabIndex = 33;
            this.lblPreventistas.Text = "Preventista";
            this.lblPreventistas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZONA
            // 
            this.lblZONA.AutoSize = true;
            this.lblZONA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZONA.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZONA.Location = new System.Drawing.Point(388, 0);
            this.lblZONA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZONA.Name = "lblZONA";
            this.lblZONA.Size = new System.Drawing.Size(164, 42);
            this.lblZONA.TabIndex = 31;
            this.lblZONA.Text = "Zona";
            this.lblZONA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(240, 8);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(105, 25);
            this.lblTipo.TabIndex = 45;
            this.lblTipo.Text = "Tipo Cliente";
            this.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTipo.AutoCompleteCustomSource.AddRange(new string[] {
            "Contado",
            "Cuenta Corriente"});
            this.comboBoxTipo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "Contado",
            "Cuenta Corriente"});
            this.comboBoxTipo.Location = new System.Drawing.Point(205, 46);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(176, 33);
            this.comboBoxTipo.TabIndex = 46;
            this.comboBoxTipo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipo_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(783, 9);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(61, 23);
            this.lblEstado.TabIndex = 47;
            this.lblEstado.Text = "Estado";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTamano
            // 
            this.lblTamano.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTamano.AutoSize = true;
            this.lblTamano.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamano.Location = new System.Drawing.Point(951, 9);
            this.lblTamano.Name = "lblTamano";
            this.lblTamano.Size = new System.Drawing.Size(70, 23);
            this.lblTamano.TabIndex = 48;
            this.lblTamano.Text = "Tamaño";
            this.lblTamano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxZona
            // 
            this.comboBoxZona.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxZona.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxZona.FormattingEnabled = true;
            this.comboBoxZona.Location = new System.Drawing.Point(387, 46);
            this.comboBoxZona.Name = "comboBoxZona";
            this.comboBoxZona.Size = new System.Drawing.Size(166, 33);
            this.comboBoxZona.TabIndex = 49;
            this.comboBoxZona.SelectedIndexChanged += new System.EventHandler(this.comboBoxZona_SelectedIndexChanged);
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEstado.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.comboBoxEstado.Location = new System.Drawing.Point(731, 46);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(166, 33);
            this.comboBoxEstado.TabIndex = 50;
            this.comboBoxEstado.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstado_SelectedIndexChanged);
            // 
            // comboBoxTamano
            // 
            this.comboBoxTamano.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTamano.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTamano.FormattingEnabled = true;
            this.comboBoxTamano.Items.AddRange(new object[] {
            "Pequeño",
            "Mediano",
            "Grande"});
            this.comboBoxTamano.Location = new System.Drawing.Point(903, 46);
            this.comboBoxTamano.Name = "comboBoxTamano";
            this.comboBoxTamano.Size = new System.Drawing.Size(166, 33);
            this.comboBoxTamano.TabIndex = 51;
            this.comboBoxTamano.SelectedIndexChanged += new System.EventHandler(this.comboBoxTamano_SelectedIndexChanged);
            // 
            // comboBoxPreventista
            // 
            this.comboBoxPreventista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPreventista.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPreventista.FormattingEnabled = true;
            this.comboBoxPreventista.Location = new System.Drawing.Point(559, 46);
            this.comboBoxPreventista.Name = "comboBoxPreventista";
            this.comboBoxPreventista.Size = new System.Drawing.Size(166, 33);
            this.comboBoxPreventista.TabIndex = 52;
            this.comboBoxPreventista.SelectedIndexChanged += new System.EventHandler(this.comboBoxPreventista_SelectedIndexChanged);
            // 
            // dataGridViewVerPedidos
            // 
            this.dataGridViewVerPedidos.AllowUserToAddRows = false;
            this.dataGridViewVerPedidos.AllowUserToDeleteRows = false;
            this.dataGridViewVerPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewVerPedidos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewVerPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewVerPedidos.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewVerPedidos.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewVerPedidos.Location = new System.Drawing.Point(12, 395);
            this.dataGridViewVerPedidos.Name = "dataGridViewVerPedidos";
            this.dataGridViewVerPedidos.RowHeadersVisible = false;
            this.dataGridViewVerPedidos.RowHeadersWidth = 51;
            this.dataGridViewVerPedidos.RowTemplate.Height = 24;
            this.dataGridViewVerPedidos.Size = new System.Drawing.Size(998, 159);
            this.dataGridViewVerPedidos.TabIndex = 40;
            this.dataGridViewVerPedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVerPedidos_CellContentClick);
            // 
            // dataGridViewDetallePagos
            // 
            this.dataGridViewDetallePagos.AllowUserToAddRows = false;
            this.dataGridViewDetallePagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetallePagos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewDetallePagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDetallePagos.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewDetallePagos.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridViewDetallePagos.Location = new System.Drawing.Point(13, 563);
            this.dataGridViewDetallePagos.Name = "dataGridViewDetallePagos";
            this.dataGridViewDetallePagos.RowHeadersVisible = false;
            this.dataGridViewDetallePagos.RowHeadersWidth = 51;
            this.dataGridViewDetallePagos.RowTemplate.Height = 24;
            this.dataGridViewDetallePagos.Size = new System.Drawing.Size(997, 163);
            this.dataGridViewDetallePagos.TabIndex = 41;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvClientes.Location = new System.Drawing.Point(12, 246);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.RowTemplate.Height = 24;
            this.dgvClientes.Size = new System.Drawing.Size(1301, 143);
            this.dgvClientes.TabIndex = 42;
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(1149, 663);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(164, 55);
            this.btnSalir.TabIndex = 43;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewCuentaCorriente
            // 
            this.dataGridViewCuentaCorriente.AllowUserToAddRows = false;
            this.dataGridViewCuentaCorriente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCuentaCorriente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCuentaCorriente.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewCuentaCorriente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCuentaCorriente.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewCuentaCorriente.Location = new System.Drawing.Point(1016, 395);
            this.dataGridViewCuentaCorriente.Name = "dataGridViewCuentaCorriente";
            this.dataGridViewCuentaCorriente.RowHeadersVisible = false;
            this.dataGridViewCuentaCorriente.RowHeadersWidth = 51;
            this.dataGridViewCuentaCorriente.RowTemplate.Height = 24;
            this.dataGridViewCuentaCorriente.Size = new System.Drawing.Size(297, 159);
            this.dataGridViewCuentaCorriente.TabIndex = 44;
            this.dataGridViewCuentaCorriente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCuentaCorriente_CellContentClick);
            // 
            // btnTodos
            // 
            this.btnTodos.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTodos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTodos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodos.ForeColor = System.Drawing.Color.White;
            this.btnTodos.Location = new System.Drawing.Point(3, 45);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(196, 36);
            this.btnTodos.TabIndex = 45;
            this.btnTodos.Text = "Todos los Clientes";
            this.btnTodos.UseVisualStyleBackColor = false;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // FormClienteHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 739);
            this.Controls.Add(this.dataGridViewCuentaCorriente);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.dataGridViewDetallePagos);
            this.Controls.Add(this.dataGridViewVerPedidos);
            this.Controls.Add(this.tableLayoutPanelCliente);
            this.Controls.Add(this.tableLayoutPanelClientes);
            this.Controls.Add(this.TLPHeader);
            this.Name = "FormClienteHistorial";
            this.Text = "Historial de Clientes";
            this.Load += new System.EventHandler(this.FormClienteHistorial_Load);
            this.TLPHeader.ResumeLayout(false);
            this.TLPHeader.PerformLayout();
            this.tableLayoutPanelCliente.ResumeLayout(false);
            this.tableLayoutPanelCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuscar)).EndInit();
            this.tableLayoutPanelClientes.ResumeLayout(false);
            this.tableLayoutPanelClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVerPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetallePagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCuentaCorriente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLPHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCliente;
        private System.Windows.Forms.TextBox txtBuscarEmail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtBuscarDni;
        private System.Windows.Forms.TextBox txtNombreApellido;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblLetraApellido;
        private System.Windows.Forms.TextBox textBoxBUSCARGENERAL;
        private System.Windows.Forms.PictureBox pictureBoxBuscar;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelClientes;
        private System.Windows.Forms.Label lblPreventistas;
        private System.Windows.Forms.Label lblZONA;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTamano;
        private System.Windows.Forms.ComboBox comboBoxZona;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.ComboBox comboBoxTamano;
        private System.Windows.Forms.DataGridView dataGridViewVerPedidos;
        private System.Windows.Forms.DataGridView dataGridViewDetallePagos;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox comboBoxPreventista;
        private System.Windows.Forms.DataGridView dataGridViewCuentaCorriente;
        private System.Windows.Forms.Button btnTodos;
    }
}