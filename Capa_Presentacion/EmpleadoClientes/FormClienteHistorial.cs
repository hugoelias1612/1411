using Capa_Entidades;
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
using System.Diagnostics.Eventing.Reader;

namespace ArimaERP.EmpleadoClientes
{
    public partial class FormClienteHistorial : Form

    {
        ClassClienteLogica clienteLogica = new ClassClienteLogica();
        private bool cargandoFormulario = true;
        private ClassUsuarioLogica usuarios = new ClassUsuarioLogica();
        private ClassEmpleadoLogica empleado = new ClassEmpleadoLogica();
        private ClassZonaLogica zona = new ClassZonaLogica();
        private ClassPedidoLogica pedidoLogica = new ClassPedidoLogica();
        private ClassPagoLogica pagoLogica = new ClassPagoLogica();
        private ClassEmpleadoLogica empleadoLogica = new ClassEmpleadoLogica();
        public FormClienteHistorial()
        {
            InitializeComponent();
        }






        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Cerrar formulario
            this.Close();
        }

        private void txtNombreApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir solo letras y espacios en blanco y control (backspace) y limitar a 30 caracteres
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtNombreApellido, "Solo se permiten letras y espacios en blanco");
            }
            else if (txtNombreApellido.Text.Length >= 30 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtNombreApellido, "No se permiten mas de 30 caracteres");
            }
            else
            {
                errorProvider1.SetError(txtNombreApellido, "");
            }
        }

        private void txtBuscarDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir solo numeros y control (backspace) y limitar a 8 caracteres
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBuscarDni, "Solo se permiten numeros");
            }
            else if (txtBuscarDni.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBuscarDni, "No se permiten mas de 8 caracteres");
            }
            else
            {
                errorProvider1.SetError(txtBuscarDni, "");
            }

        }
        //recargar dgvClientes
        private void CargarClientesEnGrid(List<CLIENTE> listaClientes)
        {
            try
            {
                dgvClientes.Rows.Clear();

                var zonas = clienteLogica.ObtenerZonas();
                var tamanos = clienteLogica.ObtenerTamanos();

                foreach (var cliente in listaClientes)
                {
                    string estadoTexto = cliente.estado ? "Activo" : "Inactivo";
                    string confiableTexto = cliente.confiable ? "Si" : "No";
                    string nombreZona = zonas.FirstOrDefault(z => z.id_zona == cliente.id_zona)?.nombre ?? "Zona desconocida";
                    string nombreTamano = tamanos.FirstOrDefault(t => t.id_tamano == cliente.id_tamano)?.descripcion ?? "Tamaño desconocido";

                    dgvClientes.Rows.Add(
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }


        private void FormClienteHistorial_Load(object sender, EventArgs e)
        {
            cargandoFormulario = true;
            //ocultar dataGridViews
            dgvClientes.Visible = true;
            dataGridViewDetallePagos.Visible = true;
            dataGridViewVerPedidos.Visible = true;
            //crear columnas en dataGridViewClientes
            dgvClientes.Columns.Add("id_cliente", "ID");
            dgvClientes.Columns.Add("dni", "DNI");
            dgvClientes.Columns.Add("nombre", "Nombre");
            dgvClientes.Columns.Add("apellido", "Apellido");
            dgvClientes.Columns.Add("telefono", "Teléfono");
            dgvClientes.Columns.Add("email", "Email");
            dgvClientes.Columns.Add("razon_social", "Razón Social");
            dgvClientes.Columns.Add("cuil_cuit", "CUIL/CUIT");
            dgvClientes.Columns.Add("fecha_alta", "Fecha de Alta");
            dgvClientes.Columns.Add("estado", "Estado");
            dgvClientes.Columns.Add("confiable", "Confiable");
            dgvClientes.Columns.Add("condicion_frenteIVA", "Condición frente al IVA");
            dgvClientes.Columns.Add("calle", "Calle");
            dgvClientes.Columns.Add("numero", "Número");
            dgvClientes.Columns.Add("ciudad", "Ciudad");
            dgvClientes.Columns.Add("provincia", "Provincia");
            dgvClientes.Columns.Add("cod_postal", "Código Postal");
            dgvClientes.Columns.Add("tamano", "Tamaño");
            dgvClientes.Columns.Add("zona", "Zona");
            dgvClientes.Columns.Add("id_tamano", "ID Tamaño");
            dgvClientes.Columns.Add("id_zona", "ID Zona");
            DataGridViewButtonColumn btnVerPedidos = new DataGridViewButtonColumn();
            btnVerPedidos.Name = "btnVerPedidos";
            btnVerPedidos.HeaderText = "Acciones";
            btnVerPedidos.Text = "Ver Pedidos";
            btnVerPedidos.UseColumnTextForButtonValue = true;
            btnVerPedidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns.Add(btnVerPedidos);

            //permitir solo lectura del dgvClientes
            dgvClientes.ReadOnly = true;
            //seleccionar toda la fila al hacer click en una celda
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //no permitir seleccionar multiples filas
            dgvClientes.MultiSelect = false;
            //ocultar columnas id_tamano e id_zona
            dgvClientes.Columns["id_tamano"].Visible = false;
            dgvClientes.Columns["id_zona"].Visible = false;
            //cargar lista de clientes en dgvClientes
            List<CLIENTE> listaClientes = clienteLogica.ObtenerClientes();

            CargarClientesEnGrid(listaClientes);
            //cargar preventistas en comboBoxPreventista
            // Obtener usuarios con rol Preventista
            var empleadosPreventistas = empleado.ObtenerEmpleadosPorRol(5);

            comboBoxPreventista.DataSource = empleadosPreventistas;
            comboBoxPreventista.DisplayMember = "nombre";
            comboBoxPreventista.ValueMember = "nombre_usuario";
            comboBoxPreventista.SelectedIndex = -1;
            //cargar zonas en comboBoxZona desde base de datos
            comboBoxZona.DataSource = clienteLogica.ObtenerZonas();
            comboBoxZona.DisplayMember = "nombre";
            comboBoxZona.ValueMember = "id_zona";
            comboBoxZona.SelectedIndex = -1;
            //cargar tamaños en comboBoxTamano desde base de datos
            comboBoxTamano.DataSource = clienteLogica.ObtenerTamanos();
            comboBoxTamano.DisplayMember = "descripcion";
            comboBoxTamano.ValueMember = "id_tamano";
            comboBoxTamano.SelectedIndex = -1;
            //cargar dataGridViewVerPedidos
            dataGridViewVerPedidos.Columns.Add("id_pedido", "ID Pedido");
            dataGridViewVerPedidos.Columns.Add("fecha_creacion", "Fecha Creación");
            dataGridViewVerPedidos.Columns.Add("fecha_entrega", "Fecha Entrega");
            dataGridViewVerPedidos.Columns.Add("id_cliente", "ID Cliente");
            dataGridViewVerPedidos.Columns.Add("nombre_cliente", "Cliente");
            dataGridViewVerPedidos.Columns.Add("id_estado", "ID_estado");
            dataGridViewVerPedidos.Columns.Add("estado", "Estado");
            dataGridViewVerPedidos.Columns.Add("total", "Total");
            dataGridViewVerPedidos.Columns.Add("numero_factura", "Número Factura");
            dataGridViewVerPedidos.Columns.Add("vendedor", "Vendedor");
            
            DataGridViewButtonColumn btnVerPagos = new DataGridViewButtonColumn();
            btnVerPagos.Name = "btnVerPagos";
            btnVerPagos.HeaderText = "Acciones";
            btnVerPagos.Text = "Ver Pagos";
            btnVerPagos.UseColumnTextForButtonValue = true;
            btnVerPagos.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewVerPedidos.Columns.Add(btnVerPagos);

            //ocultar columna id_estado
            dataGridViewVerPedidos.Columns["id_estado"].Visible = false;
            //ocultar columna id_cliente
            dataGridViewVerPedidos.Columns["id_cliente"].Visible = false;
            //permitir solo lectura del dataGridViewVerPedidos
            dataGridViewVerPedidos.ReadOnly = true;
            //cargar dataGridViewDetallePagos
            dataGridViewDetallePagos.Columns.Add("id_pago", "ID Pago");
            dataGridViewDetallePagos.Columns.Add("id_cliente", "ID Cliente");
            dataGridViewDetallePagos.Columns.Add("nombre_cliente", "Cliente");
            dataGridViewDetallePagos.Columns.Add("monto", "Monto");
            dataGridViewDetallePagos.Columns.Add("fecha", "Fecha Pago");
            dataGridViewDetallePagos.Columns.Add("id_metodo", "Método de Pago");
            dataGridViewDetallePagos.Columns.Add("metodo_pago", "Método de Pago");
            //ocultar columna id_cliente
            dataGridViewDetallePagos.Columns["id_cliente"].Visible = false;
            dataGridViewDetallePagos.Columns["id_metodo"].Visible = false;
            //permitir solo lectura del dataGridViewDetallePagos
            dataGridViewDetallePagos.ReadOnly = true;
            cargandoFormulario = false;
            dataGridViewCuentaCorriente.Columns.Add("id_cliente", "ID Cliente");
            dataGridViewCuentaCorriente.Columns.Add("cliente", "Cliente");
            dataGridViewCuentaCorriente.Columns.Add("saldo_actual", "Saldo Actual");
            dataGridViewCuentaCorriente.Columns.Add("fecha_ultimo_movimiento", "Último Movimiento");

            dataGridViewCuentaCorriente.ReadOnly = true;
            dataGridViewCuentaCorriente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCuentaCorriente.MultiSelect = false;
            dataGridViewCuentaCorriente.Visible = false;

        }

        private void txtBuscarDni_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                dgvClientes.Visible = true;
                dataGridViewDetallePagos.Visible = false;
                dataGridViewVerPedidos.Visible = false;

                errorProvider1.SetError(txtBuscarDni, "");

                string dniTexto = txtBuscarDni.Text.Trim();

                if (string.IsNullOrEmpty(dniTexto))
                {
                    MessageBox.Show("Ingrese un DNI para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(dniTexto, out int dni))
                {
                    MessageBox.Show("Por favor, ingrese solo valores numéricos para el DNI.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscarDni.Clear();
                    return;
                }

                // Buscar cliente por DNI usando capa lógica
                var cliente = clienteLogica.ObtenerClientePorDni(dni.ToString());

                if (cliente == null)
                {
                    MessageBox.Show("No se encontró ningún cliente con ese DNI.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Cargar cliente en el DataGridView usando función reutilizable
                CargarClientesEnGrid(new List<CLIENTE> { cliente });
            }
        }

        private void txtBusacarEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            //limitar a 50 caracteres
            if (txtBuscarEmail.Text.Length >= 50 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBuscarEmail, "No se permiten mas de 50 caracteres");
            }
            else
            {
                errorProvider1.SetError(txtBuscarEmail, "");
            }
        }

        private void txtNombreApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvClientes.Visible = true;
                dataGridViewDetallePagos.Visible = false;
                dataGridViewVerPedidos.Visible = false;

                errorProvider1.SetError(txtNombreApellido, "");

                string textoBusqueda = txtNombreApellido.Text.Trim();

                if (textoBusqueda.Length < 3)
                {
                    MessageBox.Show("Ingrese al menos 3 caracteres para buscar por nombre o apellido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? idCliente = pedidoLogica.ObtenerIdClientePorTexto(textoBusqueda);

                if (idCliente == null)
                {
                    MessageBox.Show("No se encontró ningún cliente con ese nombre o apellido.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var cliente = clienteLogica.ObtenerClientePorId(idCliente.Value);

                if (cliente != null)
                {
                    CargarClientesEnGrid(new List<CLIENTE> { cliente });
                }
                else
                {
                    MessageBox.Show("No se pudo recuperar la información del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscarEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            dgvClientes.Visible = true;
            dataGridViewDetallePagos.Visible = false;
            dataGridViewVerPedidos.Visible = false;
            errorProvider1.SetError(txtBuscarEmail, "");

            string email = txtBuscarEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("El campo de email no puede estar vacío", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("Por favor, ingrese un formato de email válido.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscarEmail.Clear();
                return;
            }

            var cliente = clienteLogica.ObtenerClientePorEmail(email);

            dgvClientes.Rows.Clear();

            if (cliente != null)
            {
                CargarClientesEnGrid(new List<CLIENTE> { cliente });
            }
            else
            {
                MessageBox.Show("No se encontró ningún cliente con ese email.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void textBoxBUSCARGENERAL_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBoxBUSCARGENERAL.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                dgvClientes.Rows.Clear();
                dgvClientes.Visible = false;
                return;
            }

            try
            {
                var clientesFiltrados = clienteLogica.BuscarClientesPorTexto(filtro);

                dgvClientes.Rows.Clear();
                dgvClientes.Visible = true;

                if (clientesFiltrados.Any())
                {
                    CargarClientesEnGrid(clientesFiltrados);
                }
                else
                {
                    // Opcional: mostrar mensaje si no hay coincidencias
                    // MessageBox.Show("No se encontraron coincidencias.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxPreventista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoFormulario || comboBoxPreventista.SelectedIndex == -1)
                return;

            if (comboBoxPreventista.SelectedItem is Empleado preventista)
            {
                string nombreUsuario = preventista.nombre_usuario;

                if (!string.IsNullOrEmpty(nombreUsuario))
                {
                    int idZona = zona.BuscarZonaPorPreventista(nombreUsuario);
                    List<CLIENTE> clientes = clienteLogica.ClientesPorZona(idZona);
                    MessageBox.Show($"Clientes encontrados: {clientes.Count}");

                    dgvClientes.Rows.Clear();
                    var zonas = clienteLogica.ObtenerZonas();
                    var tamanos = clienteLogica.ObtenerTamanos();

                    foreach (var cliente in clientes)
                    {
                        string estadoTexto = cliente.estado ? "Activo" : "Inactivo";
                        string confiableTexto = cliente.confiable ? "Si" : "No";
                        string nombreZona = zonas.FirstOrDefault(z => z.id_zona == cliente.id_zona)?.nombre ?? "Zona desconocida";
                        string nombreTamano = tamanos.FirstOrDefault(t => t.id_tamano == cliente.id_tamano)?.descripcion ?? "Tamaño desconocido";

                        dgvClientes.Rows.Add(
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
                    comboBoxPreventista.SelectedIndex = -1;
                    cargandoFormulario = false;
                }
                else
                {
                    MessageBox.Show("El preventista seleccionado no tiene asignada una zona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoFormulario || comboBoxTipo.SelectedIndex == -1)
                return;

            string tipoSeleccionado = comboBoxTipo.SelectedItem.ToString();
            List<CLIENTE> listaClientes = null;

            if (tipoSeleccionado == "Cuenta Corriente")
            {
                listaClientes = clienteLogica.ObtenerClientesConfiables();
                CargarClientesEnGrid(listaClientes);

                dataGridViewCuentaCorriente.Visible = true;
                dataGridViewCuentaCorriente.Rows.Clear();

                foreach (var cliente in listaClientes)
                {
                    var cuenta = clienteLogica.ObtenerCuentaCorrientePorIdCliente(cliente.id_cliente);
                    if (cuenta != null)
                    {
                        dataGridViewCuentaCorriente.Rows.Add(
                            cliente.id_cliente,
                            $"{cliente.nombre} {cliente.apellido}",
                            cuenta.saldo_actual.ToString("C"),
                            cuenta.fecha_ultimo_movimiento.ToString("dd/MM/yyyy")
                        );
                    }
                }
            }
            else if (tipoSeleccionado == "Contado")
            {
                listaClientes = clienteLogica.ObtenerClientesNoConfiables();
                CargarClientesEnGrid(listaClientes);

                // Limpiar y ocultar el grid de cuenta corriente
                dataGridViewCuentaCorriente.Rows.Clear();
                dataGridViewCuentaCorriente.Visible = false;
            
            }
            else
            {
                listaClientes = clienteLogica.ObtenerClientes();
                CargarClientesEnGrid(listaClientes);

                // Limpiar y ocultar el grid de cuenta corriente
                dataGridViewCuentaCorriente.Rows.Clear();
                dataGridViewCuentaCorriente.Visible = false;
            }           
           
        }

        private void comboBoxZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filtrar clientes por zona seleccionada
            if (cargandoFormulario || comboBoxZona.SelectedIndex == -1)
                return;
            if (comboBoxZona.SelectedItem is ZONA zonaSeleccionada)
            {
                comboBoxZona.SelectedIndex = -1;
                int idZona = zonaSeleccionada.id_zona;
                List<CLIENTE> clientes = clienteLogica.ClientesPorZona(idZona);
                dgvClientes.Rows.Clear();
                var zonas = clienteLogica.ObtenerZonas();
                var tamanos = clienteLogica.ObtenerTamanos();
                foreach (var cliente in clientes)
                {
                    string estadoTexto = cliente.estado ? "Activo" : "Inactivo";
                    string confiableTexto = cliente.confiable ? "Si" : "No";
                    string nombreZona = zonas.FirstOrDefault(z => z.id_zona == cliente.id_zona)?.nombre ?? "Zona desconocida";
                    string nombreTamano = tamanos.FirstOrDefault(t => t.id_tamano == cliente.id_tamano)?.descripcion ?? "Tamaño desconocido";
                    dgvClientes.Rows.Add(
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
                cargandoFormulario = false;
            }
        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoFormulario || comboBoxEstado.SelectedIndex == -1)
                return;

            string estadoSeleccionado = comboBoxEstado.SelectedItem.ToString();
            List<CLIENTE> listaClientes;

            if (estadoSeleccionado == "Activo")
            {
                listaClientes = clienteLogica.ObtenerClientesActivos();
            }
            else if (estadoSeleccionado == "Inactivo")
            {
                listaClientes = clienteLogica.ObtenerClientesInactivos();
            }
            else
            {
                listaClientes = clienteLogica.ObtenerClientes();
            }

            CargarClientesEnGrid(listaClientes);
            comboBoxEstado.SelectedIndex = -1;
        }

        private void comboBoxTamano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoFormulario || comboBoxTamano.SelectedIndex == -1)
                return;

            if (comboBoxTamano.SelectedValue is int idTamano)
            {
                List<CLIENTE> clientesFiltrados = clienteLogica.ObtenerClientesPorTamanio(idTamano);
                CargarClientesEnGrid(clientesFiltrados);
            }
            else
            {
                MessageBox.Show("No se pudo obtener el tamaño seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comboBoxTamano.SelectedIndex = -1;
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Columns[e.ColumnIndex].Name == "btnVerPedidos")
            {
                // Obtener ID del cliente seleccionado
                int idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["id_cliente"].Value);

                // Obtener pedidos del cliente desde la capa lógica
                var pedidos = pedidoLogica.ObtenerPedidosPorIdCliente(idCliente);

                // Mostrar solo el grid de pedidos
                dgvClientes.Visible = true;
                dataGridViewDetallePagos.Visible = false;
                dataGridViewVerPedidos.Visible = true;

                // Limpiar y cargar pedidos
                dataGridViewVerPedidos.Rows.Clear();
                foreach (var pedido in pedidos)
                {
                    var cliente = clienteLogica.ObtenerClientePorId(pedido.id_cliente);
                    string nombreCliente = cliente != null ? $"{cliente.nombre} {cliente.apellido}" : "Desconocido";
                    var empleado = empleadoLogica.ObtenerEmpleadoPorNombreUsuario(pedido.vendedor);
                    string nombreVendedor = empleado != null ? $"{empleado.nombre} {empleado.apellido}" : "Vendedor desconocido";
                    string estadoTexto = pedido.id_estado == 1 ? "Pendiente" :
                                         pedido.id_estado == 2 ? "En proceso" :
                                         pedido.id_estado == 3 ? "Entregado" :
                                         pedido.id_estado == 4 ? "Cancelado" : "Desconocido";

                    dataGridViewVerPedidos.Rows.Add(
                        pedido.id_pedido,
                        pedido.fecha_creacion.ToString("dd/MM/yyyy"),
                        pedido.fecha_entrega.ToString("dd/MM/yyyy"),
                        pedido.id_cliente,
                        nombreCliente,
                        pedido.id_estado,
                        estadoTexto,
                        pedido.total.ToString("C"),
                        pedido.numero_factura,
                        nombreVendedor
                    );
                }
            }
        }

        private void dataGridViewVerPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewVerPedidos.Columns[e.ColumnIndex].Name == "btnVerPagos")
            {
                int idPedido = Convert.ToInt32(dataGridViewVerPedidos.Rows[e.RowIndex].Cells["id_pedido"].Value);

                // Obtener pagos relacionados al pedido
                var pagosRelacionados = pagoLogica.ObtenerPedidoPagosPorIdPedido(idPedido);

                // Mostrar solo el grid de pagos
                dgvClientes.Visible = true;
                dataGridViewVerPedidos.Visible = true;
                dataGridViewDetallePagos.Visible = true;

                // Limpiar y cargar pagos
                dataGridViewDetallePagos.Rows.Clear();
                foreach (var pedidoPago in pagosRelacionados)
                {
                    // Obtener datos del pago
                    var pago = pagoLogica.ObtenerPagoPorId(pedidoPago.id_pago); // Debés tener esta función en tu lógica
                    var cliente = clienteLogica.ObtenerClientePorId(pago.id_cliente);
                    var metodo = pagoLogica.ObtenerMetodoPagoPorId(pago.id_metodo);

                    string nombreCliente = cliente != null ? $"{cliente.nombre} {cliente.apellido}" : "Desconocido";
                    string nombreMetodo = metodo != null ? metodo.descripcion : "Método desconocido";

                    dataGridViewDetallePagos.Rows.Add(
                        pago.id_pago,
                        pago.id_cliente,
                        nombreCliente,
                        pago.monto.ToString("C"),
                        pago.fecha.ToString("dd/MM/yyyy"),
                        pago.id_metodo,
                        nombreMetodo
                    );
                }
            }
        }

        private void dataGridViewCuentaCorriente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            var listaClientes = clienteLogica.ObtenerClientes();
            CargarClientesEnGrid(listaClientes);
            // Ocultar otros grids si estaban visibles
            dataGridViewDetallePagos.Visible = false;
            dataGridViewVerPedidos.Visible = false;
            dataGridViewCuentaCorriente.Visible = false;

            dgvClientes.Visible = true;
        }
    }
}

