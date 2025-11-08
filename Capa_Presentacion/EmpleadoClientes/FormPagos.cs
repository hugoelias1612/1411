using Capa_Entidades;
using Capa_Logica;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;

namespace ArimaERP.EmpleadoClientes
{
    public partial class FormPagos : Form
    {
        ClassClienteLogica clienteLogica = new ClassClienteLogica();
        ClassEmpleadoLogica empleadoLogica = new ClassEmpleadoLogica();
        ClassPedidoLogica pedidoLogica = new ClassPedidoLogica();
        ClassPagoLogica pagoLogica = new ClassPagoLogica();
        ClassUsuarioLogica usuarioLogica = new ClassUsuarioLogica();
        ClassProductoLogica productoLogica = new ClassProductoLogica();
        // Declarar btnPagar como campo de clase para que esté disponible en todo el formulario
        private DataGridViewButtonColumn btnPagar;
        public FormPagos()
        {
            InitializeComponent();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            //cerrar
            this.Close();
        }
        private void FormPagos_Load(object sender, EventArgs e)
        {
            
            //crear dataGridviewPedidos con columnas
            dataGridViewPedidos.Columns.Add("id_pedido", "ID_Pedido");
            dataGridViewPedidos.Columns.Add("fecha_entrega", "Fecha de Entrega");
            dataGridViewPedidos.Columns.Add("fecha_vencimiento", "Fecha Vencimiento");
            dataGridViewPedidos.Columns.Add("id_cliente", "ID_Cliente");
            //ocultar columna id_cliente
            dataGridViewPedidos.Columns["id_cliente"].Visible = false;
            dataGridViewPedidos.Columns.Add("nombre_cliente", "Nombre Cliente");
            dataGridViewPedidos.Columns.Add("total", "Total");
            dataGridViewPedidos.Columns.Add("saldo", "Saldo");
            dataGridViewPedidos.Columns.Add("estado_pago", "Estado de Pago");
            dataGridViewPedidos.Columns.Add("numero_factura", "Factura N°");
            dataGridViewPedidos.Columns.Add("vendedor", "Vendedor");
            //ocultar columna vendedor
            dataGridViewPedidos.Columns["vendedor"].Visible = false;
            dataGridViewPedidos.Columns.Add("nombre_vendedor", "Vendedor");

            //Agregar botón pagar
            btnPagar = new DataGridViewButtonColumn();
            btnPagar.HeaderText = "Generar Pago";
            btnPagar.Name = "pagar";
            btnPagar.Text = "Pagar";
            btnPagar.UseColumnTextForButtonValue = true;
            dataGridViewPedidos.Columns.Add(btnPagar);
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.MultiSelect = false;
            dataGridViewPedidos.AllowUserToAddRows = false;
            //NO permitir modificar el ancho de las filas
            dataGridViewPedidos.AllowUserToResizeRows = false;
            //agregar btnVerPagos
            DataGridViewButtonColumn btnVerPagos = new DataGridViewButtonColumn();
            btnVerPagos.HeaderText = "Pagos";
            btnVerPagos.Name = "btnVerPagos";
            btnVerPagos.Text = "Ver Pagos";
            btnVerPagos.UseColumnTextForButtonValue = true;
            dataGridViewPedidos.Columns.Add(btnVerPagos);
            //cargar zonas en comboBoxClienteZona
            var zonas = clienteLogica.ObtenerZonas();
            comboBoxClienteZona.DataSource = zonas;
            comboBoxClienteZona.DisplayMember = "nombre";
            comboBoxClienteZona.ValueMember = "id_zona";
            comboBoxClienteZona.SelectedIndex = -1; // No seleccionar nada al inicio
            //cargar metodos de pago en comboBoxMetodoPago desde ClassPagoLogica            
            var metodosPago = pagoLogica.ObtenerMetodosPago();
            comboBoxMetodoPago.DataSource = metodosPago;
            comboBoxMetodoPago.DisplayMember = "descripcion";
            comboBoxMetodoPago.ValueMember = "id_metodo";
            comboBoxMetodoPago.SelectedIndex = -1; // No seleccionar nada al inicio
            //Cargar todos los pedidos en el dataGridViewPedidos
            List<PEDIDO> todosLosPedidos = pedidoLogica.ObtenerPedidosEntregados();
            CargarPedidosEnDataGridView(todosLosPedidos);
            //Crear columnas de dataGridViewDetallePagos
            dataGridViewDetallePagos.Columns.Add("id_pago", "ID_Pago");
            dataGridViewDetallePagos.Columns.Add("monto", "Monto");
            dataGridViewDetallePagos.Columns.Add("fecha", "Fecha de Pago");
            dataGridViewDetallePagos.Columns.Add("id_metodo", "ID_Metodo");
            dataGridViewDetallePagos.Columns.Add("metodo_pago", "Método de Pago");
            dataGridViewDetallePagos.Columns.Add("id_cliente", "ID_Cliente");
            dataGridViewDetallePagos.Columns.Add("nombre_cliente", "Nombre Cliente");
            //Ocultar columnas id_metodo e id_cliente
            dataGridViewDetallePagos.Columns["id_metodo"].Visible = false;
            dataGridViewDetallePagos.Columns["id_cliente"].Visible = false;
            dataGridViewDetallePagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDetallePagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDetallePagos.MultiSelect = false;
            dataGridViewDetallePagos.AllowUserToAddRows = false;
            //NO permitir modificar el ancho de las filas
            dataGridViewDetallePagos.AllowUserToResizeRows = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiar datGridViewDetallePagos
            dataGridViewDetallePagos.Rows.Clear();
            //Limpiar textBoxCliente
            textBoxCliente.Text = "";
            //Limpiar txtMonto
            txtMonto.Text = "";
            //Limpiar txtIdCliente
            txtIdCliente.Text = "";
            //Eliminar selección de comboBoxMetodoPago
            comboBoxMetodoPago.SelectedIndex = -1;
        }

