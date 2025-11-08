using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Logica;
using Capa_Entidades;

namespace ArimaERP.Administrador
{
    public partial class FormAuditoria : Form
    {
        ClassAuditoriaLogica auditoriaLogica = new ClassAuditoriaLogica();
        ClassUsuarioLogica usuarioLogica = new ClassUsuarioLogica();
        public FormAuditoria()
        {
            InitializeComponent();
        }

        private void FormAuditoria_Load(object sender, EventArgs e)
        {
            dgvAuditoria.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12);
            // Configuración general
            dgvAuditoria.AutoGenerateColumns = false;

            // Limpiar columnas existentes
            dgvAuditoria.Columns.Clear();

            // Crear columnas manualmente
            dgvAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fecha_hora",
                HeaderText = "Fecha y Hora",
                DataPropertyName = "fecha_hora",
                ReadOnly = true
            });

            dgvAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_entidad",
                HeaderText = "Entidad",
                DataPropertyName = "nombre_entidad",
                ReadOnly = true
            });

            dgvAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_accion",
                HeaderText = "Acción",
                DataPropertyName = "nombre_accion",
                ReadOnly = true
            });

            dgvAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "usuario",
                HeaderText = "Usuario",
                DataPropertyName = "usuario",
                ReadOnly = true
            });

            dgvAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "valor_anterior",
                HeaderText = "Valor Anterior",
                DataPropertyName = "valor_anterior",
                ReadOnly = true
            });

            dgvAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "valor_nuevo",
                HeaderText = "Valor Nuevo",
                DataPropertyName = "valor_nuevo",
                ReadOnly = true
            });
            // Cargar comboBoxEntidad desde base de datos
            var entidades = auditoriaLogica.ObtenerEntidades();
            comboBoxEntidad.DataSource = entidades;
            comboBoxEntidad.DisplayMember = "nombre";
            comboBoxEntidad.ValueMember = "entidad_id";
            comboBoxEntidad.SelectedIndex = -1;


            // Cargar comboBoxAccion desde base de datos
            var acciones = auditoriaLogica.ObtenerAcciones();
            comboBoxAccion.DataSource = acciones;
            comboBoxAccion.DisplayMember = "descripcion";
            comboBoxAccion.ValueMember = "ID_accion";
            comboBoxAccion.SelectedIndex = -1;

            // Configurar fechas por defecto
            dateTimePickerDesde.Value = DateTime.Today.AddDays(-30);
            dateTimePickerHasta.Value = DateTime.Today;
        }

        private void comboBoxEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que haya una entidad seleccionada
            if (comboBoxEntidad.SelectedValue is int entidadSeleccionada && entidadSeleccionada > 0)
            {
                dgvAuditoria.Rows.Clear();

                // Obtener auditorías filtradas por entidad
                List<AUDITORIA> auditorias = auditoriaLogica.ObtenerAuditoriasPorEntidad(entidadSeleccionada);

                // Cargar auditorías en el DataGridView
                CargarAuditoriasEnDataGridView(auditorias);
                //resetear selección 
                comboBoxEntidad.SelectedIndex = -1;
            }

        }
        private void CargarAuditoriasEnDataGridView(List<AUDITORIA> auditorias)
        {
            dgvAuditoria.Rows.Clear();

            foreach (var auditoria in auditorias)
            {
                // Obtener entidad por ID
                var entidad = auditoriaLogica.ObtenerEntidadPorId(auditoria.entidad_id);
                string nombreEntidad = entidad?.nombre ?? "(Entidad desconocida)";

                // Obtener acción por ID
                var accion = auditoriaLogica.ObtenerAccionPorId(auditoria.ID_accion);
                string descripcionAccion = accion?.descripcion ?? "(Acción desconocida)";

                // Obtener usuario por nombre
                var usuario = usuarioLogica.ObtenerUsuarioPorNombre(auditoria.usuario);
                string nombreUsuario = usuario?.nombre ?? auditoria.usuario;

                // Agregar fila al DataGridView
                dgvAuditoria.Rows.Add(
                    auditoria.fecha_hora.ToString("dd/MM/yyyy HH:mm"),
                    nombreEntidad,
                    descripcionAccion,
                    nombreUsuario,
                    auditoria.valor_anterior,
                    auditoria.valor_nuevo
                );
            }
        }

        private void comboBoxAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que haya una entidad seleccionada
            if (comboBoxAccion.SelectedValue is int accionSeleccionada && accionSeleccionada > 0)
            {
                dgvAuditoria.Rows.Clear();
                // Obtener auditorías filtradas por accion
                List<AUDITORIA> auditorias = auditoriaLogica.ObtenerAuditoriasPorAccion(accionSeleccionada);
                // Cargar auditorías en el DataGridView
                CargarAuditoriasEnDataGridView(auditorias);
                //resetear selección 
                comboBoxAccion.SelectedIndex = -1;
            }
        }

        private void textBoxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No permitir espacios en blanco
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
                errorProvider1.SetError(textBoxUsuario, "No se permiten espacios en blanco.");
            }
            else
            {
                errorProvider1.SetError(textBoxUsuario, "");
            }
            // No permitir más de 20 caracteres
            if (textBoxUsuario.Text.Length >= 20 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                errorProvider1.SetError(textBoxUsuario, "No se permiten más de 20 caracteres.");
            }
            else
            {
                errorProvider1.SetError(textBoxUsuario, "");
            }
        }

        private void textBoxUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                dgvAuditoria.Rows.Clear();
                string nombreUsuario = textBoxUsuario.Text.Trim();
                if (!string.IsNullOrWhiteSpace(nombreUsuario))
                {
                    var auditorias = auditoriaLogica.ObtenerAuditoriasPorUsuario(nombreUsuario);
                    CargarAuditoriasEnDataGridView(auditorias);
                }
            }
        }

        private void btnBuscarxFecha_Click(object sender, EventArgs e)
        {
            dgvAuditoria.Rows.Clear();
            DateTime fechaDesde = dateTimePickerDesde.Value.Date;
            DateTime fechaHasta = dateTimePickerHasta.Value.Date.AddDays(1).AddSeconds(-1); // incluir todo el día

            var auditorias = auditoriaLogica.ObtenerAuditoriasPorFecha(fechaDesde, fechaHasta);
            CargarAuditoriasEnDataGridView(auditorias);
        }    
}
}
