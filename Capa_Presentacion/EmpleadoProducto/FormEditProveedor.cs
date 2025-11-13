using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Capa_Entidades;
using Capa_Logica;

namespace ArimaERP.EmpleadoProducto
{
    public partial class FormEditProveedor : Form
    {
        private readonly ClassProveedorLogica _proveedorLogica = new ClassProveedorLogica();

        public PROVEEDOR ProveedorSeleccionado { get; private set; }

        public FormEditProveedor()
        {
            InitializeComponent();
        }

        private void FormEditProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            var proveedores = _proveedorLogica.ObtenerTodosLosProveedores() ?? new List<PROVEEDOR>();

            if (!proveedores.Any())
            {
                MessageBox.Show("No hay proveedores disponibles para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            cbxProveedores.DataSource = proveedores;
            cbxProveedores.DisplayMember = nameof(PROVEEDOR.nombre);
            cbxProveedores.ValueMember = nameof(PROVEEDOR.id_proveedor);
            cbxProveedores.SelectedIndex = 0;
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            if (cbxProveedores.SelectedItem is PROVEEDOR proveedorSeleccionado)
            {
                var proveedorCompleto = _proveedorLogica.ObtenerProveedorPorId(proveedorSeleccionado.id_proveedor) ?? proveedorSeleccionado;
                ProveedorSeleccionado = proveedorCompleto;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}