using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Capa_Entidades.DTOs;
using Capa_Logica;

namespace ArimaERP.EmpleadoProducto
{
    public partial class FormHistorialCompras : Form
    {
        private readonly CultureInfo _culturaMoneda = CultureInfo.GetCultureInfo("es-AR");
        private readonly ClassCompraLogica _compraLogica = new ClassCompraLogica();
        private List<CompraHistorialDto> _historialCompleto = new List<CompraHistorialDto>();

        public FormHistorialCompras()
        {
            InitializeComponent();

            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AllowUserToResizeRows = false;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.MultiSelect = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.RowHeadersVisible = false;

            if (Detalle is DataGridViewButtonColumn detalleColumn)
            {
                detalleColumn.UseColumnTextForButtonValue = true;
                detalleColumn.Text = "Ver detalle";
            }

            btnFiltrar.Click += BtnFiltrar_Click;
            dgvHistorial.CellContentClick += DgvHistorial_CellContentClick;
        }

        public void CargarHistorial(IEnumerable<CompraHistorialDto> historial)
        {
            _historialCompleto = historial?.ToList() ?? new List<CompraHistorialDto>();

            if (_historialCompleto.Any())
            {
                var fechaMin = _historialCompleto.Min(h => h.FechaCompra).Date;
                var fechaMax = _historialCompleto.Max(h => h.FechaCompra).Date;

                dtpDesde.Value = fechaMin;
                dtpHasta.Value = fechaMax;
            }
            else
            {
                var hoy = DateTime.Today;
                dtpDesde.Value = hoy;
                dtpHasta.Value = hoy;
            }

            AplicarFiltros();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            var fechaDesde = dtpDesde.Value.Date;
            var fechaHasta = dtpHasta.Value.Date;

            if (fechaHasta < fechaDesde)
            {
                MessageBox.Show(
                    "La fecha \"Hasta\" no puede ser anterior a la fecha \"Desde\".",
                    "Rango de fechas inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpHasta.Value = fechaDesde;
                fechaHasta = fechaDesde;
            }

            var historialFiltrado = _historialCompleto
                .Where(h => h.FechaCompra.Date >= fechaDesde && h.FechaCompra.Date <= fechaHasta)
                .OrderByDescending(h => h.FechaCompra)
                .ThenByDescending(h => h.NumeroFactura)
                .ToList();

            dgvHistorial.Rows.Clear();

            foreach (var registro in historialFiltrado)
            {
                var indice = dgvHistorial.Rows.Add();
                var fila = dgvHistorial.Rows[indice];

                fila.Cells["FechaCompra"].Value = registro.FechaCompra.ToString("dd/MM/yyyy");
                fila.Cells["Marca"].Value = string.IsNullOrWhiteSpace(registro.Marca) ? "Sin marca" : registro.Marca;
                fila.Cells["Monto"].Value = registro.Monto.ToString("C2", _culturaMoneda);
                fila.Cells["NumeroFactura"].Value = registro.NumeroFactura;
                fila.Tag = registro;
            }

            dgvHistorial.Refresh();
        }

        private void DgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (dgvHistorial.Columns[e.ColumnIndex].Name != "Detalle")
            {
                return;
            }

            var fila = dgvHistorial.Rows[e.RowIndex];
            if (fila?.Tag is CompraHistorialDto compraSeleccionada)
            {
                MostrarDetalleCompra(compraSeleccionada);
            }
        }

        private void MostrarDetalleCompra(CompraHistorialDto compraSeleccionada)
        {
            var detalles = _compraLogica.ObtenerDetalleCompra(compraSeleccionada.CompraId) ?? new List<CompraDetalleDto>();

            if (_compraLogica.ErroresValidacion.Any())
            {
                MessageBox.Show(
                    string.Join(Environment.NewLine, _compraLogica.ErroresValidacion),
                    "Error al obtener el detalle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            using (var detalleForm = new FormDetalleCompra(compraSeleccionada, detalles, _culturaMoneda))
            {
                detalleForm.ShowDialog(this);
            }
        }
    }
}