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

namespace ArimaERP.EmpleadoClientes
{
    
    public partial class FormEditarCliente : Form
    {
        private ClassClienteLogica clienteLog = new ClassClienteLogica();
        private CLIENTE clienteActual;
        ClassAuditoriaLogica auditoriaLogica = new ClassAuditoriaLogica();
        private bool limpiarPresionado = false;



        public FormEditarCliente(CLIENTE cliente)
        {
            InitializeComponent();
            clienteActual = cliente;
        }

        private void FormEditarCliente_Load(object sender, EventArgs e)
        {
            List<TAMAÑO_NEGOCIO> listaTamanos = clienteLog.ObtenerTamanos();
            List<ZONA> zonas = clienteLog.ObtenerZonas();
            //Cargar datos del cliente seleccionado en datagrid
            if (clienteActual != null)
            {
                txtBoxNombre.Text = clienteActual.nombre;
                txtBoxApellido.Text = clienteActual.apellido;
                txtBoxDni.Text = clienteActual.dni.ToString();
                txtBoxCuil.Text = clienteActual.cuil_cuit.ToString();
                txtBoxMovil.Text = clienteActual.telefono.ToString();
                txtMail.Text = clienteActual.email.ToString();
                txtBoxLocalidad.Text = clienteActual.ciudad;
                txtBoxProvincia.Text = clienteActual.provincia;
                txtBoxCalle.Text = clienteActual.calle;
                txtCodigoPostal.Text = clienteActual.cod_postal.ToString();
                txtNumero.Text = clienteActual.numero.ToString();
                checkBoxActivo.Checked = clienteActual.estado;
                checkBoxConfiable.Checked = clienteActual.confiable;
                txtRazonSocial.Text = clienteActual.razon_social;
                comboBoxSeleccionarTamano.DataSource = listaTamanos;
                comboBoxSeleccionarTamano.DisplayMember = "descripcion";
                comboBoxSeleccionarTamano.ValueMember = "id_tamano";
                comboBoxSeleccionarTamano.SelectedValue = clienteActual.id_tamano;
                comboBoxSeleccionarZona.DataSource = zonas;
                comboBoxSeleccionarZona.DisplayMember = "nombre";
                comboBoxSeleccionarZona.ValueMember = "id_zona";
                comboBoxSeleccionarZona.SelectedValue = clienteActual.id_zona;
                comboBoxCondicionFrenteIVA.SelectedItem = clienteActual.condicion_frenteIVA;

                txtBoxNombre.ReadOnly = false;
                txtBoxApellido.ReadOnly = false;
                txtBoxDni.ReadOnly = false;
                txtBoxCuil.ReadOnly = false;
            }
        }
      
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Validar que no existan campos editables vacíos, combobox sin seleccionar o datepicker con fecha futura, excepto razon social que puede estar vacío
            if (string.IsNullOrWhiteSpace(txtBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(txtBoxApellido.Text) ||
                string.IsNullOrWhiteSpace(txtBoxDni.Text) ||
                string.IsNullOrWhiteSpace(txtBoxCuil.Text) ||
                string.IsNullOrWhiteSpace(txtBoxMovil.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text) ||
                string.IsNullOrWhiteSpace(txtBoxCalle.Text) ||
                string.IsNullOrWhiteSpace(txtNumero.Text) ||
                string.IsNullOrWhiteSpace(txtBoxLocalidad.Text) ||
                string.IsNullOrWhiteSpace(txtBoxProvincia.Text) ||
                string.IsNullOrWhiteSpace(txtCodigoPostal.Text)
                )
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((int)comboBoxSeleccionarTamano.SelectedValue == 0 ||
                (int)comboBoxSeleccionarZona.SelectedValue == 0 ||
                comboBoxCondicionFrenteIVA.SelectedIndex == 0 ||
                dateTimePickerFechaAlta.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Por favor seleccione una opción válida en los combobox y asegúrese que la fecha de alta no sea futura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Obtener el ID del cliente que se está modificando
            int idCliente = clienteActual.id_cliente;

            // Validar email único (excluyendo al cliente actual)
            if (clienteLog.ExisteOtroClienteConMismoEmail(idCliente, txtMail.Text))
            {
                MessageBox.Show("Ya existe otro cliente con el email ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar selección de zona y tamaño
            if (comboBoxSeleccionarTamano.SelectedValue == null || comboBoxSeleccionarZona.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione una opción válida en los combobox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string id_tamano = comboBoxSeleccionarTamano.SelectedValue.ToString();
            string id_zona = comboBoxSeleccionarZona.SelectedValue.ToString();
            
            CLIENTE clienteActualizado = clienteLog.ActualizarCliente(idCliente, txtBoxNombre.Text, txtBoxApellido.Text, id_tamano, id_zona, dateTimePickerFechaAlta.Value, txtMail.Text, txtBoxMovil.Text, txtBoxDni.Text, txtBoxCuil.Text, txtBoxCalle.Text, txtNumero.Text, txtBoxLocalidad.Text, txtBoxProvincia.Text, txtRazonSocial.Text, checkBoxActivo.Checked, checkBoxConfiable.Checked, comboBoxCondicionFrenteIVA.SelectedItem.ToString(), txtCodigoPostal.Text);

            if (clienteActualizado != null)
            {
                // Auditoría de modificación
                string usuarioActual = ObtenerUsuarioActual();

                string valorAnterior =
                    $"{clienteActual.nombre}, {clienteActual.apellido}, DNI: {clienteActual.dni}, " +
                    $"CUIL/CUIT: {clienteActual.cuil_cuit}, {clienteActual.email}, " +
                    $"Calle: {clienteActual.calle} Numero: {clienteActual.numero}, Ciudad: {clienteActual.ciudad}, " +
                    $"Fecha Alta: {clienteActual.fecha_alta:dd/MM/yyyy}, Estado: {(clienteActual.estado ? "Activo" : "Inactivo")} "
                    ;

                string valorNuevo =
                    $"{clienteActualizado.nombre}, {clienteActualizado.apellido}, DNI: {clienteActualizado.dni}, " +
                    $"CUIL/CUIT: {clienteActualizado.cuil_cuit}, {clienteActualizado.email}, " +
                    $"Calle: {clienteActualizado.calle} Numero: {clienteActualizado.numero}, Ciudad: {clienteActualizado.ciudad}, " +
                    $"Fecha Alta: {clienteActualizado.fecha_alta:dd/MM/yyyy}, Estado: {(clienteActualizado.estado ? "Activo" : "Inactivo")} "
                    ;

                bool registrado = auditoriaLogica.Registrar(
                    valorAnterior: valorAnterior,
                    valorNuevo: valorNuevo,
                    nombreAccion: "Modificacion",
                    nombreEntidad: "CLIENTE",
                    usuario: usuarioActual
                );

                if (!registrado)
                {
                    MessageBox.Show("Cliente actualizado, pero no se pudo registrar auditoría:\n" +
                        string.Join("\n", auditoriaLogica.ErroresValidacion),
                        "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Verificar si el cliente pasó de no confiable a confiable y está activo
                if (clienteActualizado.estado && !clienteActual.confiable && clienteActualizado.confiable)
                {
                    bool cuentaCreada = clienteLog.CrearCuentaCorriente(clienteActualizado.id_cliente);

                    if (!cuentaCreada)
                    {
                        MessageBox.Show("No se pudo crear la cuenta corriente para el cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Cuenta Corriente creada con éxito");
                    }
                }

                MessageBox.Show("Cliente actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                string errores = string.Join("\n", clienteLog.ErroresValidacion);
                MessageBox.Show("No se pudo actualizar el cliente. Errores:\n" + errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerUsuarioActual()
        {

            return UsuarioSesion.Nombre; // Ejemplo: retorna el nombre del usuario desde una clase estática de sesión
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cierra el formulario sin guardar cambios
            this.Close();
        }

        private void txtBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Convertir a mayúscula la primera letra
            if (txtBoxNombre.Text.Length == 0 && char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            // Permitir solo letras, espacios y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxNombre, "Solo se permiten letras.");
            }
            else if (!char.IsControl(e.KeyChar) && txtBoxNombre.Text.Length >= 30)
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxNombre, "El nombre no debe exceder los 20 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtBoxNombre, "");
            }
        }

        private void txtBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Convertir a mayúscula la primera letra
            if (txtBoxApellido.Text.Length == 0 && char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            // Permitir solo letras, espacios y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxApellido, "Solo se permiten letras.");
            }
            else if (!char.IsControl(e.KeyChar) && txtBoxApellido.Text.Length >= 30)
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxApellido, "El apellido no debe exceder los 20 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtBoxApellido, "");
            }
        }

        private void txtBoxDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxDni, "Solo se permiten números.");
            }
            // Limitar a 8 caracteres
            else if (!char.IsControl(e.KeyChar) && txtBoxDni.Text.Length >= 8)
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxDni, "Debe ingresar entre 7 y 8 dígitos.");
            }
            else
            {
                errorProvider1.SetError(txtBoxDni, "");
            }
        }

        private void txtBoxCuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxCuil, "Solo se permiten números.");
            }
            // Limitar a 11 caracteres
            else if (!char.IsControl(e.KeyChar) && txtBoxCuil.Text.Length >= 11)
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxCuil, "El CUIL debe tener 11 dígitos.");
            }
            else
            {
                errorProvider1.SetError(txtBoxCuil, "");
            }
        }

        private void txtBoxMovil_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxMovil, "Solo se permiten números.");
            }
            // Limitar a 10 caracteres
            else if (!char.IsControl(e.KeyChar) && txtBoxMovil.Text.Length >= 10)
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxMovil, "El número de móvil debe tener 10 dígitos.");
            }
            else
            {
                errorProvider1.SetError(txtBoxMovil, "");
            }
        }

       

        private void txtBoxCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Convertir a mayúscula la primera letra
            if (txtBoxCalle.Text.Length == 0 && char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            // Permitir solo letras, números, espacios y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxCalle, "Solo se permiten letras y números.");
            }
            else if (!char.IsControl(e.KeyChar) && txtBoxCalle.Text.Length >= 20)
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxCalle, "La calle no debe exceder los 20 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtBoxCalle, "");
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtNumero, "Solo se permiten números.");
            }
            else if (!char.IsControl(e.KeyChar) && txtNumero.Text.Length >= 5)
            {
                e.Handled = true;
                errorProvider1.SetError(txtNumero, "El número no debe exceder los 5 dígitos.");
            }
            else
            {
                errorProvider1.SetError(txtNumero, "");
            }
        }

        private void txtBoxLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Convertir a mayúscula la primera letra
            if (txtBoxLocalidad.Text.Length == 0 && char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            // Permitir solo letras, espacios y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxLocalidad, "Solo se permiten letras.");
            }
            else if (!char.IsControl(e.KeyChar) && txtBoxLocalidad.Text.Length >= 20)
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxLocalidad, "La localidad no debe exceder los 20 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtBoxLocalidad, "");
            }
        }

        private void txtBoxProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Convertir a mayúscula la primera letra
            if (txtBoxProvincia.Text.Length == 0 && char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            // Permitir solo letras, espacios y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxProvincia, "Solo se permiten letras.");
            }
            else if (!char.IsControl(e.KeyChar) && txtBoxProvincia.Text.Length >= 20)
            {
                e.Handled = true;
                errorProvider1.SetError(txtBoxProvincia, "La provincia no debe exceder los 20 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtBoxProvincia, "");
            }
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (como borrar) y no mas de 8 caracteres
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtCodigoPostal, "Solo se permiten números.");
            }
            else if (!char.IsControl(e.KeyChar) && txtCodigoPostal.Text.Length >= 8)
            {
                e.Handled = true;
                errorProvider1.SetError(txtCodigoPostal, "El código postal no debe exceder los 8 dígitos.");
            }
            else
            {
                errorProvider1.SetError(txtCodigoPostal, "");
            }
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Convertir a mayúscula la primera letra
            if (txtRazonSocial.Text.Length == 0 && char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            // Permitir cadena de texto alfanumérica, comas, puntos, espacios y teclas de control (como borrar) menor o igual a 20 caracteres 
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
                errorProvider1.SetError(txtRazonSocial, "Solo se permiten letras, números, comas y puntos.");
            }
            else if (!char.IsControl(e.KeyChar) && txtRazonSocial.Text.Length >= 30)
            {
                e.Handled = true;
                errorProvider1.SetError(txtRazonSocial, "La razón social no debe exceder los 30 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtRazonSocial, "");
            }

        }

        private void txtBoxDni_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtBoxDni.Text) || this.IsDisposed || limpiarPresionado)
            {
                errorProvider1.SetError(txtBoxDni, "");
                return;
            }

            // Validar solo si hay caracteres
            if (txtBoxDni.Text.Length < 7 || txtBoxDni.Text.Length > 8)
            {
                errorProvider1.SetError(txtBoxDni, "El DNI debe tener entre 7 y 8 dígitos.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBoxDni, "");
            }
        }

        private void txtBoxCuil_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtBoxCuil.Text) || this.IsDisposed || limpiarPresionado)
            {
                errorProvider1.SetError(txtBoxCuil, "");
                return;
            }
            // Validar solo si hay caracteres
            if (txtBoxCuil.Text.Length != 11)
            {
                errorProvider1.SetError(txtBoxCuil, "El CUIL debe tener 11 dígitos.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBoxCuil, "");
            }
        }

        private void txtMail_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío o se presiono btnLimpiar o cerrar el formulario
            // 
            if (string.IsNullOrWhiteSpace(txtMail.Text) || this.IsDisposed || limpiarPresionado)
            {
                errorProvider1.SetError(txtMail, "");
                
                return;
            }
            // Validar formato de email básico
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtMail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(txtMail, "Formato de email inválido.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtMail, "");
            }
        }

        private void txtBoxNombre_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtBoxNombre.Text) || this.IsDisposed || limpiarPresionado)
            {
                errorProvider1.SetError(txtBoxNombre, "");
                return;
            }
            //Validar que tenga al menos 2 caracteres
            if (txtBoxNombre.Text.Length < 2)
            {
                errorProvider1.SetError(txtBoxNombre, "El nombre debe tener al menos 2 caracteres.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBoxNombre, "");
            }
        }

        private void txtBoxApellido_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtBoxApellido.Text) || this.IsDisposed || limpiarPresionado)
            {
                errorProvider1.SetError(txtBoxApellido, "");
                return;
            }
            //Validar que tenga al menos 2 caracteres
            if (txtBoxApellido.Text.Length < 2)
            {
                errorProvider1.SetError(txtBoxApellido, "El apellido debe tener al menos 2 caracteres.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBoxApellido, "");
            }
        }

        private void txtBoxCalle_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtBoxCalle.Text) || this.IsDisposed || limpiarPresionado)
            {
                errorProvider1.SetError(txtBoxCalle, "");
                return;
            }
            //Validar que tenga al menos 2 caracteres
            if (txtBoxCalle.Text.Length < 2)
            {
                errorProvider1.SetError(txtBoxCalle, "La calle debe tener al menos 2 caracteres.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBoxCalle, "");
            }
        }

        private void txtBoxLocalidad_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtBoxLocalidad.Text) || this.IsDisposed || limpiarPresionado)
            {
                errorProvider1.SetError(txtBoxLocalidad, "");
                return;
            }
            //Validar que tenga al menos 3 caracteres
            if (txtBoxLocalidad.Text.Length < 3)
            {
                errorProvider1.SetError(txtBoxLocalidad, "La localidad debe tener al menos 3 caracteres.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBoxLocalidad, "");
            }
        }
    }
    }

