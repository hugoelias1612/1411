using Capa_Entidades;
using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArimaERP.EmpleadoClientes
{
    public partial class FormBajaCliente : Form
    {
        private bool cargandoFormulario = true;
        private ClassClienteLogica clienteLogica = new ClassClienteLogica();
        private ClassUsuarioLogica usuarios = new ClassUsuarioLogica();
        private ClassEmpleadoLogica empleado = new ClassEmpleadoLogica();
        private ClassZonaLogica zona = new ClassZonaLogica();
        ClassAuditoriaLogica auditoriaLogica = new ClassAuditoriaLogica();
        public FormBajaCliente()
        {
            InitializeComponent();
        }

        private void FormBajaCliente_Load(object sender, EventArgs e)
        {
            cargandoFormulario = true;
            //cargar zonas en el combobox
            var zonas = clienteLogica.ObtenerZonas();
            var tamanos = clienteLogica.ObtenerTamanos();
            comboBoxBuscarClienteZona.DataSource = zonas;
            comboBoxBuscarClienteZona.DisplayMember = "nombre";
            comboBoxBuscarClienteZona.ValueMember = "id_zona";
            comboBoxBuscarClienteZona.SelectedIndex = -1;
            //Crear encabezados del datagridview
            dataGridViewBajaCliente.ReadOnly = true;
            dataGridViewBajaCliente.AllowUserToAddRows = false;
            dataGridViewBajaCliente.AllowUserToDeleteRows = false;
            dataGridViewBajaCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewBajaCliente.Columns.Clear();
            dataGridViewBajaCliente.Columns.Add("id_cliente", "ID");
            dataGridViewBajaCliente.Columns.Add("dni", "DNI");
            dataGridViewBajaCliente.Columns.Add("nombre", "Nombre");
            dataGridViewBajaCliente.Columns.Add("apellido", "Apellido");
            dataGridViewBajaCliente.Columns.Add("telefono", "Teléfono");
            dataGridViewBajaCliente.Columns.Add("email", "Email");
            dataGridViewBajaCliente.Columns.Add("razon_social", "Razón Social");
            dataGridViewBajaCliente.Columns.Add("cuil_cuit", "CUIL/CUIT");
            dataGridViewBajaCliente.Columns.Add("fecha_alta", "Fecha de Alta");
            dataGridViewBajaCliente.Columns.Add("estado", "Estado");
            dataGridViewBajaCliente.Columns.Add("confiable", "Confiable");
            dataGridViewBajaCliente.Columns.Add("condicion_frenteIVA", "Condición frente al IVA");
            dataGridViewBajaCliente.Columns.Add("calle", "Calle");
            dataGridViewBajaCliente.Columns.Add("numero", "Número");
            dataGridViewBajaCliente.Columns.Add("ciudad", "Ciudad");
            dataGridViewBajaCliente.Columns.Add("provincia", "Provincia");
            dataGridViewBajaCliente.Columns.Add("cod_postal", "Código Postal");
            dataGridViewBajaCliente.Columns.Add("tamano", "Tamaño");
            dataGridViewBajaCliente.Columns.Add("zona", "Zona");
            dataGridViewBajaCliente.Columns.Add("id_tamano", "ID_Tamaño");
            dataGridViewBajaCliente.Columns.Add("id_zona", "ID_Zona");
            dataGridViewBajaCliente.Columns["id_tamano"].Visible = false;
            dataGridViewBajaCliente.Columns["id_zona"].Visible = false;
            //agregar boton eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Acción";
            btnEliminar.Text = "Dar Baja";
            btnEliminar.Name = "btnDarDeBaja";
            btnEliminar.UseColumnTextForButtonValue = true; // Esto hace que el texto del botón sea el mismo en todas las filas
            dataGridViewBajaCliente.Columns.Add(btnEliminar);
            //agregar boton activar
            DataGridViewButtonColumn btnActivar = new DataGridViewButtonColumn();
            btnActivar.HeaderText = "Acción";
            btnActivar.Text = "Activar";
            btnActivar.Name = "btnActivar";
            btnActivar.UseColumnTextForButtonValue = true; // Esto hace que el texto del botón sea el mismo en todas las filas
            dataGridViewBajaCliente.Columns.Add(btnActivar);


            //cargar todos los clientes en el datagridview
            List<CLIENTE> listaClientes = clienteLogica.ObtenerClientes();

            foreach (var cliente in listaClientes)
            {
                string estadoTexto = cliente.estado ? "Activo" : "Inactivo";
                string confiableTexto = cliente.confiable ? "Si" : "No";
                string nombreZona = zonas.FirstOrDefault(z => z.id_zona == cliente.id_zona)?.nombre ?? "Zona desconocida";
                string nombreTamano = tamanos.FirstOrDefault(t => t.id_tamano == cliente.id_tamano)?.descripcion ?? "Tamaño desconocido";
                dataGridViewBajaCliente.Rows.Add(
                    cliente.id_cliente,
                    cliente.dni,
                    cliente.nombre,
                    cliente.apellido,
                    cliente.telefono,
                    cliente.email,
                    cliente.razon_social,
                    cliente.cuil_cuit,
                    cliente.fecha_alta,
                    estadoTexto,
                    confiableTexto,
                    cliente.condicion_frenteIVA,
                    cliente.calle,
                    cliente.numero,
                    cliente.ciudad,
                    cliente.provincia,
                    cliente.cod_postal,
                    nombreTamano,
                    nombreZona,
                     cliente.id_tamano, cliente.id_zona
                );
            }
            // Obtener usuarios con rol Preventista
            var empleadosPreventistas = empleado.ObtenerEmpleadosPorRol(5);

            comboBoxBuscarClientePreventista.DataSource = empleadosPreventistas;
            comboBoxBuscarClientePreventista.DisplayMember = "nombre";
            comboBoxBuscarClientePreventista.ValueMember = "nombre_usuario";
            comboBoxBuscarClientePreventista.SelectedIndex = -1;
            cargandoFormulario = false;
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir solo letras, control y espacio
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBoxApellido, "Solo se permiten letras");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(textBoxApellido, "");
            }
        }

        private void textBoxApellido_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar enter buscar por nombre o por apellido
            if (e.KeyCode == Keys.Enter)
            {
                //
                string filtro = textBoxApellido.Text.ToLower();
                //buscar por nombre o apellido en tabla CLIENTE de base de datos
                // Limpiar las filas actuales del DataGridView
                dataGridViewBajaCliente.Rows.Clear();
                List<CLIENTE> listaClientes = clienteLogica.ObtenerClientes();
                var clientesFiltrados = listaClientes.Where(cliente =>
                    (cliente.nombre != null && cliente.nombre.ToLower().Contains(filtro)) ||
                    (cliente.apellido != null && cliente.apellido.ToLower().Contains(filtro))
                ).ToList();
                var zonas = clienteLogica.ObtenerZonas();
                var tamanos = clienteLogica.ObtenerTamanos();
                foreach (var cliente in clientesFiltrados)
                {
                    string estadoTexto = cliente.estado ? "Activo" : "Inactivo";
                    string confiableTexto = cliente.confiable ? "Si" : "No";
                    string nombreZona = zonas.FirstOrDefault(z => z.id_zona == cliente.id_zona)?.nombre ?? "Zona desconocida";
                    string nombreTamano = tamanos.FirstOrDefault(t => t.id_tamano == cliente.id_tamano)?.descripcion ?? "Tamaño desconocido";
                    dataGridViewBajaCliente.Rows.Add(
                        cliente.id_cliente,
                        cliente.dni,
                        cliente.nombre,
                        cliente.apellido,
                        cliente.telefono,
                        cliente.email,
                        cliente.razon_social,
                        cliente.cuil_cuit,
                        cliente.fecha_alta,
                        estadoTexto,
                        confiableTexto,
                        cliente.condicion_frenteIVA,
                        cliente.calle,
                        cliente.numero,
                        cliente.ciudad,
                        cliente.provincia,
                        cliente.cod_postal,
                        nombreTamano,
                        nombreZona,
                         cliente.id_tamano, cliente.id_zona
                    );
                }
            }
        }

        private void txtBuscarDni_KeyDown(object sender, KeyEventArgs e)
        {
            //Validar que se ingresaron valores numericos
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBuscarDni.Text))
                {
                    if (!long.TryParse(txtBuscarDni.Text, out _))
                    {
                        MessageBox.Show("Por favor, ingrese solo valores numéricos para el DNI.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBuscarDni.Clear();
                        return;
                    }
                }
                string filtro = txtBuscarDni.Text.ToLower();
                //buscar por dni en tabla CLIENTE de base de datos
                // Limpiar las filas actuales del DataGridView
                dataGridViewBajaCliente.Rows.Clear();
                List<CLIENTE> listaClientes = clienteLogica.ObtenerClientes();
                var clientesFiltrados = listaClientes.Where(cliente =>
                    cliente.dni.ToString().ToLower().Contains(filtro)
                ).ToList();
                var zonas = clienteLogica.ObtenerZonas();
                var tamanos = clienteLogica.ObtenerTamanos();
                foreach (var cliente in clientesFiltrados)
                {
                    string estadoTexto = cliente.estado ? "Activo" : "Inactivo";
                    string confiableTexto = cliente.confiable ? "Si" : "No";
                    string nombreZona = zonas.FirstOrDefault(z => z.id_zona == cliente.id_zona)?.nombre ?? "Zona desconocida";
                    string nombreTamano = tamanos.FirstOrDefault(t => t.id_tamano == cliente.id_tamano)?.descripcion ?? "Tamaño desconocido";
                    dataGridViewBajaCliente.Rows.Add(
                        cliente.id_cliente,
                        cliente.dni,
                        cliente.nombre,
                        cliente.apellido,
                        cliente.telefono,
                        cliente.email,
                        cliente.razon_social,
                        cliente.cuil_cuit,
                        cliente.fecha_alta,
                        estadoTexto,
                        confiableTexto,
                        cliente.condicion_frenteIVA,
                        cliente.calle,
                        cliente.numero,
                        cliente.ciudad,
                        cliente.provincia,
                        cliente.cod_postal,
                        nombreTamano,
                        nombreZona,
                         cliente.id_tamano, cliente.id_zona
                    );
                }
            }
        }

        private void txtBusacarEmail_KeyDown(object sender, KeyEventArgs e)
        {
            //buscar por email en tabla CLIENTE de base de datos
            // Limpiar las filas actuales del DataGridView
            dataGridViewBajaCliente.Rows.Clear();
            List<CLIENTE> listaClientes = clienteLogica.ObtenerClientes();
            string filtro = txtBusacarEmail.Text.ToLower();
            var clientesFiltrados = listaClientes.Where(cliente =>
                (cliente.email != null && cliente.email.ToLower().Contains(filtro))
            ).ToList();
            foreach (var cliente in clientesFiltrados)
            {
                string estadoTexto = cliente.estado ? "Activo" : "Inactivo";
                string confiableTexto = cliente.confiable ? "Si" : "No";
                var zonas = clienteLogica.ObtenerZonas();
                var tamanos = clienteLogica.ObtenerTamanos();
                string nombreZona = zonas.FirstOrDefault(z => z.id_zona == cliente.id_zona)?.nombre ?? "Zona desconocida";
                string nombreTamano = tamanos.FirstOrDefault(t => t.id_tamano == cliente.id_tamano)?.descripcion ?? "Tamaño desconocido";
                dataGridViewBajaCliente.Rows.Add(
                    cliente.id_cliente,
                    cliente.dni,
                    cliente.nombre,
                    cliente.apellido,
                    cliente.telefono,
                    cliente.email,
                    cliente.razon_social,
                    cliente.cuil_cuit,
                    cliente.fecha_alta,
                    estadoTexto,
                    confiableTexto,
                    cliente.condicion_frenteIVA,
                    cliente.calle,
                    cliente.numero,
                    cliente.ciudad,
                    cliente.provincia,
                    cliente.cod_postal,
                    nombreTamano,
                    nombreZona,
                     cliente.id_tamano, cliente.id_zona
                );
            }
        }

        private void comboBoxBuscarClientePreventista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoFormulario || comboBoxBuscarClientePreventista.SelectedIndex == -1)
                return;

            if (comboBoxBuscarClientePreventista.SelectedItem is Empleado preventista)
            {
                string nombreUsuario = preventista.nombre_usuario;

                if (!string.IsNullOrEmpty(nombreUsuario))
                {
                    int idZona = zona.BuscarZonaPorPreventista(nombreUsuario);
                    List<CLIENTE> clientes = clienteLogica.ClientesPorZona(idZona);
                    MessageBox.Show($"Clientes encontrados: {clientes.Count}");

                    dataGridViewBajaCliente.Rows.Clear();
                    var zonas = clienteLogica.ObtenerZonas();
                    var tamanos = clienteLogica.ObtenerTamanos();

                    foreach (var cliente in clientes)
                    {
                        string estadoTexto = cliente.estado ? "Activo" : "Inactivo";
                        string confiableTexto = cliente.confiable ? "Si" : "No";
                        string nombreZona = zonas.FirstOrDefault(z => z.id_zona == cliente.id_zona)?.nombre ?? "Zona desconocida";
                        string nombreTamano = tamanos.FirstOrDefault(t => t.id_tamano == cliente.id_tamano)?.descripcion ?? "Tamaño desconocido";

                        dataGridViewBajaCliente.Rows.Add(
                            cliente.id_cliente,
                            cliente.dni,
                            cliente.nombre,
                            cliente.apellido,
                            cliente.telefono,
                            cliente.email,
                            cliente.razon_social,
                            cliente.cuil_cuit,
                            cliente.fecha_alta,
                            estadoTexto,
                            confiableTexto,
                            cliente.condicion_frenteIVA,
                            cliente.calle,
                            cliente.numero,
                            cliente.ciudad,
                            cliente.provincia,
                            cliente.cod_postal,
                            nombreTamano,
                            nombreZona,
                            cliente.id_tamano,
                            cliente.id_zona
                        );
                    }
                }
                else
                {
                    MessageBox.Show("El preventista seleccionado no tiene asignada una zona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewBajaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignorar encabezados

            // Identificar la columna presionada
            var columna = dataGridViewBajaCliente.Columns[e.ColumnIndex];

            // Obtener el ID del cliente desde la fila
            int idCliente = Convert.ToInt32(dataGridViewBajaCliente.Rows[e.RowIndex].Cells["id_cliente"].Value);
            var clienteActivo = clienteLogica.ObtenerClientePorId(idCliente);
            //verificar si ya se encuentra inactivo
            bool estadoCliente = dataGridViewBajaCliente.Rows[e.RowIndex].Cells["estado"].Value.ToString() == "Activo";
            if (!estadoCliente && columna.Name == "btnDarDeBaja")
            {
                MessageBox.Show("El cliente ya se encuentra inactivo.");
                return;
            }
            if (columna.Name == "btnDarDeBaja")
            {
                DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea dar de baja al cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    bool resultado = clienteLogica.InactivarCliente(idCliente);
                    if (resultado)
                    {
                        dataGridViewBajaCliente.Rows[e.RowIndex].Cells["btnDarDeBaja"].ReadOnly = true;
                        MessageBox.Show("Cliente dado de baja correctamente.");
                        ActualizarGrilla();

                        // Auditoría de baja
                        string usuarioActual = ObtenerUsuarioActual();
                        string valorAnterior =
                            $"{clienteActivo.nombre}, {clienteActivo.apellido}, DNI: {clienteActivo.dni}, " +
                            $"CUIL/CUIT: {clienteActivo.cuil_cuit}, Estado: Activo";

                        string valorNuevo =
                            $"{clienteActivo.nombre}, {clienteActivo.apellido}, DNI: {clienteActivo.dni}, " +
                            $"CUIL/CUIT: {clienteActivo.cuil_cuit}, Estado: Inactivo";

                        bool registrado = auditoriaLogica.Registrar(
                            valorAnterior: valorAnterior,
                            valorNuevo: valorNuevo,
                            nombreAccion: "Baja",
                            nombreEntidad: "CLIENTE",
                            usuario: usuarioActual
                        );

                        if (!registrado)
                        {
                            MessageBox.Show("Cliente dado de baja, pero no se pudo registrar auditoría:\n" +
                                string.Join("\n", auditoriaLogica.ErroresValidacion),
                                "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Error al dar de baja al cliente.");
                    }
                }
            }
            else if (columna.Name == "btnActivar")
            {
                if (estadoCliente)
                {
                    MessageBox.Show("El cliente ya se encuentra activo.");
                    return;
                }

                DialogResult confirmacion = MessageBox.Show("¿Desea activar nuevamente al cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    bool resultado = clienteLogica.ActivarCliente(idCliente);
                    if (resultado)
                    {
                        dataGridViewBajaCliente.Rows[e.RowIndex].Cells["btnActivar"].ReadOnly = true;
                        MessageBox.Show("Cliente activado correctamente.");
                        ActualizarGrilla();

                        // Auditoría de activación
                        string usuarioActual = ObtenerUsuarioActual();
                        string valorAnterior =
                            $"{clienteActivo.nombre}, {clienteActivo.apellido}, DNI: {clienteActivo.dni}, " +
                            $"CUIL/CUIT: {clienteActivo.cuil_cuit}, Estado: Inactivo";

                        string valorNuevo =
                            $"{clienteActivo.nombre}, {clienteActivo.apellido}, DNI: {clienteActivo.dni}, " +
                            $"CUIL/CUIT: {clienteActivo.cuil_cuit}, Estado: Activo";

                        bool registrado = auditoriaLogica.Registrar(
                            valorAnterior: valorAnterior,
                            valorNuevo: valorNuevo,
                            nombreAccion: "Activación",
                            nombreEntidad: "CLIENTE",                        
                            usuario: usuarioActual
                        );

                        if (!registrado)
                        {
                            MessageBox.Show("Cliente activado, pero no se pudo registrar auditoría:\n" +
                                string.Join("\n", auditoriaLogica.ErroresValidacion),
                                "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al activar al cliente.");
                    }
                }
            }
        }
        private string ObtenerUsuarioActual()
        {

            return UsuarioSesion.Nombre; // Ejemplo: retorna el nombre del usuario desde una clase estática de sesión
        }
        //actualizar grilla
        private void ActualizarGrilla()
        {
            dataGridViewBajaCliente.Rows.Clear();
            List<CLIENTE> listaClientes = clienteLogica.ObtenerClientes();
            var zonas = clienteLogica.ObtenerZonas();
            var tamanos = clienteLogica.ObtenerTamanos();
            foreach (var cliente in listaClientes)
            {
                string estadoTexto = cliente.estado ? "Activo" : "Inactivo";
                string confiableTexto = cliente.confiable ? "Si" : "No";
                string nombreZona = zonas.FirstOrDefault(z => z.id_zona == cliente.id_zona)?.nombre ?? "Zona desconocida";
                string nombreTamano = tamanos.FirstOrDefault(t => t.id_tamano == cliente.id_tamano)?.descripcion ?? "Tamaño desconocido";
                dataGridViewBajaCliente.Rows.Add(
                    cliente.id_cliente,
                    cliente.dni,
                    cliente.nombre,
                    cliente.apellido,
                    cliente.telefono,
                    cliente.email,
                    cliente.razon_social,
                    cliente.cuil_cuit,
                    cliente.fecha_alta,
                    estadoTexto,
                    confiableTexto,
                    cliente.condicion_frenteIVA,
                    cliente.calle,
                    cliente.numero,
                    cliente.ciudad,
                    cliente.provincia,
                    cliente.cod_postal,
                    nombreTamano,
                    nombreZona,
                     cliente.id_tamano, cliente.id_zona
                );
            }
        }

        private void btnBuscarTodosClientes_Click(object sender, EventArgs e)
        {
            //cargar todos los clientes en el datagridview
            ActualizarGrilla();
        }

        private void btnVerClientesInactivos_Click(object sender, EventArgs e)
        {
            //cargar todos los clientes inactivos en el datagridview
            dataGridViewBajaCliente.Rows.Clear();
            List<CLIENTE> listaClientes = clienteLogica.ObtenerClientesInactivos();
            var zonas = clienteLogica.ObtenerZonas();
            var tamanos = clienteLogica.ObtenerTamanos();
            foreach (var cliente in listaClientes)
            {
                string estadoTexto = cliente.estado ? "Activo" : "Inactivo";
                string confiableTexto = cliente.confiable ? "Si" : "No";
                string nombreZona = zonas.FirstOrDefault(z => z.id_zona == cliente.id_zona)?.nombre ?? "Zona desconocida";
                string nombreTamano = tamanos.FirstOrDefault(t => t.id_tamano == cliente.id_tamano)?.descripcion ?? "Tamaño desconocido";
                dataGridViewBajaCliente.Rows.Add(
                    cliente.id_cliente,
                    cliente.dni,
                    cliente.nombre,
                    cliente.apellido,
                    cliente.telefono,
                    cliente.email,
                    cliente.razon_social,
                    cliente.cuil_cuit,
                    cliente.fecha_alta,
                    estadoTexto,
                    confiableTexto,
                    cliente.condicion_frenteIVA,
                    cliente.calle,
                    cliente.numero,
                    cliente.ciudad,
                    cliente.provincia,
                    cliente.cod_postal,
                    nombreTamano,
                    nombreZona,
                     cliente.id_tamano, cliente.id_zona
                );
            }
        }
    }
}