        private void btnRegistrarNuevo_Click(object sender, EventArgs e)
        {
            // Validar campo Monto
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                errorProvider1.SetError(txtMonto, "El campo Monto es obligatorio.");
                return;
            }
            errorProvider1.SetError(txtMonto, "");

            // Validar campo Cliente
            if (string.IsNullOrWhiteSpace(textBoxCliente.Text))
            {
                errorProvider1.SetError(textBoxCliente, "El campo Cliente es obligatorio.");
                return;
            }
            errorProvider1.SetError(textBoxCliente, "");

            // Validar método de pago
            if (comboBoxMetodoPago.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBoxMetodoPago, "Debe seleccionar un método de pago.");
                return;
            }
            errorProvider1.SetError(comboBoxMetodoPago, "");

            // Obtener datos del pedido seleccionado
            if (dataGridViewPedidos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dataGridViewPedidos.CurrentRow;
            int idPedido = Convert.ToInt32(fila.Cells["id_pedido"].Value);
            //Obtener PEDIDO por id_pedido
            var pedido = pedidoLogica.ObtenerPedidoPorId(idPedido);

            decimal saldo;
            // Obtener el saldo actual del pedido desde base de datos
            var ultimoPago = pagoLogica.ObtenerUltimoPedidoPagoPorIdPedido(idPedido);
            if (ultimoPago != null)
            {
                saldo = ultimoPago.saldo;
                //Si el saldo es 0.00, el pedido se encuentra completamente abonado
                if (saldo == 0m)
                {
                    MessageBox.Show("El pedido ya se encuentra completamente abonado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Salir del flujo de pago
                }

            }
            else
            {
                // No hay registros → usar el total del pedido como saldo inicial
                saldo = pedido.total;
            }

            decimal monto;
            if (!decimal.TryParse(txtMonto.Text, out monto) || monto <= 0)
            {
                MessageBox.Show("El monto debe ser un número mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (monto > saldo)
            {
                MessageBox.Show("El monto ingresado no puede ser mayor al saldo del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener datos del cliente y método de pago
            int id_cliente = Convert.ToInt32(txtIdCliente.Text);
            int id_metodo = Convert.ToInt32(comboBoxMetodoPago.SelectedValue);
            DateTime fecha = DateTime.Today;

            // Registrar el pago
            int idPagoGenerado = pagoLogica.CrearNuevoPago(monto, fecha, id_metodo, id_cliente);
            if (idPagoGenerado == -1)
            {
                MessageBox.Show("Error al registrar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Registrar en pedido_pago con saldo actualizado
            decimal nuevoSaldo = saldo - monto;
            bool registrado = pagoLogica.CrearNuevopedido_pago(idPedido, idPagoGenerado, nuevoSaldo);
            if (!registrado)
            {
                MessageBox.Show("Error al registrar el pago en el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ajustar cuenta corriente si el cliente es confiable
            var cliente = clienteLogica.ObtenerClientePorId(id_cliente);
            if (cliente != null && cliente.confiable)
            {
                bool actualizado = clienteLogica.AjustarSaldo(id_cliente, -monto);
                if (!actualizado)
                {
                    MessageBox.Show("No se pudo actualizar el saldo de la cuenta corriente del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            MessageBox.Show("Pago registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (pedido.numero_factura == null)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Desea generar el comprobante de factura para este pedido?",
                    "Generar factura",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    // Generar número de factura
                    int numeroGenerado = pedidoLogica.GenerarNumeroFactura(idPedido);
                    if (numeroGenerado > 0)
                    {
                        // Obtener detalles del pedido
                        var detalles = pedidoLogica.ObtenerDetallesPedido(idPedido);
                        // Generar el PDF
                        GenerarComprobanteFactura(pedidoLogica.ObtenerPedidoPorId(idPedido), detalles);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo generar el número de factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Refrescar grillas
            CargarPedidosEnDataGridView(pedidoLogica.ObtenerPedidosEntregados());
            btnLimpiar.PerformClick();
        }


        private void txtBuscarPedidosCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string textoBusqueda = txtBuscarPedidosCliente.Text.Trim();

                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    MessageBox.Show("Debe ingresar un DNI o Email para buscar.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? idCliente = pedidoLogica.ObtenerIdClientePorTexto(textoBusqueda);

                dataGridViewPedidos.Rows.Clear();

                if (idCliente.HasValue)
                {
                    List<PEDIDO> pedidos = pedidoLogica.ObtenerPedidosEntregadosPorIdCliente(idCliente.Value);
                    CargarPedidosEnDataGridView(pedidos);
                }
                else
                {
                    MessageBox.Show("No se encontró ningún cliente con ese DNI o Email.", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Función para sumar días hábiles
        private DateTime SumarDiasHabiles(DateTime fecha, int diasHabiles)
        {
            int diasSumados = 0;
            DateTime resultado = fecha;
            while (diasSumados < diasHabiles)
            {
                resultado = resultado.AddDays(1);
                if (resultado.DayOfWeek != DayOfWeek.Saturday && resultado.DayOfWeek != DayOfWeek.Sunday)
                {
                    diasSumados++;
                }
            }
            return resultado;
        }

        private void txtMontoMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir el ingreso de numeros y un punto decimal únicamente
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                errorProvider1.SetError(txtMontoMaximo, "Solo se permiten números y un punto decimal.");
            }
            else if (e.KeyChar == '.' && txtMontoMaximo.Text.Contains('.'))
            {
                e.Handled = true; // No permitir más de un punto decimal
                errorProvider1.SetError(txtMontoMaximo, "Solo se permite un punto decimal.");
            }
            else
            {
                errorProvider1.SetError(txtMontoMaximo, ""); // Limpiar el error si la entrada es válida
            }
        }

        private void textBoxNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ingresar solo números y no mas de 10 caracteres
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBoxNumeroFactura, "Ingrese solo números.");
            }
            else if (
                textBoxNumeroFactura.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBoxNumeroFactura, "No puede ingresar más de 10 caracteres.");
            }
            else
            {
                errorProvider1.SetError(textBoxNumeroFactura, "");
            }
        }

        private void textBoxNumeroFactura_KeyDown(object sender, KeyEventArgs e)
        {
            //Obtener pedido por número de factura al presionar Enter
            if (e.KeyCode == Keys.Enter)
            {
                string textoBusqueda = textBoxNumeroFactura.Text.Trim();
                if (int.TryParse(textoBusqueda, out int numeroFactura))
                {
                    // Limpiar el DataGrid antes de cargar nuevos datos
                    dataGridViewPedidos.Rows.Clear();
                    // Obtener el pedido por número de factura
                    PEDIDO pedido = pedidoLogica.ObtenerPedidoEntregadoPorNumeroFactura(numeroFactura);
                    if (pedido != null)
                    {
                        //Obtener CLIENTE por pedido.id_cliente
                        var cliente = clienteLogica.ObtenerClientePorId(pedido.id_cliente);
                        string nombreCompleto = $"{cliente.nombre} {cliente.apellido}";
                        //Obtener VENDEDOR por pedido.vendedor
                        var empleado = empleadoLogica.ObtenerEmpleadoPorNombreUsuario(pedido.vendedor);
                        string nombreVendedor = $"{empleado.nombre} {empleado.apellido}";
                        //Si el cliente no es confiable la fecha vencimiento es igual a la fecha_entrega si no la fecha vencimiento es igual a la fecha_entrega mas 5 días hábiles
                        DateTime fecha_vencimiento;
                        DateTime.TryParse(pedido.fecha_entrega.ToString("dd/MM/yyyy"), out fecha_vencimiento);
                        
                        /*Obtener el valor del saldo de la tabla pedido_pago para este id_pedido, si no se encuentra ningún registro para ese pedido
                         el saldo es igual al total del pedido*/

                        if (cliente.confiable)
                        {
                            fecha_vencimiento = SumarDiasHabiles(pedido.fecha_entrega, 5);                           
                            
                        }
                        else
                        {
                            fecha_vencimiento = pedido.fecha_entrega;
                            
                        }

                        decimal saldo;
                        // Obtener el saldo actual del pedido desde base de datos
                        var ultimoPago = pagoLogica.ObtenerUltimoPedidoPagoPorIdPedido(pedido.id_pedido);
                        if (ultimoPago != null)
                        {
                            saldo = ultimoPago.saldo;
                            

                        }
                        else
                        {
                            // No hay registros → usar el total del pedido como saldo inicial
                            saldo = pedido.total;
                        }

                        dataGridViewPedidos.Rows.Add(
                            pedido.id_pedido,
                            pedido.fecha_entrega.ToString("dd/MM/yyyy"),
                            fecha_vencimiento.ToString("dd/MM/yyyy"),
                            pedido.id_cliente,
                            nombreCompleto,
                            pedido.total.ToString(),
                            saldo.ToString(),
                            pedido.numero_factura,
                            pedido.vendedor,
                            nombreVendedor
                        );
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún pedido con ese número de factura.", "Pedido no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un número de factura válido.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtMontoMaximo_KeyDown(object sender, KeyEventArgs e)
        {
            //filtrar pedidos por monto máximo al presionar Enter
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewPedidos.Rows.Clear();
                string textoBusqueda = txtMontoMaximo.Text.Trim();
                if (decimal.TryParse(textoBusqueda, out decimal montoMaximo))
                {
                    // Limpiar el DataGrid antes de cargar nuevos datos
                    dataGridViewPedidos.Rows.Clear();
                    // Obtener los pedidos por monto máximo
                    List<PEDIDO> pedidosPorMonto = pedidoLogica.ObtenerPedidosEntregadosPorMontoMaximo(montoMaximo);
                    CargarPedidosEnDataGridView(pedidosPorMonto);
                }
                else
                {
                    MessageBox.Show("Ingrese un monto válido.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void CargarPedidosEnDataGridView(List<PEDIDO> pedidos)
        {
            dataGridViewPedidos.Rows.Clear();

            foreach (var pedido in pedidos)
            {
                var cliente = clienteLogica.ObtenerClientePorId(pedido.id_cliente);
                string nombreCompleto = $"{cliente.nombre} {cliente.apellido}";

                DateTime fecha_vencimiento = cliente.confiable
                    ? SumarDiasHabiles(pedido.fecha_entrega, 5)
                    : pedido.fecha_entrega;

                decimal saldo;
                var ultimoPago = pagoLogica.ObtenerUltimoPedidoPagoPorIdPedido(pedido.id_pedido);
                saldo = ultimoPago?.saldo ?? pedido.total;

                var empleado = empleadoLogica.ObtenerEmpleadoPorNombreUsuario(pedido.vendedor);
                string nombreVendedor = $"{empleado.nombre} {empleado.apellido}";

                int rowIndex = dataGridViewPedidos.Rows.Add(
                    pedido.id_pedido,
                    pedido.fecha_entrega.ToString("dd/MM/yyyy"),
                    fecha_vencimiento.ToString("dd/MM/yyyy"),
                    pedido.id_cliente,
                    nombreCompleto,
                    pedido.total,
                    saldo,
                    saldo == 0m ? "PAGADO" : "DEBE",
                    pedido.numero_factura,
                    pedido.vendedor,
                    nombreVendedor                    
                );

                // Aplicar color
                var estadoCell = dataGridViewPedidos.Rows[rowIndex].Cells["estado_pago"];
                estadoCell.Style.ForeColor = saldo == 0m ? Color.Blue : Color.Red;
                // Reemplaza la línea problemática en el método CargarPedidosEnDataGridView:
                // estadoCell.Style.Font = new Font(dataGridViewPedidos.DefaultCellStyle.Font, FontStyle.Bold);

                // Solución: Usa System.Drawing.Font directamente para establecer el estilo en el DataGridView.
                // System.Drawing.Font tiene un constructor que acepta (Font font, FontStyle style).
                estadoCell.Style.Font = new System.Drawing.Font(dataGridViewPedidos.DefaultCellStyle.Font, saldo == 0m ? FontStyle.Bold : FontStyle.Regular);
                
                // Inhabilitar botón "Pagar" si está pagado
                var pagarCell = dataGridViewPedidos.Rows[rowIndex].Cells["pagar"];
                pagarCell.ReadOnly = saldo == 0m;
                pagarCell.Style.ForeColor = saldo == 0m ? Color.Gray : Color.Black;
            }

        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir el ingreso de numeros y un punto decimal únicamente
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                errorProvider1.SetError(txtMontoMaximo, "Solo se permiten números y un punto decimal.");
            }
            else if (e.KeyChar == '.' && txtMontoMaximo.Text.Contains('.'))
            {
                e.Handled = true; // No permitir más de un punto decimal
                errorProvider1.SetError(txtMontoMaximo, "Solo se permite un punto decimal.");
            }
            else
            {
                errorProvider1.SetError(txtMontoMaximo, ""); // Limpiar el error si la entrada es válida
            }
        }

        private void btnFechaEntrega_Click(object sender, EventArgs e)
        {
            //Obtener todos los pedidos con la fecha de Vencimiento indicada en dateTimePicker1
            DateTime fechaSeleccionada = dateTimePicker1.Value.Date;
            List<PEDIDO> pedidosPorFecha = pedidoLogica.ObtenerPedidosEntregadosPorFechaEntrega(fechaSeleccionada);
            CargarPedidosEnDataGridView(pedidosPorFecha);
        }

        private void btnCreacion_Click(object sender, EventArgs e)
        {
            //Obtener todos los pedidos con la fecha de creación indicada en dateTimePicker4
            DateTime fechaSeleccionada = dateTimePicker4.Value.Date;
            List<PEDIDO> pedidosPorFecha = pedidoLogica.ObtenerPedidosEntregadosPorFechaCreacion(fechaSeleccionada);
            CargarPedidosEnDataGridView(pedidosPorFecha);
        }

        private void comboBoxClienteZona_SelectedIndexChanged(object sender, EventArgs e)
        {

            //filtrar clientes por zona seleccionada
            if (comboBoxClienteZona.SelectedValue is int idZona && idZona > 0)
            {
                dataGridViewPedidos.Rows.Clear();
                //Obtener todos los clientes de la zona seleccionada
                List<CLIENTE> clientesEnZona = clienteLogica.ClientesPorZona(idZona);

                foreach (var cliente in clientesEnZona)
                {
                    List<PEDIDO> pedidosDelCliente = pedidoLogica.ObtenerPedidosEntregadosPorIdCliente(cliente.id_cliente);
                    //cargar pedidos en dataGridViewModificarPedidos
                    CargarPedidosEnDataGridView(pedidosDelCliente);
                }
                comboBoxClienteZona.SelectedIndex = -1; //resetear comboBox después de filtrar
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permitir solo números en el campo DNI y no mas de 8 caracteres
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtDNI, "Ingrese solo números.");
            }
            else if (
                txtDNI.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtDNI, "No puede ingresar más de 8 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtDNI, "");

            }
        }

        private void txtDNI_KeyDown(object sender, KeyEventArgs e)
        {
            //Por el DNI buscar empleado y validar con nombre_usuario que sea un usuario de id_rol = 5 al presionar Enter.Luego buscar los pedidos de ese empleado
            if (e.KeyCode == Keys.Enter)
            {
                string textoBusqueda = txtDNI.Text.Trim();
                //convertir textoBusqueda a int
                int dniBusqueda = int.Parse(textoBusqueda);
                // Obtener el empleado por DNI
                Empleado empleado = empleadoLogica.ObtenerEmpleadoPorDNI(dniBusqueda);
                //Obtener Usuario por nombre_usuario del empleado
                if (empleado != null)
                {
                    var usuario = usuarioLogica.ObtenerUsuarioPorNombre(empleado.nombre_usuario);
                    if (usuario != null)
                    {
                        if (usuario.id_rol != 5)
                        {
                            MessageBox.Show("El empleado no es un preventista.", "Empleado no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún usuario asociado al empleado.", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ningún empleado con ese DNI.", "Empleado no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Limpiar el DataGrid antes de cargar nuevos datos
                dataGridViewPedidos.Rows.Clear();
                {
                    // Obtener los pedidos del empleado
                    List<PEDIDO> pedidos = pedidoLogica.ObtenerPedidosEntregadosPorVendedor(empleado.nombre_usuario);
                    CargarPedidosEnDataGridView(pedidos);
                }

            }
        }

        private void dataGridViewPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cuando se presiona el botón btnVerPagos cargar los pagos del id_pedido desde tabla pedido_pago de base de datos, en dataGridViewDetallePagos
            if (e.RowIndex >= 0 && dataGridViewPedidos.Columns[e.ColumnIndex].Name == "btnVerPagos")
            {
                // Obtener el id_pedido de la fila seleccionada
                int idPedido = Convert.ToInt32(dataGridViewPedidos.Rows[e.RowIndex].Cells["id_pedido"].Value);
                // Limpiar el DataGrid antes de cargar nuevos datos
                dataGridViewDetallePagos.Rows.Clear();
                // Obtener los registros de pedido_pago asociados al pedido
                List<pedido_pago> pagosDelPedido = pagoLogica.ObtenerPedidoPagosPorIdPedido(idPedido);
                foreach (var pedidoPago in pagosDelPedido)
                {
                    // Obtener el pago completo por id_pago
                    var pago = pagoLogica.ObtenerPagoPorId(pedidoPago.id_pago);
                    if (pago != null)
                    {
                        // Obtener CLIENTE por pago.id_cliente
                        var cliente = clienteLogica.ObtenerClientePorId(pago.id_cliente);
                        string nombreCompleto = cliente != null ? $"{cliente.nombre} {cliente.apellido}" : "";
                        // Obtener METODO DE PAGO por pago.id_metodo
                        var metodoPago = pagoLogica.ObtenerMetodoPagoPorId(pago.id_metodo);
                        string descripcionMetodo = metodoPago != null ? metodoPago.descripcion : "";
                        dataGridViewDetallePagos.Rows.Add(
                            pago.id_pago,
                            pago.monto,
                            pago.fecha.ToString("dd/MM/yyyy"),
                            pago.id_metodo,
                            descripcionMetodo,
                            pago.id_cliente,
                            nombreCompleto
                        );
                    }
                }
            }
            else if (e.RowIndex >= 0 && dataGridViewPedidos.Columns[e.ColumnIndex].Name == "pagar")
            {
                /*Si el cliente no es confiable el monto a pagar tiene que ser el saldo total  del pedido, cargar en el txtMonto y no permitir editar txtMonto,
                 y si es confiable puede abonar una valor menor al total del pedido, también cargar el saldo en el txtMonto y permitir editar txtMonto */
                // Obtener el id_pedido de la fila seleccionada
                int idPedido = Convert.ToInt32(dataGridViewPedidos.Rows[e.RowIndex].Cells["id_pedido"].Value);
                var ultimoPedidoPago = pagoLogica.ObtenerUltimoPedidoPagoPorIdPedido(idPedido);
                //Obtener PEDIDO por id_pedido
                var pedido = pedidoLogica.ObtenerPedidoPorId(idPedido);
                // Obtener el cliente asociado al pedido
                int idCliente = pedido.id_cliente;
                var cliente = clienteLogica.ObtenerClientePorId(idCliente);

                if (ultimoPedidoPago != null)
                {
                    decimal ultimoSaldo = ultimoPedidoPago.saldo;
                    if (ultimoSaldo == 0m)
                    {
                        MessageBox.Show("Este pedido ya está pagado. No se puede generar un nuevo pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if(cliente.confiable)
                    {
                        txtMonto.Text = ultimoSaldo.ToString();
                    }
                }
                else
                {
                    txtMonto.Text = pedido.total.ToString();
                }
                    
               
         
                //Cargar id_cliente en txtIdCliente
                txtIdCliente.Text = idCliente.ToString();
                
                //Mostrar nombre del cliente en textBoxCliente
                textBoxCliente.Text = $" {cliente.nombre} {cliente.apellido}";                   
                          
                 
                //Si el cliente es confiable puede editar txtMonto
                if (cliente.confiable)
                {
                    txtMonto.ReadOnly= false;
                }
                else
                {
                    txtMonto.ReadOnly = true;
                }
             
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            CargarPedidosEnDataGridView(pedidoLogica.ObtenerPedidosEntregados());
        }
        private void GenerarComprobanteFactura(PEDIDO pedido, List<DETALLE_PEDIDO> detalles)
        {
            string nombreArchivo = pedido.id_estado == 4 ? $"Factura_{pedido.numero_factura}_ANULADA.pdf" : $"Factura_{pedido.numero_factura}.pdf";

            string rutaArchivo = Path.Combine(Application.StartupPath, nombreArchivo);
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
            doc.Open();
            // Verificar si el pedido está cancelado
            var estadoPedido = pedido.id_estado;
            bool esCancelado = estadoPedido == 4;
            if (esCancelado)
            {
                // Agregar leyenda "ANULADO" en rojo y centrado
                Paragraph anulacion = new Paragraph("ANULADO", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 30, BaseColor.RED));
                anulacion.Alignment = Element.ALIGN_CENTER;
                doc.Add(anulacion);

                // Espacio visual
                doc.Add(new Paragraph("\n\n"));
            }
            var cliente = clienteLogica.ObtenerClientePorId(pedido.id_cliente);
            var vendedor = empleadoLogica.ObtenerEmpleadoPorNombreUsuario(pedido.vendedor);
            // Encabezado
            doc.Add(new Paragraph($"Razón Social: Distribuidora J.K.     Factura N° 2025-{pedido.numero_factura}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
            doc.Add(new Paragraph("CUIT: 30-71234567-8"));
            doc.Add(new Paragraph("I.V.A Responsable Inscripto"));
            doc.Add(new Paragraph("Dirección Comercial: Av. Libertad 1450,Corrientes Capital, Corrientes, Argentina"));
            doc.Add(new Paragraph("Teléfono: +54 9 (379) 4456789"));
            doc.Add(new Paragraph("Sucursal: Corrientes Centro"));
            doc.Add(new Paragraph("Inscripción AFIP: Nº 123456789 – Fecha de alta: 12/03/2010"));
            doc.Add(new Paragraph("--------------------------------------------------"));
            //Obtener fecha actual
            DateTime fechaActual = DateTime.Now;
            doc.Add(new Paragraph($"Fecha: {fechaActual.ToShortDateString()}"));
            doc.Add(new Paragraph("--------------------------------------------------"));
            doc.Add(new Paragraph($"Cliente: {cliente.nombre} {cliente.apellido}"));
            doc.Add(new Paragraph($"DNI: {cliente.dni}"));
            doc.Add(new Paragraph($"Dirección: {cliente.calle} {cliente.numero}, {cliente.ciudad}, {cliente.provincia}, CP: {cliente.cod_postal}"));
            doc.Add(new Paragraph($"Condición frente al IVA: {cliente.condicion_frenteIVA}"));
            doc.Add(new Paragraph("--------------------------------------------------"));
            doc.Add(new Paragraph($"Vendedor: {vendedor.nombre} {vendedor.apellido}"));
            doc.Add(new Paragraph("--------------------------------------------------"));
            // Tabla de detalles
            PdfPTable tabla = new PdfPTable(8);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 2f, 2f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 2f });
            Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
            string[] encabezados = { "Producto", "Presentación", "Cant. Unidades", "Cant. Bultos", "Precio Unitario", "Subtotal", "Descuento", "Total Producto" };
            foreach (string titulo in encabezados)
            {
                PdfPCell celda = new PdfPCell(new Phrase(titulo, fontHeader));
                celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.Padding = 3;
                tabla.AddCell(celda);
            }

            foreach (var detalle in detalles)
            {
                var producto = productoLogica.ObtenerProductoPorId(detalle.id_producto);
                var presentacion = productoLogica.ObtenerPresentacionPorId(detalle.ID_presentacion);
                var productoPresentacion = productoLogica.ObtenerProductoPresentacionPorProductoYPresentacion(producto.id_producto, presentacion.ID_presentacion);
                decimal subtotal = (detalle.cantidad ?? 0 + (detalle.cantidad_bultos ?? 0)) * detalle.precio_unitario;
                decimal totalProducto = subtotal - detalle.descuento;
                Font fontDetalle = FontFactory.GetFont(FontFactory.HELVETICA, 9); // mismo tamaño que fontHeader
                tabla.AddCell(new Phrase(producto.nombre.ToString(), fontDetalle));
                tabla.AddCell(new Phrase($"{presentacion.descripcion}\n{productoPresentacion.unidades_bulto} unidades/bulto", fontDetalle));
                tabla.AddCell(new Phrase((detalle.cantidad ?? 0).ToString(), fontDetalle));
                tabla.AddCell(new Phrase((detalle.cantidad_bultos ?? 0).ToString(), fontDetalle));
                tabla.AddCell(new Phrase(detalle.precio_unitario.ToString("C"), fontDetalle));
                tabla.AddCell(new Phrase(subtotal.ToString("C"), fontDetalle));
                tabla.AddCell(new Phrase(detalle.descuento.ToString("C"), fontDetalle));
                tabla.AddCell(new Phrase(totalProducto.ToString("C"), fontDetalle));
            }
            doc.Add(tabla);
            // Total
            doc.Add(new Paragraph("--------------------------------------------------"));
            doc.Add(new Paragraph($"Total:      {pedido.total.ToString("C")}"));
            doc.Close();
            // Mostrar el PDF
            System.Diagnostics.Process.Start(rutaArchivo);
        }
    } 
}
