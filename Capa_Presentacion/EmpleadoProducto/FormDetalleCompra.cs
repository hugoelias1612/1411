using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Capa_Entidades.DTOs;

namespace ArimaERP.EmpleadoProducto
{
    public partial class FormDetalleCompra : Form
    {
        private readonly DataGridView _dgvDetalle;
        private readonly CultureInfo _culturaMoneda;

        public FormDetalleCompra(CompraHistorialDto compra, IEnumerable<CompraDetalleDto> detalles, CultureInfo culturaMoneda)
        {
            _culturaMoneda = culturaMoneda ?? CultureInfo.GetCultureInfo("es-AR");

            Text = compra == null
                ? "Detalle de compra"
                : $"Detalle compra - Factura {compra.NumeroFactura}";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(600, 400);
            Size = new Size(720, 420);

            _dgvDetalle = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            Controls.Add(_dgvDetalle);

            ConfigurarColumnas();
            CargarDetalle(detalles);
        }

        private void ConfigurarColumnas()
        {
            _dgvDetalle.Columns.Clear();

            _dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(CompraDetalleDto.IdProducto),
                HeaderText = "ID producto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            _dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(CompraDetalleDto.NombreProducto),
                HeaderText = "Producto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            _dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(CompraDetalleDto.Cantidad),
                HeaderText = "Cantidad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            _dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(CompraDetalleDto.PrecioUnitario),
                HeaderText = "Precio unitario",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        private void CargarDetalle(IEnumerable<CompraDetalleDto> detalles)
        {
            _dgvDetalle.Rows.Clear();

            foreach (var detalle in detalles ?? Enumerable.Empty<CompraDetalleDto>())
            {
                var indice = _dgvDetalle.Rows.Add();
                var fila = _dgvDetalle.Rows[indice];

                fila.Cells[nameof(CompraDetalleDto.IdProducto)].Value = detalle.IdProducto;
                fila.Cells[nameof(CompraDetalleDto.NombreProducto)].Value = detalle.NombreProducto;
                fila.Cells[nameof(CompraDetalleDto.Cantidad)].Value = detalle.Cantidad;
                fila.Cells[nameof(CompraDetalleDto.PrecioUnitario)].Value = detalle.PrecioUnitario.ToString("C2", _culturaMoneda);
            }
        }
    }
}