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
    public partial class FormEditarProducto : Form
    {
        private readonly ProductoCatalogoDto _productoSeleccionado;
        private readonly ClassProductoLogica _productoLogica = new ClassProductoLogica();
        private readonly ClassFamiliaLogica _familiaLogica = new ClassFamiliaLogica();
        private readonly ClassMarcaLogica _marcaLogica = new ClassMarcaLogica();
        private readonly ClassProveedorLogica _proveedorLogica = new ClassProveedorLogica();

        private PRODUCTO _productoEntidad;
        private producto_presentacion _productoPresentacion;
        private stock _stockEntidad;

        public FormEditarProducto(ProductoCatalogoDto producto)
        {
            _productoSeleccionado = producto ?? throw new ArgumentNullException(nameof(producto));

            InitializeComponent();

            Load += FormEditarProducto_Load;
            btnCrear.Click += BtnCrear_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
        }

        private void FormEditarProducto_Load(object sender, EventArgs e)
        {
            ConfigurarLimitesNumericUpDown();
            CargarFamilias();
            CargarProveedores();
            CargarMarcas();
            CargarDatosProducto();
        }

        private void ConfigurarLimitesNumericUpDown()
        {
            decimal limiteMaximo = 100000;

            nudUPB.Minimum = 0;
            nudUPB.Maximum = limiteMaximo;

            nudBultosIniciales.Minimum = 0;
            nudBultosIniciales.Maximum = limiteMaximo;

            nudUnidadesIniciales.Minimum = 0;
            nudUnidadesIniciales.Maximum = limiteMaximo;
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

            cbxFamilia.DataSource = familiasConPlaceholder;
            cbxFamilia.DisplayMember = nameof(FAMILIA.descripcion);
            cbxFamilia.ValueMember = nameof(FAMILIA.id_familia);
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
        }

        private void CargarDatosProducto()
        {
            _productoEntidad = _productoLogica.ObtenerProductoPorId(_productoSeleccionado.IdProducto);

            if (_productoEntidad == null)
            {
                MostrarErrorYSalir(_productoLogica.ErroresValidacion.Any()
                    ? string.Join(Environment.NewLine, _productoLogica.ErroresValidacion)
                    : "No se encontraron los datos del producto.");
                return;
            }

            _productoPresentacion = _productoLogica.ObtenerProductoPresentacionPorCodigo(_productoSeleccionado.Codigo);

            if (_productoPresentacion == null)
            {
                MostrarErrorYSalir(_productoLogica.ErroresValidacion.Any()
                    ? string.Join(Environment.NewLine, _productoLogica.ErroresValidacion)
                    : "No se encontró la presentación del producto.");
                return;
            }

            _stockEntidad = _productoLogica.ObtenerStockPorProductoYPresentacion(_productoSeleccionado.IdProducto, _productoSeleccionado.IdPresentacion);

            txtNombre.Text = _productoEntidad.nombre;

            SeleccionarValorCombo(cbxFamilia, _productoEntidad.id_familia);
            SeleccionarValorCombo(cbxMarca, _productoEntidad.id_marca);

            string proveedorPrincipal = ObtenerPrimerProveedor(_productoSeleccionado.Proveedor);
            if (!string.IsNullOrWhiteSpace(proveedorPrincipal))
            {
                var proveedores = cbxProveedor.DataSource as IEnumerable<PROVEEDOR>;
                var proveedorEncontrado = proveedores?
                    .FirstOrDefault(p => string.Equals(p.nombre, proveedorPrincipal, StringComparison.OrdinalIgnoreCase));

                if (proveedorEncontrado != null)
                {
                    SeleccionarValorCombo(cbxProveedor, proveedorEncontrado.id_proveedor);
                }
                else
                {
                    cbxProveedor.SelectedIndex = 0;
                }
            }
            else
            {
                cbxProveedor.SelectedIndex = 0;
            }

            decimal precioLista = _productoPresentacion.precioLista;
            txtPrecioUnit.Text = precioLista.ToString("N2", CultureInfo.CurrentCulture);

            int unidadesPorBulto = _productoPresentacion.unidades_bulto;
            if (unidadesPorBulto <= 0)
            {
                unidadesPorBulto = Math.Max(1, _productoSeleccionado.UnidadesPorBulto);
            }

            AjustarLimitesNumericUpDown(nudUPB, unidadesPorBulto);
            nudUPB.Value = unidadesPorBulto;

            int stockActual = _stockEntidad?.stock_actual ?? _productoSeleccionado.StockActual;
            int bultos = unidadesPorBulto > 0 ? stockActual / unidadesPorBulto : 0;
            int unidadesSueltas = unidadesPorBulto > 0 ? stockActual % unidadesPorBulto : stockActual;

            AjustarLimitesNumericUpDown(nudBultosIniciales, bultos);
            AjustarLimitesNumericUpDown(nudUnidadesIniciales, unidadesSueltas);

            nudBultosIniciales.Value = bultos;
            nudUnidadesIniciales.Value = unidadesSueltas;
        }

        private static string ObtenerPrimerProveedor(string proveedores)
        {
            if (string.IsNullOrWhiteSpace(proveedores))
            {
                return string.Empty;
            }

            return proveedores
                .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .FirstOrDefault() ?? string.Empty;
        }

        private static void AjustarLimitesNumericUpDown(NumericUpDown control, int valor)
        {
            if (valor < 0)
            {
                valor = 0;
            }

            decimal decimalValor = valor;

            if (decimalValor > control.Maximum)
            {
                control.Maximum = decimalValor;
            }

            if (control.Minimum > decimalValor)
            {
                control.Minimum = decimalValor;
            }
        }

        private static void SeleccionarValorCombo(ComboBox comboBox, int valor)
        {
            if (comboBox.DataSource != null)
            {
                comboBox.SelectedValue = valor;
            }
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            var mensajesError = new List<string>();

            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensajesError.Add("El nombre del producto es obligatorio.");
            }

            int familiaId = cbxFamilia.SelectedValue is int idFamilia ? idFamilia : 0;
            if (familiaId == 0)
            {
                mensajesError.Add("Debe seleccionar una familia.");
            }

            int marcaId = cbxMarca.SelectedValue is int idMarca ? idMarca : 0;
            if (marcaId == 0)
            {
                mensajesError.Add("Debe seleccionar una marca.");
            }

            if (!decimal.TryParse(txtPrecioUnit.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal precioLista) || precioLista <= 0)
            {
                mensajesError.Add("Ingrese un precio válido.");
            }

            int unidadesPorBulto = (int)nudUPB.Value;
            if (unidadesPorBulto <= 0)
            {
                mensajesError.Add("Las unidades por bulto deben ser mayores a cero.");
            }

            int bultos = (int)nudBultosIniciales.Value;
            if (bultos < 0)
            {
                mensajesError.Add("Los bultos no pueden ser negativos.");
            }

            int unidadesSueltas = (int)nudUnidadesIniciales.Value;
            if (unidadesSueltas < 0)
            {
                mensajesError.Add("Las unidades sueltas no pueden ser negativas.");
            }

            if (mensajesError.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, mensajesError), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool actualizado = _productoLogica.ActualizarProducto(
                _productoSeleccionado.IdProducto,
                nombre,
                familiaId,
                marcaId,
                _productoSeleccionado.IdPresentacion,
                _productoSeleccionado.Codigo,
                precioLista,
                unidadesPorBulto,
                _productoSeleccionado.Activo);

            if (!actualizado)
            {
                string mensajeError = _productoLogica.ErroresValidacion.Any()
                    ? string.Join(Environment.NewLine, _productoLogica.ErroresValidacion)
                    : "No se pudo actualizar el producto.";

                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int stockActual = (bultos * unidadesPorBulto) + unidadesSueltas;
            int umbral = unidadesPorBulto > 0 ? unidadesPorBulto : 0;

            bool stockActualizado = _productoLogica.EstablecerStock(
                _productoSeleccionado.IdProducto,
                _productoSeleccionado.IdPresentacion,
                stockActual,
                umbral);

            if (!stockActualizado)
            {
                string mensajeError = _productoLogica.ErroresValidacion.Any()
                    ? string.Join(Environment.NewLine, _productoLogica.ErroresValidacion)
                    : "No se pudo actualizar el stock del producto.";

                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void MostrarErrorYSalir(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}