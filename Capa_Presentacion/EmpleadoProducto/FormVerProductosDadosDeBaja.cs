using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Capa_Entidades.DTOs;
using Capa_Logica;

namespace ArimaERP.EmpleadoProducto
{
    public partial class FormVerProductosDadosDeBaja : Form
    {
        private readonly ClassProductoLogica _productoLogica = new ClassProductoLogica();

        public FormVerProductosDadosDeBaja()
        {
            InitializeComponent();

            Load += FormVerProductosDadosDeBaja_Load;
            button1.Click += ButtonReactivar_Click;
            button2.Click += ButtonCancelar_Click;
            DGResultadosBaja.CurrentCellDirtyStateChanged += DGResultadosBaja_CurrentCellDirtyStateChanged;
            DGResultadosBaja.CellContentClick += DGResultadosBaja_CellContentClick;
        }

        private void FormVerProductosDadosDeBaja_Load(object sender, EventArgs e)
        {
            CargarProductosInactivos();
        }

        private void CargarProductosInactivos()
        {
            DGResultadosBaja.EndEdit();
            DGResultadosBaja.Rows.Clear();

            var productos = _productoLogica.BuscarCatalogoProductos(null, null, null, null, false)
                ?? new List<ProductoCatalogoDto>();

            var culturaMoneda = CultureInfo.GetCultureInfo("es-AR");

            foreach (var producto in productos
                         .OrderBy(p => p.Nombre)
                         .ThenBy(p => p.Presentacion))
            {
                string proveedorMostrado = string.IsNullOrWhiteSpace(producto.Proveedor)
                    ? "Sin proveedor asignado"
                    : producto.Proveedor;

                string precioFormateado = producto.PrecioLista.ToString("C2", culturaMoneda);

                int index = DGResultadosBaja.Rows.Add(
                    false,
                    producto.Nombre,
                    precioFormateado,
                    producto.Familia,
                    producto.Marca,
                    proveedorMostrado);

                DGResultadosBaja.Rows[index].Tag = producto;
            }

            if (!DGResultadosBaja.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow))
            {
                MessageBox.Show(
                    "No hay productos inactivos para mostrar.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ButtonReactivar_Click(object sender, EventArgs e)
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
                MessageBox.Show(
                    "Seleccione al menos un producto para reactivar.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var errores = new List<string>();

            foreach (var producto in seleccionados)
            {
                bool resultado = _productoLogica.CambiarEstadoProducto(producto.IdProducto, producto.IdPresentacion, true);

                if (!resultado)
                {
                    string mensajeError = _productoLogica.ErroresValidacion.Any()
                        ? string.Join(Environment.NewLine, _productoLogica.ErroresValidacion)
                        : $"No se pudo reactivar el producto {producto.Nombre}.";

                    errores.Add(mensajeError);
                }
            }

            if (errores.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, errores.Distinct()),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(
                    "Los productos seleccionados se reactivaron correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            CargarProductosInactivos();
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
