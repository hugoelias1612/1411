using Capa_Entidades;
using Capa_Entidades.DTOs;
using Capa_Logica;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ArimaERP.EmpleadoProducto
{
    public partial class FormABM : Form
    {
        private ErrorProvider errorProvider;
        private readonly ClassFamiliaLogica _familiaLogica = new ClassFamiliaLogica();
        private readonly ClassProductoLogica _productoLogica = new ClassProductoLogica();
        private readonly ClassProveedorLogica _proveedorLogica = new ClassProveedorLogica();
        private readonly ClassMarcaLogica _marcaLogica = new ClassMarcaLogica();
        private readonly Dictionary<int, (int desde, int hasta)> _rangosPresentacion =
            new Dictionary<int, (int desde, int hasta)>
            {
                { 3, (1, 10) },   // Lácteos
                { 2, (11, 20) },  // Bebidas
                { 5, (21, 30) },  // Bebidas alcohólicas
                { 1, (31, 40) },  // Comidas / Alimentos
                { 7, (41, 50) },  // Pilas - Velas - Encendedores
                { 4, (51, 60) },  // Higiene personal
                { 6, (61, 70) }   // Cuidado doméstico
            };
        private bool _modificacionInicializada = false;
        private bool _cargandoFiltrosMod = false;

        public FormABM()
        {
            InitializeComponent();

            // Inicialización del ErrorProvider
            errorProvider = new ErrorProvider
            {
                ContainerControl = this,
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };
            this.Load += new System.EventHandler(this.FormABM_Load);
            cbxFamilia.SelectedIndexChanged += cbxFamilia_SelectedIndexChanged;
            btnBuscarBaja.Click += btnBuscarBaja_Click;
            btnConfirmarBaja.Click += btnConfirmarBaja_Click;
            DGResultadosBaja.CurrentCellDirtyStateChanged += DGResultadosBaja_CurrentCellDirtyStateChanged;
            DGResultadosBaja.CellContentClick += DGResultadosBaja_CellContentClick;
            btnVerBajas.Click += btnVerBajas_Click;

            btnBuscarMod.Click += btnBuscarMod_Click;
            btnEditar.Click += btnEditar_Click;
            cbxFamiliaMod.SelectedIndexChanged += FiltrosModificacion_Changed;
            cbxMarcaMod.SelectedIndexChanged += FiltrosModificacion_Changed;
            txtNombreMod.KeyDown += TxtNombreMod_KeyDown;
            DGResultadosMod.CurrentCellDirtyStateChanged += DGResultadosMod_CurrentCellDirtyStateChanged;

            InicializarGrillaMod();
            InicializarGrillaBaja();
        }

        private void FormABM_Load(object sender, EventArgs e)
        {
            CargarFamilias();
            CargarProveedores();
            CargarMarcas();
            CargarFiltrosBaja();
            CargarFiltrosModificacion();
        }

        // Validar que Nombre solo contenga letras y espacios
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNombre.Text.Length == 0 && char.IsLower(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtNombre, "Solo se permiten letras y espacios.");
            }
            else if (!char.IsControl(e.KeyChar) && txtNombre.Text.Length >= 30)
            {
                e.Handled = true;
                errorProvider1.SetError(txtNombre, "Máximo 30 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtNombre, string.Empty);
            }
        }

        private void btnCrearProducto_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            var mensajesError = new List<string>();

            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensajesError.Add("El nombre del producto es obligatorio.");
                errorProvider1.SetError(txtNombre, "Ingrese el nombre del producto.");
            }

            int familiaId = cbxFamilia.SelectedValue is int idFamilia ? idFamilia : 0;
            if (familiaId == 0)
            {
                mensajesError.Add("Debe seleccionar una familia.");
                errorProvider1.SetError(cbxFamilia, "Seleccione una familia.");
            }
            else
            {
                errorProvider1.SetError(cbxFamilia, string.Empty);
            }

            int proveedorId = cbxProveedor.SelectedValue is int idProveedor ? idProveedor : 0;
            if (proveedorId == 0)
            {
                mensajesError.Add("Debe seleccionar un proveedor.");
                errorProvider1.SetError(cbxProveedor, "Seleccione un proveedor.");
            }
            else
            {
                errorProvider1.SetError(cbxProveedor, string.Empty);
            }

            int marcaId = cbxMarca.SelectedValue is int idMarca ? idMarca : 0;
            if (marcaId == 0)
            {
                mensajesError.Add("Debe seleccionar una marca.");
                errorProvider1.SetError(cbxMarca, "Seleccione una marca.");
            }
            else
            {
                errorProvider1.SetError(cbxMarca, string.Empty);
            }

            int presentacionId = cbxPresentacion.SelectedValue is int idPresentacion ? idPresentacion : 0;
            if (presentacionId == 0)
            {
                mensajesError.Add("Debe seleccionar una presentación.");
                errorProvider1.SetError(cbxPresentacion, "Seleccione una presentación.");
            }
            else
            {
                errorProvider1.SetError(cbxPresentacion, string.Empty);
            }

            if (!int.TryParse(textBoxCodigo.Text, out int codigoProducto) || codigoProducto <= 0)
            {
                mensajesError.Add("El código del producto debe ser un número entero mayor a cero.");
                errorProvider1.SetError(textBoxCodigo, "Ingrese un código numérico válido.");
            }
            else if (!_productoLogica.EsCodigoDeProductoDisponible(codigoProducto))
            {
                mensajesError.Add("El código de producto ingresado ya está en uso.");
                errorProvider1.SetError(textBoxCodigo, "El código de producto ya está en uso.");
            }
            else
            {
                errorProvider1.SetError(textBoxCodigo, string.Empty);
            }

            if (!decimal.TryParse(txtPrecioUnit.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal precioLista) || precioLista <= 0)
            {
                mensajesError.Add("El precio unitario debe ser un número mayor a cero.");
                errorProvider1.SetError(txtPrecioUnit, "Ingrese un precio válido.");
            }
            else
            {
                errorProvider1.SetError(txtPrecioUnit, string.Empty);
            }

            // Se elimina la validación que obligaba unidadesPorBulto > 0.
            int unidadesPorBulto = (int)nudBultosIniciales.Value;

            int bultosIniciales = (int)nudBultosIniciales.Value;
            if (bultosIniciales < 0)
            {
                mensajesError.Add("Los bultos iniciales no pueden ser negativos.");
                errorProvider1.SetError(nudBultosIniciales, "Ingrese un valor válido.");
            }
            else
            {
                errorProvider1.SetError(nudBultosIniciales, string.Empty);
            }

            int unidadesIniciales = (int)nudUnidadesIniciales.Value;
            if (unidadesIniciales < 0)
            {
                mensajesError.Add("Las unidades iniciales no pueden ser negativas.");
                errorProvider1.SetError(nudUnidadesIniciales, "Ingrese un valor válido.");
            }
            else
            {
                errorProvider1.SetError(nudUnidadesIniciales, string.Empty);
            }

            if (mensajesError.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, mensajesError), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int stockInicial = unidadesIniciales;
            int umbralStock = unidadesPorBulto;

            bool creado;
            try
            {
                creado = _productoLogica.CrearProducto(nombre, familiaId, marcaId, codigoProducto, precioLista, presentacionId, stockInicial, umbralStock);
            }
            catch (Exception ex)
            {
                // Mostrar la excepción interna para facilitar el diagnóstico (no cambiar lógica de negocio)
                string detalle = ex.Message;
                if (ex.InnerException != null)
                    detalle += Environment.NewLine + "Inner: " + ex.InnerException.Message;
                MessageBox.Show($"Error al crear el producto: {detalle}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!creado)
            {
                string mensajeError = (_productoLogica.ErroresValidacion != null && _productoLogica.ErroresValidacion.Any())
                    ? string.Join(Environment.NewLine, _productoLogica.ErroresValidacion)
                    : "No se pudo crear el producto. Intente nuevamente.";

                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Producto creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLimpiarCampos_Click(sender, e);
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtPrecioUnit.Clear();
            textBoxCodigo.Clear();

            if (cbxFamilia.Items.Count > 0)
            {
                cbxFamilia.SelectedIndex = 0;
            }

            cbxProveedor.SelectedIndex = 0;
            cbxMarca.SelectedIndex = 0;

            LimpiarPresentaciones();

            nudUPB.Value = 0;
            nudBultosIniciales.Value = 0;
            nudUnidadesIniciales.Value = 0;

            errorProvider1.Clear();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            PAlta.Visible = true;
            PBaja.Visible = false;
            PModificacion.Visible = false;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            PAlta.Visible = false;
            PBaja.Visible = true;
            PModificacion.Visible = false;

            if (!DGResultadosBaja.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow))
            {
                EjecutarBusquedaBaja();
            }
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            PAlta.Visible = false;
            PBaja.Visible = false;
            PModificacion.Visible = true;

        }

        private void DGResultadosMod_KeyDown(object sender, KeyEventArgs e)
        {
            // Lógica adicional si se necesita
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // Lógica adicional si se necesita
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Acción al hacer clic en una celda
        }

        private void textBoxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (textBoxCodigo.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBoxCodigo, "Máximo 10 caracteres.");
            }
        }

        private void CargarFamilias()
        {
            var familias = _familiaLogica.ObtenerTodasLasFamilias() ?? new List<FAMILIA>();

            if (familias.Count == 0 && _familiaLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _familiaLogica.ErroresValidacion),
                    "Error al cargar familias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var familiasConPlaceholder = new List<FAMILIA>
            {
                new FAMILIA { id_familia = 0, descripcion = "Seleccione familia" }
            };
            familiasConPlaceholder.AddRange(familias.OrderBy(f => f.descripcion));

            cbxFamilia.SelectedIndexChanged -= cbxFamilia_SelectedIndexChanged;
            cbxFamilia.DataSource = familiasConPlaceholder;
            cbxFamilia.DisplayMember = nameof(FAMILIA.descripcion);
            cbxFamilia.ValueMember = nameof(FAMILIA.id_familia);
            cbxFamilia.SelectedIndex = 0;
            cbxFamilia.SelectedIndexChanged += cbxFamilia_SelectedIndexChanged;
        }

        private void CargarProveedores()
        {
            var proveedores = _proveedorLogica.ObtenerTodosLosProveedores() ?? new List<PROVEEDOR>();

            if (proveedores.Count == 0 && _proveedorLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _proveedorLogica.ErroresValidacion),
                    "Error al cargar proveedores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var proveedoresConPlaceholder = new List<PROVEEDOR>
            {
                new PROVEEDOR { id_proveedor = 0, nombre = "Seleccione proveedor" }
            };
            proveedoresConPlaceholder.AddRange(proveedores.OrderBy(p => p.nombre));

            cbxProveedor.DataSource = proveedoresConPlaceholder;
            cbxProveedor.DisplayMember = nameof(PROVEEDOR.nombre);
            cbxProveedor.ValueMember = nameof(PROVEEDOR.id_proveedor);
            cbxProveedor.SelectedIndex = 0;
        }

        private void CargarMarcas()
        {
            var marcas = _marcaLogica.ObtenerTodasLasMarcas() ?? new List<MARCA>();

            if (marcas.Count == 0 && _marcaLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _marcaLogica.ErroresValidacion),
                    "Error al cargar marcas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var marcasConPlaceholder = new List<MARCA>
            {
                new MARCA { id_marca = 0, nombre = "Seleccione marca" }
            };
            marcasConPlaceholder.AddRange(marcas.OrderBy(m => m.nombre));

            cbxMarca.DataSource = marcasConPlaceholder;
            cbxMarca.DisplayMember = nameof(MARCA.nombre);
            cbxMarca.ValueMember = nameof(MARCA.id_marca);
            cbxMarca.SelectedIndex = 0;
        }

        private void cbxFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbxFamilia.SelectedValue is int familiaId) || familiaId == 0)
            {
                LimpiarPresentaciones();
                return;
            }

            if (!_rangosPresentacion.TryGetValue(familiaId, out var rango))
            {
                LimpiarPresentaciones();
                return;
            }

            var presentaciones = _productoLogica.ObtenerPresentacionesPorRango(rango.desde, rango.hasta) ?? new List<PRESENTACION>();

            if (presentaciones.Count == 0 && _productoLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _productoLogica.ErroresValidacion),
                    "Error al cargar presentaciones",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                LimpiarPresentaciones();
                return;
            }

            var presentacionesConPlaceholder = new List<PRESENTACION>
            {
                new PRESENTACION { ID_presentacion = 0, descripcion = "Seleccione presentación" }
            };
            presentacionesConPlaceholder.AddRange(presentaciones.OrderBy(p => p.descripcion));

            cbxPresentacion.DataSource = presentacionesConPlaceholder;
            cbxPresentacion.DisplayMember = nameof(PRESENTACION.descripcion);
            cbxPresentacion.ValueMember = nameof(PRESENTACION.ID_presentacion);
            cbxPresentacion.SelectedIndex = 0;
            cbxPresentacion.Enabled = true;
        }

        private void LimpiarPresentaciones()
        {
            cbxPresentacion.DataSource = null;
            cbxPresentacion.Items.Clear();
            cbxPresentacion.Items.Insert(0, "Seleccione presentación");
            cbxPresentacion.SelectedIndex = 0;
            cbxPresentacion.Enabled = false;
        }

        private void textBoxCodigo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
        }

        private void InicializarGrillaBaja()
        {
            DGResultadosBaja.AutoGenerateColumns = false;
            DGResultadosBaja.DataSource = null;
            DGResultadosBaja.Rows.Clear();
            DGResultadosBaja.AllowUserToAddRows = false;

            if (DGResultadosBaja.Columns["Precio"] != null)
            {
                DGResultadosBaja.Columns["Precio"].DefaultCellStyle.Format = "C2";
                DGResultadosBaja.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void InicializarGrillaMod()
        {
            DGResultadosMod.AutoGenerateColumns = false;
            DGResultadosMod.DataSource = null;
            DGResultadosMod.Rows.Clear();
            DGResultadosMod.AllowUserToAddRows = false;
            DGResultadosMod.MultiSelect = false;
            DGResultadosMod.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (DGResultadosMod.Columns["colPrecio"] != null)
            {
                DGResultadosMod.Columns["colPrecio"].DefaultCellStyle.Format = "C2";
                DGResultadosMod.Columns["colPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void CargarFiltrosModificacion()
        {
            _cargandoFiltrosMod = true;

            try
            {
                CargarFamiliasMod();
                CargarMarcasMod();
            }
            finally
            {
                _cargandoFiltrosMod = false;
            }
        }

        private void CargarFamiliasMod()
        {
            var familias = _familiaLogica.ObtenerTodasLasFamilias() ?? new List<FAMILIA>();

            if (familias.Count == 0 && _familiaLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _familiaLogica.ErroresValidacion),
                    "Error al cargar familias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var familiasConOpcionTodas = new List<FAMILIA>
            {
                new FAMILIA { id_familia = 0, descripcion = "Todas" }
            };
            familiasConOpcionTodas.AddRange(familias.OrderBy(f => f.descripcion));

            cbxFamiliaMod.DataSource = familiasConOpcionTodas;
            cbxFamiliaMod.DisplayMember = nameof(FAMILIA.descripcion);
            cbxFamiliaMod.ValueMember = nameof(FAMILIA.id_familia);
            cbxFamiliaMod.SelectedIndex = 0;
        }

        private void CargarMarcasMod()
        {
            var marcas = _marcaLogica.ObtenerTodasLasMarcas() ?? new List<MARCA>();

            if (marcas.Count == 0 && _marcaLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _marcaLogica.ErroresValidacion),
                    "Error al cargar marcas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var marcasConOpcionTodas = new List<MARCA>
            {
                new MARCA { id_marca = 0, nombre = "Todas" }
            };
            marcasConOpcionTodas.AddRange(marcas.OrderBy(m => m.nombre));

            cbxMarcaMod.DataSource = marcasConOpcionTodas;
            cbxMarcaMod.DisplayMember = nameof(MARCA.nombre);
            cbxMarcaMod.ValueMember = nameof(MARCA.id_marca);
            cbxMarcaMod.SelectedIndex = 0;
        }

        private void btnBuscarMod_Click(object sender, EventArgs e)
        {
            EjecutarBusquedaModificacion();
        }

        private void FiltrosModificacion_Changed(object sender, EventArgs e)
        {
            if (_cargandoFiltrosMod)
            {
                return;
            }

            if (PModificacion.Visible)
            {
                EjecutarBusquedaModificacion();
            }
        }

        private void TxtNombreMod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                EjecutarBusquedaModificacion();
            }
        }

        private void DGResultadosMod_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGResultadosMod.IsCurrentCellDirty)
            {
                DGResultadosMod.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DGResultadosMod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (DGResultadosMod.Columns[e.ColumnIndex].Name == "colSeleccionar")
            {
                DGResultadosMod.EndEdit();

                bool marcado = Convert.ToBoolean(DGResultadosMod.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? false);

                if (marcado)
                {
                    foreach (DataGridViewRow row in DGResultadosMod.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells[e.ColumnIndex].Value = false;
                        }
                    }
                }
            }
        }

        private void EjecutarBusquedaModificacion()
        {
            string termino = txtNombreMod.Text.Trim();
            int? familiaId = cbxFamiliaMod.SelectedValue is int idFamilia && idFamilia != 0 ? idFamilia : (int?)null;
            int? marcaId = cbxMarcaMod.SelectedValue is int idMarca && idMarca != 0 ? idMarca : (int?)null;

            var productos = _productoLogica.BuscarCatalogoProductos(termino, familiaId, marcaId, null, true);

            if (_productoLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _productoLogica.ErroresValidacion),
                    "Error al buscar productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ActualizarResultadosMod(productos);
            _modificacionInicializada = true;
        }

        private void ActualizarResultadosMod(IEnumerable<ProductoCatalogoDto> productos)
        {
            DGResultadosMod.EndEdit();
            DGResultadosMod.Rows.Clear();

            foreach (var producto in productos)
            {
                string proveedorMostrado = string.IsNullOrWhiteSpace(producto.Proveedor)
                    ? "Sin proveedor asignado"
                    : producto.Proveedor;

                var culturaMoneda = CultureInfo.GetCultureInfo("es-AR");

                string precioFormateado = producto.PrecioLista.ToString("C2", culturaMoneda);

                int index = DGResultadosMod.Rows.Add(false, precioFormateado, producto.Nombre, producto.Familia, producto.Marca, proveedorMostrado, producto.UnidadesPorBulto);
                DGResultadosMod.Rows[index].Tag = producto;
            }

            if (!DGResultadosMod.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow))
            {
                MessageBox.Show("No se encontraron productos con los filtros seleccionados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private ProductoCatalogoDto ObtenerProductoSeleccionadoParaModificar()
        {
            return DGResultadosMod.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow && Convert.ToBoolean(r.Cells["colSeleccionar"].Value ?? false))
                .Select(r => r.Tag as ProductoCatalogoDto)
                .FirstOrDefault(p => p != null);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var productoSeleccionado = ObtenerProductoSeleccionadoParaModificar();

            if (productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new FormEditarProducto(productoSeleccionado))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    EjecutarBusquedaModificacion();
                }
            }
        }

        private void CargarFiltrosBaja()
        {
            CargarFamiliasBaja();
            CargarMarcasBaja();
            CargarProveedoresBaja();
        }

        private void CargarFamiliasBaja()
        {
            var familias = _familiaLogica.ObtenerTodasLasFamilias() ?? new List<FAMILIA>();

            if (familias.Count == 0 && _familiaLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _familiaLogica.ErroresValidacion),
                    "Error al cargar familias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var familiasConOpcionTodas = new List<FAMILIA>
            {
                new FAMILIA { id_familia = 0, descripcion = "Todas" }
            };
            familiasConOpcionTodas.AddRange(familias.OrderBy(f => f.descripcion));

            cbxFamiliaBaja.DataSource = familiasConOpcionTodas;
            cbxFamiliaBaja.DisplayMember = nameof(FAMILIA.descripcion);
            cbxFamiliaBaja.ValueMember = nameof(FAMILIA.id_familia);
            cbxFamiliaBaja.SelectedIndex = 0;
        }

        private void CargarMarcasBaja()
        {
            var marcas = _marcaLogica.ObtenerTodasLasMarcas() ?? new List<MARCA>();

            if (marcas.Count == 0 && _marcaLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _marcaLogica.ErroresValidacion),
                    "Error al cargar marcas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var marcasConOpcionTodas = new List<MARCA>
            {
                new MARCA { id_marca = 0, nombre = "Todas" }
            };
            marcasConOpcionTodas.AddRange(marcas.OrderBy(m => m.nombre));

            cbxMarcaBaja.DataSource = marcasConOpcionTodas;
            cbxMarcaBaja.DisplayMember = nameof(MARCA.nombre);
            cbxMarcaBaja.ValueMember = nameof(MARCA.id_marca);
            cbxMarcaBaja.SelectedIndex = 0;
        }

        private void CargarProveedoresBaja()
        {
            var proveedores = _proveedorLogica.ObtenerTodosLosProveedores() ?? new List<PROVEEDOR>();

            if (proveedores.Count == 0 && _proveedorLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _proveedorLogica.ErroresValidacion),
                    "Error al cargar proveedores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var proveedoresConOpcionTodos = new List<PROVEEDOR>
            {
                new PROVEEDOR { id_proveedor = 0, nombre = "Todos" }
            };
            proveedoresConOpcionTodos.AddRange(proveedores.OrderBy(p => p.nombre));

            cbxProveedorBaja.DataSource = proveedoresConOpcionTodos;
            cbxProveedorBaja.DisplayMember = nameof(PROVEEDOR.nombre);
            cbxProveedorBaja.ValueMember = nameof(PROVEEDOR.id_proveedor);
            cbxProveedorBaja.SelectedIndex = 0;
        }

        private void btnBuscarBaja_Click(object sender, EventArgs e)
        {
            EjecutarBusquedaBaja();
        }

        private void EjecutarBusquedaBaja()
        {
            string termino = txtNombreBaja.Text.Trim();
            int? familiaId = cbxFamiliaBaja.SelectedValue is int idFamilia && idFamilia != 0 ? idFamilia : (int?)null;
            int? marcaId = cbxMarcaBaja.SelectedValue is int idMarca && idMarca != 0 ? idMarca : (int?)null;
            int? proveedorId = cbxProveedorBaja.SelectedValue is int idProveedor && idProveedor != 0 ? idProveedor : (int?)null;

            var productos = _productoLogica.BuscarCatalogoProductos(termino, familiaId, marcaId, proveedorId, true);

            if (_productoLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _productoLogica.ErroresValidacion),
                    "Error al buscar productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ActualizarResultadosBaja(productos);
        }

        private void ActualizarResultadosBaja(IEnumerable<ProductoCatalogoDto> productos)
        {
            DGResultadosBaja.EndEdit();
            DGResultadosBaja.Rows.Clear();

            foreach (var producto in productos)
            {
                string proveedorMostrado = string.IsNullOrWhiteSpace(producto.Proveedor)
                    ? "Sin proveedor asignado"
                    : producto.Proveedor;

                var culturaMoneda = CultureInfo.GetCultureInfo("es-AR");

                string precioFormateado = producto.PrecioLista.ToString("C2", culturaMoneda);

                int index = DGResultadosBaja.Rows.Add(false, precioFormateado, producto.Nombre, producto.Familia, producto.Marca, proveedorMostrado);
                DGResultadosBaja.Rows[index].Tag = producto;
            }

            if (!DGResultadosBaja.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow))
            {
                MessageBox.Show("No se encontraron productos con los filtros seleccionados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConfirmarBaja_Click(object sender, EventArgs e)
        {
            DGResultadosBaja.EndEdit();

            var seleccionados = DGResultadosBaja.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow && Convert.ToBoolean(r.Cells["Baja"].Value ?? false))
                .Select(r => r.Tag as ProductoCatalogoDto)
                .Where(p => p != null)
                .ToList();

            if (!seleccionados.Any())
            {
                MessageBox.Show("Seleccione al menos un producto para dar de baja.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var errores = new List<string>();

            foreach (var producto in seleccionados)
            {
                bool resultado = _productoLogica.CambiarEstadoProducto(producto.IdProducto, producto.IdPresentacion, false);

                if (!resultado)
                {
                    string mensajeError = _productoLogica.ErroresValidacion.Any()
                        ? string.Join(Environment.NewLine, _productoLogica.ErroresValidacion)
                        : $"No se pudo dar de baja el producto {producto.Nombre}.";

                    errores.Add(mensajeError);
                }
            }

            if (errores.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, errores.Distinct()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Los productos seleccionados se dieron de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            EjecutarBusquedaBaja();
        }

        private void DGResultadosBaja_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGResultadosBaja.IsCurrentCellDirty)
            {
                DGResultadosBaja.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DGResultadosBaja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (DGResultadosBaja.Columns[e.ColumnIndex].Name == "Baja")
            {
                DGResultadosBaja.EndEdit();
            }
        }

        private void btnVerBajas_Click(object sender, EventArgs e)
        {
            using (var form = new FormVerProductosDadosDeBaja())
            {
                form.ShowDialog(this);
            }
        }

    }
}