using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidades;


namespace ArimaERP.Preventista
{
    public partial class FormAltaBajaCliente : Form
    {
        private ClassClienteLogica clienteLogica = new ClassClienteLogica();
        public FormAltaBajaCliente()
        {
            InitializeComponent();
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

        // Validar longitud al perder el foco
        private void txtBoxDni_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtBoxDni.Text))
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
        // Validar longitud al perder el foco
        private void txtBoxCuil_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtBoxCuil.Text))
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

        private void txtMail_Validating(object sender, CancelEventArgs e)
        {
            //Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtMail.Text))
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

        private void txtBoxNombre_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtBoxNombre.Text))
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
            if (string.IsNullOrWhiteSpace(txtBoxApellido.Text))
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
            if (string.IsNullOrWhiteSpace(txtBoxCalle.Text))
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
            if (string.IsNullOrWhiteSpace(txtBoxLocalidad.Text))
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

        private void txtBoxProvincia_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtBoxProvincia.Text))
            {
                errorProvider1.SetError(txtBoxProvincia, "");
                return;
            }
            //Validar que tenga al menos 5 caracteres
            if (txtBoxProvincia.Text.Length < 5)
            {
                errorProvider1.SetError(txtBoxProvincia, "La provincia debe tener al menos 5 caracteres.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBoxProvincia, "");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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
                string.IsNullOrWhiteSpace(comboBoxCondicionFrenteIVA.Text) ||
                string.IsNullOrWhiteSpace(txtCodigoPostal.Text) ||
                comboBoxSeleccionarTamano.SelectedIndex == 0 ||
                comboBoxCondicionFrenteIVA.SelectedIndex == 0 ||
                dateTimePickerFechaAlta.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var idCliente = clienteLogica.AgregarCliente(
               txtBoxNombre.Text, txtBoxApellido.Text, "1", "1", dateTimePickerFechaAlta.Value,
               txtMail.Text, txtBoxMovil.Text, txtBoxDni.Text, txtBoxCuil.Text, txtBoxCalle.Text, txtNumero.Text,
               txtBoxLocalidad.Text, txtBoxProvincia.Text, txtRazonSocial.Text, checkBoxActivo.Checked,
               false, comboBoxCondicionFrenteIVA.Text, txtCodigoPostal.Text
               );

            if (idCliente.HasValue)
            {
                MessageBox.Show("Cliente guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var error in clienteLogica.ErroresValidacion)
                {
                    MessageBox.Show(error, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cerrar el formulario sin guardar cambios
            this.Close();
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

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            // Permitir salir si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                errorProvider1.SetError(txtRazonSocial, "");
                return;
            }
            //Validar que tenga al menos 2 caracteres
            if (txtRazonSocial.Text.Length < 2)
            {
                errorProvider1.SetError(txtRazonSocial, "La razón social debe tener al menos 2 caracteres.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtRazonSocial, "");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar todos los campos del formulario DEJANDO LOS COMBOBOX EN SU ESTADO INICIAL Y DATEPICKER EN LA FECHA ACTUAL
            txtBoxNombre.Clear();
            txtBoxApellido.Clear();
            txtBoxDni.Clear();
            txtBoxCuil.Clear();
            txtBoxMovil.Clear();
            txtMail.Clear();
            txtBoxCalle.Clear();
            txtNumero.Clear();
            txtBoxLocalidad.Clear();
            txtBoxProvincia.Clear();
            txtRazonSocial.Clear();
            comboBoxSeleccionarTamano.SelectedIndex = -1;
            dateTimePickerFechaAlta.Value = DateTime.Now;
            errorProvider1.Clear();
            comboBoxCondicionFrenteIVA.SelectedIndex = 0;
            checkBoxActivo.Checked = false;
            
            txtCodigoPostal.Clear();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            //Cargar combobox desde base de datos
            var tamanos = clienteLogica.ObtenerTamanos();
            comboBoxSeleccionarTamano.Items.Clear();
            comboBoxSeleccionarTamano.Items.Add("Seleccione tamaño");
            foreach (var tamano in tamanos)
            {
                string descripcion = $"{tamano.id_tamano} - {tamano.descripcion}";
                comboBoxSeleccionarTamano.Items.Add(descripcion);
            }
            comboBoxSeleccionarTamano.SelectedIndex = 0;

            var zonas = clienteLogica.ObtenerZonas();
            comboBoxSeleccionarZona.Items.Clear();
            comboBoxSeleccionarZona.Items.Add("Seleccione zona");
            foreach (var zona in zonas)
            {
                string nombre = $"{zona.id_zona} - {zona.nombre}";
                comboBoxSeleccionarZona.Items.Add(nombre);
            }
            comboBoxSeleccionarZona.SelectedIndex = 0;

        }

        private void lblFechaAlta_Click(object sender, EventArgs e)
        {

        }

        private void lblNbre_Click(object sender, EventArgs e)
        {

        }

        private void lblTamano_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void lblApell_Click(object sender, EventArgs e)
        {

        }

        private void lblDni_Click(object sender, EventArgs e)
        {

        }

        private void lblFacturacion_Click(object sender, EventArgs e)
        {

        }

       
    }
}

