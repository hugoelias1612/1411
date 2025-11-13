using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using Capa_Entidades;
using Capa_Logica;

namespace ArimaERP.EmpleadoProducto
{
    public partial class FormFMP : Form
    {
        private bool limpiarPresionado = false;
        private readonly ClassProveedorLogica _proveedorLogica = new ClassProveedorLogica();
        private readonly ClassMarcaLogica _marcaLogica = new ClassMarcaLogica();
        private PROVEEDOR _proveedorEnEdicion;

        public FormFMP()
        {
            InitializeComponent();
            btnCrear.Click += btnCrear_Click;
            btnCrearMarca.Click += btnCrearMarca_Click;
            btnEditarProveedor.Click += btnEditarProveedor_Click;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir solo letras, espacios y teclas de control (como retroceso)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras y espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtNombre.Text.Length >= 20 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtNombre, "Máximo 20 caracteres.");


            }
        }

        private void txtProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir solo letras, espacios y teclas de control (como retroceso)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras y espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtProvincia.Text.Length >= 30 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtProvincia, "Máximo 30 caracteres.");
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir solo numeros y teclas de control (como retroceso)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBoxNroCalle.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBoxNroCalle, "Máximo 10 caracteres.");
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permitir solo numeros y teclas de control (como retroceso)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtTelefono.Text.Length >= 15 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtTelefono, "Máximo 15 caracteres.");
            }
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir solo letras, espacios y teclas de control (como retroceso)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras y espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtCiudad.Text.Length >= 30 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtCiudad, "Máximo 30 caracteres.");
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Limitar la longitud del correo electrónico a 50 caracteres
            if (txtEmail.Text.Length >= 50 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtEmail, "Máximo 50 caracteres.");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            // Validar el formato del correo electrónico
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                try
                {
                    var addr = new MailAddress(txtEmail.Text);
                    if (!string.Equals(addr.Address, txtEmail.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtEmail, "Formato de correo electrónico inválido.");
                    }
                    else
                    {
                        errorProvider1.SetError(txtEmail, string.Empty);
                    }
                }
                catch
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail, "Formato de correo electrónico inválido.");
                }
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty);
            }
            if (limpiarPresionado)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, string.Empty);
            }
            //si this.Is Disposed no hacer nada
            if (this.IsDisposed)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, string.Empty);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ResetFormulario();
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir solo letras, espacios y teclas de control (como retroceso) y máximo 25 caracteres
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras y espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtCalle.Text.Length >= 25 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtCalle, "Máximo 25 caracteres.");
            }
        }

        private void txtNombreMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir solo letras, espacios y teclas de control (como retroceso) y máximo 30 caracteres
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras y espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtNombreMarca.Text.Length >= 30 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtNombreMarca, "Máximo 30 caracteres.");
            }
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (txtCodigoPostal.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtCodigoPostal, "Máximo 10 caracteres.");
            }
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (txtCuit.Text.Length >= 11 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtCuit, "El CUIT debe tener 11 dígitos.");
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!ValidarProveedor())
            {
                return;
            }

            if (_proveedorEnEdicion == null)
            {
                var nuevoProveedor = new PROVEEDOR();
                AplicarDatosProveedor(nuevoProveedor);

                var creado = _proveedorLogica.CrearProveedor(nuevoProveedor);
                if (creado != null)
                {
                    MessageBox.Show("Proveedor creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFormulario();
                }
                else
                {
                    MostrarErrores(_proveedorLogica.ErroresValidacion);
                }
            }
            else
            {
                AplicarDatosProveedor(_proveedorEnEdicion);
                var actualizado = _proveedorLogica.ActualizarProveedor(_proveedorEnEdicion);
                if (actualizado)
                {
                    MessageBox.Show("Proveedor editado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFormulario();
                }
                else
                {
                    MostrarErrores(_proveedorLogica.ErroresValidacion);
                }
            }
        }

        private void btnCrearMarca_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNombreMarca, string.Empty);

            string nombreMarca = txtNombreMarca.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombreMarca))
            {
                errorProvider1.SetError(txtNombreMarca, "Ingrese el nombre de la marca.");
                return;
            }

            var nuevaMarca = new MARCA { nombre = nombreMarca };
            var marcaCreada = _marcaLogica.CrearMarca(nuevaMarca);

            if (marcaCreada != null)
            {
                MessageBox.Show("Marca creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreMarca.Clear();
            }
            else
            {
                MostrarErrores(_marcaLogica.ErroresValidacion);
            }
        }

        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            using (var formEdit = new FormEditProveedor())
            {
                if (formEdit.ShowDialog(this) == DialogResult.OK && formEdit.ProveedorSeleccionado != null)
                {
                    _proveedorEnEdicion = formEdit.ProveedorSeleccionado;
                    CargarProveedorEnFormulario(_proveedorEnEdicion);
                }
            }
        }

        private bool ValidarProveedor()
        {
            bool esValido = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre del proveedor.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtProvincia.Text))
            {
                errorProvider1.SetError(txtProvincia, "Ingrese la provincia.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                errorProvider1.SetError(txtCiudad, "Ingrese la ciudad.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                errorProvider1.SetError(txtCalle, "Ingrese la calle.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxNroCalle.Text) || !int.TryParse(textBoxNroCalle.Text, out _))
            {
                errorProvider1.SetError(textBoxNroCalle, "Ingrese un número de calle válido.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtCodigoPostal.Text) || !int.TryParse(txtCodigoPostal.Text, out _))
            {
                errorProvider1.SetError(txtCodigoPostal, "Ingrese un código postal válido.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(lblRazonSocial.Text))
            {
                errorProvider1.SetError(lblRazonSocial, "Ingrese la razón social.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtCuit.Text) || !long.TryParse(txtCuit.Text, out _) || txtCuit.Text.Length != 11)
            {
                errorProvider1.SetError(txtCuit, "El CUIT debe contener 11 dígitos numéricos.");
                esValido = false;
            }

            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && !long.TryParse(txtTelefono.Text, out _))
            {
                errorProvider1.SetError(txtTelefono, "Ingrese un teléfono válido.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Ingrese el correo electrónico.");
                esValido = false;
            }
            else
            {
                try
                {
                    var addr = new MailAddress(txtEmail.Text);
                    if (!string.Equals(addr.Address, txtEmail.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        errorProvider1.SetError(txtEmail, "Formato de correo electrónico inválido.");
                        esValido = false;
                    }
                }
                catch
                {
                    errorProvider1.SetError(txtEmail, "Formato de correo electrónico inválido.");
                    esValido = false;
                }
            }

            return esValido;
        }

        private void AplicarDatosProveedor(PROVEEDOR proveedor)
        {
            proveedor.nombre = txtNombre.Text.Trim();
            proveedor.provincia = txtProvincia.Text.Trim();
            proveedor.ciudad = txtCiudad.Text.Trim();
            proveedor.calle = txtCalle.Text.Trim();
            proveedor.numero = int.Parse(textBoxNroCalle.Text.Trim());
            proveedor.cod_postal = int.Parse(txtCodigoPostal.Text.Trim());
            proveedor.razon_social = txtRazonSocial.Text.Trim();
            proveedor.cuit = long.Parse(txtCuit.Text.Trim());
            proveedor.telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? 0 : long.Parse(txtTelefono.Text.Trim());
            proveedor.email = txtEmail.Text.Trim();
        }

        private void CargarProveedorEnFormulario(PROVEEDOR proveedor)
        {
            if (proveedor == null)
            {
                return;
            }

            limpiarPresionado = true;
            txtNombre.Text = proveedor.nombre;
            txtProvincia.Text = proveedor.provincia;
            txtCiudad.Text = proveedor.ciudad;
            txtCalle.Text = proveedor.calle;
            textBoxNroCalle.Text = proveedor.numero.ToString();
            txtCodigoPostal.Text = proveedor.cod_postal.ToString();
            txtRazonSocial.Text = proveedor.razon_social;
            txtCuit.Text = proveedor.cuit.ToString();
            txtTelefono.Text = proveedor.telefono == 0 ? string.Empty : proveedor.telefono.ToString();
            txtEmail.Text = proveedor.email;
            btnCrear.Text = "Guardar cambios";
            gbxProveedor.Text = "Editar proveedor";
            limpiarPresionado = false;
        }

        private void ResetFormulario()
        {
            limpiarPresionado = true;
            txtNombre.Clear();
            txtProvincia.Clear();
            txtCiudad.Clear();
            txtCalle.Clear();
            textBoxNroCalle.Clear();
            txtCodigoPostal.Clear();
            txtRazonSocial.Clear();
            txtCuit.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtNombreMarca.Clear();
            errorProvider1.Clear();
            _proveedorEnEdicion = null;
            btnCrear.Text = "Crear nuevo Proveedor";
            gbxProveedor.Text = "Datos del nuevo proveedor";
            limpiarPresionado = false;
        }

        private void MostrarErrores(IEnumerable<string> errores)
        {
            if (errores == null)
            {
                return;
            }

            var listaErrores = errores.Where(error => !string.IsNullOrWhiteSpace(error)).ToList();
            if (listaErrores.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, listaErrores), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}