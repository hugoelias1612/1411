using Capa_Logica;
using Capa_Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ArimaERP.EmpleadoProducto
{
    public partial class FormStock : Form
    {
        private readonly ClassProductoLogica _productoLogica = new ClassProductoLogica();

        public FormStock()
        {
            InitializeComponent();

            // Wire events
            BFiltrar.Click += BFiltrar_Click;
            BLimpiar.Click += BLimpiar_Click; // "Alertas Stock Bajo" -> abre FormAlerta
            BComprar.Click += BComprar_Click; // Buscar por nombre en la sección comprar
            TNombreContiene.KeyDown += TNombreContiene_KeyDown;

            // Cargar datos de combo (familia / marca / proveedor)
            LoadCombosFromCatalog();
        }

        private void TNombreContiene_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                EjecutarFiltro(); // Enter en el textbox ejecuta filtro (igual que BFiltrar)
            }
        }

        private void BFiltrar_Click(object sender, EventArgs e)
        {
            EjecutarFiltro();
        }

        private void EjecutarFiltro()
        {
            string termino = TNombreContiene.Text?.Trim();
            int? familiaId = CbFamilia.SelectedValue is int f && f != 0 ? f : (int?)null;
            int? marcaId = CbMarca.SelectedValue is int m && m != 0 ? m : (int?)null;
            int? proveedorId = CbProveedor.SelectedValue is int p && p != 0 ? p : (int?)null;

            // Obtener resultados desde la lógica (puede devolver productos sin FamilyId)
            var productos = (_productoLogica.BuscarCatalogoProductos(termino, familiaId, marcaId, proveedorId, null) ?? new List<ProductoCatalogoDto>()).ToList();

            // Si no tenemos familiaId numérico pero el combo seleccionó una familia concreta,
            // filtramos por nombre de familia en memoria (caso DTO sin FamilyId)
            if (familiaId == null && CbFamilia.SelectedIndex > 0 && !string.Equals(CbFamilia.Text, "Todas", StringComparison.OrdinalIgnoreCase))
            {
                string familiaSeleccionada = CbFamilia.Text?.Trim();
                productos = productos
                    .Where(prod => string.Equals(
                        GetStringProperty(prod, new[] { "Familia", "NombreFamilia", "familyName" })?.Trim(),
                        familiaSeleccionada,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (_productoLogica.ErroresValidacion != null && _productoLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, _productoLogica.ErroresValidacion), "Error al buscar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ActualizarResultadosStock(productos);
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
           
        }

        private void BComprar_Click(object sender, EventArgs e)
        {
            // Permitir buscar por nombre desde la sección "Comprar"
            string termino = TNombreContiene.Text?.Trim();
            if (string.IsNullOrWhiteSpace(termino))
            {
                MessageBox.Show("Ingrese el nombre o parte del nombre para buscar antes de comprar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int? familiaId = CbFamilia.SelectedValue is int f && f != 0 ? f : (int?)null;
            int? marcaId = CbMarca.SelectedValue is int m && m != 0 ? m : (int?)null;
            int? proveedorId = CbProveedor.SelectedValue is int p && p != 0 ? p : (int?)null;

            var productos = _productoLogica.BuscarCatalogoProductos(termino, familiaId, marcaId, proveedorId, null) ?? new List<ProductoCatalogoDto>();

            if (_productoLogica.ErroresValidacion != null && _productoLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, _productoLogica.ErroresValidacion), "Error al buscar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mostrar resultados en la misma grilla para que el usuario seleccione y proceda a comprar
            ActualizarResultadosStock(productos);

            if (!productos.Any())
            {
                MessageBox.Show("No se encontraron productos con ese nombre.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Si existe una pantalla de compra específica puede abrirse desde aquí,
                // por ejemplo: abrir FormComprar con el producto seleccionado.
            }
        }

        private void ActualizarResultadosStock(IEnumerable<ProductoCatalogoDto> productos)
        {
            DGResultados.EndEdit();
            DGResultados.Rows.Clear();

            var culturaMoneda = CultureInfo.GetCultureInfo("es-AR");

            foreach (var producto in productos)
            {
                string proveedorMostrado = string.IsNullOrWhiteSpace(producto.Proveedor) ? "Sin proveedor asignado" : producto.Proveedor;
                decimal precio = GetDecimalProperty(producto, new[] { "PrecioLista", "Precio" });
                string precioFormateado = precio.ToString("C2", culturaMoneda);
                int stock = GetIntProperty(producto, new[] { "Stock", "StockActual", "stock_actual" });
                int stockMinimo = GetIntProperty(producto, new[] { "StockMinimo", "UmbralStock", "umbral_stock" });

                int index = DGResultados.Rows.Add(producto.Nombre, producto.Familia, proveedorMostrado, precioFormateado, stock, stockMinimo);
                DGResultados.Rows[index].Tag = producto;
            }

            LEstado.Text = $"{DGResultados.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow)} Productos";
        }

        // Helpers robustos para leer propiedades que pueden variar entre DTOs
        private decimal GetDecimalProperty(object obj, string[] names)
        {
            if (obj == null) return 0m;
            foreach (var name in names)
            {
                var pi = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (pi != null && (pi.PropertyType == typeof(decimal) || pi.PropertyType == typeof(double) || pi.PropertyType == typeof(float)))
                {
                    var val = pi.GetValue(obj);
                    if (val == null) continue;
                    try
                    {
                        return Convert.ToDecimal(val);
                    }
                    catch { }
                }
            }
            return 0m;
        }

        private int GetIntProperty(object obj, string[] names)
        {
            if (obj == null) return 0;
            foreach (var name in names)
            {
                var pi = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (pi != null && (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(long) || pi.PropertyType == typeof(short)))
                {
                    var val = pi.GetValue(obj);
                    if (val == null) continue;
                    try
                    {
                        return Convert.ToInt32(val);
                    }
                    catch { }
                }
            }
            return 0;
        }

        private string GetStringProperty(object obj, string[] names)
        {
            if (obj == null) return string.Empty;
            foreach (var name in names)
            {
                var pi = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (pi != null && pi.PropertyType == typeof(string))
                {
                    var val = pi.GetValue(obj) as string;
                    if (!string.IsNullOrEmpty(val)) return val;
                }
            }
            return string.Empty;
        }

        // Carga familias (y puede extenderse a marcas/proveedores) extrayéndolas del catálogo
        private void LoadCombosFromCatalog()
        {
            try
            {
                var productos = _productoLogica.BuscarCatalogoProductos(null, null, null, null, null) ?? new List<ProductoCatalogoDto>();

                var familiasRaw = productos
                    .Select(p => new
                    {
                        Id = GetIntProperty(p, new[] { "FamiliaId", "IdFamilia", "familia_id", "FamiliaID" }),
                        Nombre = (GetStringProperty(p, new[] { "Familia", "NombreFamilia", "familyName" }) ?? string.Empty).Trim()
                    });

                // Agrupar considerando nombre cuando no existe Id (evita colapsar todo en Id=0)
                var familias = familiasRaw
                    .GroupBy(x => x.Id != 0 ? $"id:{x.Id}" : $"name:{x.Nombre.ToLowerInvariant()}")
                    .Select(g =>
                    {
                        var first = g.First();
                        return new { Id = first.Id, Nombre = string.IsNullOrWhiteSpace(first.Nombre) ? "Sin familia" : first.Nombre };
                    })
                    .OrderBy(x => x.Nombre)
                    .ToList();

                var lista = new List<object> { new { Id = 0, Nombre = "Todas" } };
                foreach (var f in familias)
                {
                    lista.Add(new { Id = f.Id, Nombre = f.Nombre });
                }

                CbFamilia.DisplayMember = "Nombre";
                CbFamilia.ValueMember = "Id";
                CbFamilia.DataSource = lista;
                CbFamilia.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar las familias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

                private void button1_Click(object sender, EventArgs e)
        {
            // Aquí puedes poner la lógica que debe ejecutarse al hacer clic en "Ver todos"
            EjecutarFiltro(); // Por ejemplo, mostrar todos los productos
        }

        // El diseñador tiene un handler pintado: agregamos el método vacío seguro
        private void tableLayoutPanel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Intencionalmente vacío: el diseñador referenciaba este handler.
        }
    }
}