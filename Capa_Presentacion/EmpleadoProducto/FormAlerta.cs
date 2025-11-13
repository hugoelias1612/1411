using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Capa_Entidades;
using Capa_Entidades.DTOs;
using Capa_Logica;

namespace ArimaERP.EmpleadoProducto
{
    public partial class FormAlerta : Form
    {
        private readonly ClassFamiliaLogica _familiaLogica = new ClassFamiliaLogica();
        private readonly ClassProveedorLogica _proveedorLogica = new ClassProveedorLogica();
        private readonly ClassProductoLogica _productoLogica = new ClassProductoLogica();

        public FormAlerta()
        {
            InitializeComponent();
        }

        private void FormAlerta_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarFamilias();
            CargarProveedores();

            label12.Visible = false;
            CbOrden.Visible = false;

            NStockMax.Value = NStockMax.Maximum;

            CbOrden.SelectedIndex = 0;
            MostrarResultados(new List<ProductoCatalogoDto>());
        }

        private void ConfigurarGrilla()
        {
            DGResultados.AutoGenerateColumns = false;
            DGResultados.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            DGResultados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DGResultados.ColumnHeadersHeight = 34;
            DGResultados.EnableHeadersVisualStyles = false;
            DGResultados.ColumnHeadersDefaultCellStyle.SelectionBackColor = DGResultados.ColumnHeadersDefaultCellStyle.BackColor;
            DGResultados.ColumnHeadersDefaultCellStyle.SelectionForeColor = DGResultados.ColumnHeadersDefaultCellStyle.ForeColor;

            DGResultados.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            DGResultados.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGResultados.GridColor = Color.FromArgb(210, 220, 235);
            DGResultados.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
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

            var opciones = new List<FAMILIA>
            {
                new FAMILIA { id_familia = 0, descripcion = "Todas las familias" }
            };
            opciones.AddRange(familias.OrderBy(f => f.descripcion));

            CbFamilia.DataSource = opciones;
            CbFamilia.DisplayMember = nameof(FAMILIA.descripcion);
            CbFamilia.ValueMember = nameof(FAMILIA.id_familia);
            CbFamilia.SelectedIndex = 0;
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

            var opciones = new List<PROVEEDOR>
            {
                new PROVEEDOR { id_proveedor = 0, nombre = "Todos los proveedores" }
            };
            opciones.AddRange(proveedores);

            CbProveedor.DataSource = opciones;
            CbProveedor.DisplayMember = nameof(PROVEEDOR.nombre);
            CbProveedor.ValueMember = nameof(PROVEEDOR.id_proveedor);
            CbProveedor.SelectedIndex = 0;
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            int? familiaId = ObtenerValorCombo(CbFamilia);
            int? proveedorId = ObtenerValorCombo(CbProveedor);
            int? stockMaximo = ObtenerStockMaximo();
            bool soloStockInsuficiente = CheckBoxUmbral.Checked;
            string termino = string.IsNullOrWhiteSpace(TNombreContiene.Text) ? null : TNombreContiene.Text.Trim();

            // Intentar interpretar término como código si es numérico
            int codigoBuscado;
            bool terminoEsCodigo = int.TryParse(termino, out codigoBuscado);

            List<ProductoCatalogoDto> productos;
            try
            {
                productos = _productoLogica.ObtenerProductosConStockCritico(
                    familiaId,
                    proveedorId,
                    stockMaximo,
                    soloStockInsuficiente) ?? new List<ProductoCatalogoDto>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al obtener los productos: {ex.Message}",
                    "Error al buscar productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Aplicar filtro por término: buscar en Nombre, Familia, Marca, Presentacion o Codigo
            if (!string.IsNullOrEmpty(termino))
            {
                productos = productos
                    .Where(p =>
                        (terminoEsCodigo && p.Codigo == codigoBuscado) ||
                        (!string.IsNullOrWhiteSpace(p.Nombre) && p.Nombre.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrWhiteSpace(p.Familia) && p.Familia.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrWhiteSpace(p.Marca) && p.Marca.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrWhiteSpace(p.Presentacion) && p.Presentacion.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0))
                    .ToList();
            }

            // Aplicar orden según SelectedIndex de CbOrden (si tiene ítems)
            if (CbOrden.Items.Count > 0)
            {
                switch (CbOrden.SelectedIndex)
                {
                    case 1:
                        productos = productos.OrderBy(p => p.Nombre).ToList();
                        break;
                    case 2:
                        productos = productos.OrderBy(p => p.StockActual).ToList();
                        break;
                    case 3:
                        productos = productos.OrderByDescending(p => p.StockActual).ToList();
                        break;
                    case 4:
                        productos = productos.OrderBy(p => p.PrecioLista).ToList();
                        break;
                    case 5:
                        productos = productos.OrderByDescending(p => p.PrecioLista).ToList();
                        break;
                    case 6:
                        productos = productos.OrderBy(p => p.Presentacion).ToList();
                        break;
                    case 7:
                        productos = productos.OrderBy(p => p.Codigo).ToList();
                        break;
                    default:
                        // índice 0 o desconocido => mantener el orden original
                        break;
                }
            }

            if (_productoLogica.ErroresValidacion != null && _productoLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _productoLogica.ErroresValidacion),
                    "Error al buscar productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            MostrarResultados(productos);
        }

        private static int? ObtenerValorCombo(ComboBox combo)
        {
            return combo.SelectedValue is int valor && valor != 0
                ? valor
                : (int?)null;
        }

        private void MostrarResultados(List<ProductoCatalogoDto> productos)
        {
            var datos = productos
                .Select(p => new
                {
                    Codigo = p.Codigo,
                    Producto = p.Nombre,
                    Marca = string.IsNullOrWhiteSpace(p.Marca) ? "—" : p.Marca,
                    Familia = p.Familia,
                    Presentacion = string.IsNullOrWhiteSpace(p.Presentacion) ? "—" : p.Presentacion,
                    Proveedor = string.IsNullOrWhiteSpace(p.Proveedor) ? "—" : p.Proveedor,
                    Precio = p.PrecioLista,
                    Stock = p.StockActual,
                    StockMinimo = p.UmbralStock
                })
                .ToList();

            DGResultados.DataSource = datos;

            if (datos.Count == 0)
            {
                LEstado.Text = "Sin resultados. Ajustá los filtros y presioná Buscar.";
            }
            else
            {
                var sufijo = datos.Count == 1 ? "producto encontrado." : "productos encontrados.";
                LEstado.Text = $"{datos.Count} {sufijo}";
            }
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            CbFamilia.SelectedIndex = 0;
            CbProveedor.SelectedIndex = 0;
            TNombreContiene.Clear();
            CheckBoxUmbral.Checked = false;
            NStockMax.Value = NStockMax.Maximum;
            CbOrden.SelectedIndex = 0;

            MostrarResultados(new List<ProductoCatalogoDto>());
        }

        private int? ObtenerStockMaximo()
        {
            var maximoPermitido = (int)NStockMax.Maximum;
            var seleccionado = (int)NStockMax.Value;

            return seleccionado < maximoPermitido ? (int?)seleccionado : null;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        }
    }
}