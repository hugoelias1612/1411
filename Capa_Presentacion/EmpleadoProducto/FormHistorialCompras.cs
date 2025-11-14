using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Capa_Entidades.DTOs;

namespace ArimaERP.EmpleadoProducto
{
    public partial class FormHistorialCompras : Form
    {
        private readonly DataGridView _dgvHistorial;
        private readonly CultureInfo _culturaMoneda = CultureInfo.GetCultureInfo("es-AR");

        public FormHistorialCompras()
        {
            Text = "Historial de compras";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(640, 400);
            Size = new Size(800, 450);

            _dgvHistorial = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false
            };

            Controls.Add(_dgvHistorial);

            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            _dgvHistorial.Columns.Clear();

            _dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(CompraHistorialDto.FechaCompra),
                HeaderText = "Fecha de compra",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            _dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(CompraHistorialDto.Cantidad),
                HeaderText = "Cantidad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            _dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(CompraHistorialDto.Monto),
                HeaderText = "Monto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            _dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(CompraHistorialDto.NumeroFactura),
                HeaderText = "N° factura",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            _dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(CompraHistorialDto.IdProducto),
                HeaderText = "ID producto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        public void CargarHistorial(IEnumerable<CompraHistorialDto> historial)
        {
            _dgvHistorial.Rows.Clear();

            foreach (var registro in historial ?? Enumerable.Empty<CompraHistorialDto>())
            {
                _dgvHistorial.Rows.Add(
                    registro.FechaCompra.ToString("dd/MM/yyyy"),
                    registro.Cantidad,
                    registro.Monto.ToString("C2", _culturaMoneda),
                    registro.NumeroFactura,
                    registro.IdProducto);
            }
        }
    }
}