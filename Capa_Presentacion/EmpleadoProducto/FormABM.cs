using System;
using System.ComponentModel;
using System.Windows.Forms;
using Capa_Logica;
using Capa_Entidades;

namespace ArimaERP.EmpleadoProducto
{
    public partial class FormABM : Form
    {
        private ErrorProvider errorProvider;
        ClassMarcaLogica marcaLogica = new ClassMarcaLogica();
        ClassFamiliaLogica familiaLogica = new ClassFamiliaLogica();
        ClassProveedorLogica proveedorLogica = new ClassProveedorLogica();
        ClassProductoLogica productoLogica = new ClassProductoLogica();
        public FormABM()
        {
            InitializeComponent();            
        }

        private void FormABM_Load(object sender, EventArgs e)
        {
            //cargar comboBoxMarca de base de datos
            var marcas = marcaLogica.ObtenerTodasLasMarcas();
            cbxMarca.DataSource = marcas;
            //cargar comboBoxFamilia de base de datos
            var familias = familiaLogica.ObtenerTodasLasFamilias();
            cbxFamilia.DataSource = familias;
            cbxFamilia.DisplayMember = "descripcion";
            cbxFamilia.ValueMember = "id_familia";
            cbxFamilia.SelectedIndex = -1; // No seleccionar nada al inicio
            cbxMarca.DisplayMember = "nombre";
            cbxMarca.ValueMember = "id_marca";
            cbxMarca.SelectedIndex = -1; // No seleccionar nada al inicio

            var familiasBaja = familiaLogica.ObtenerTodasLasFamilias();
            cbxFamiliaBaja.DataSource = familiasBaja;
            cbxFamiliaBaja.DisplayMember = "descripcion";
            cbxFamiliaBaja.ValueMember = "id_familia";
            cbxFamiliaBaja.SelectedIndex = -1; // No seleccionar nada al inicio

            var marcasBaja = marcaLogica.ObtenerTodasLasMarcas();
            cbxMarcaBaja.DataSource = marcasBaja;
            cbxMarcaBaja.DisplayMember = "nombre";
            cbxMarcaBaja.ValueMember = "id_marca";
            cbxMarcaBaja.SelectedIndex = -1; // No seleccionar nada al inicio

            //Cargar todos los proveedores
            var presentaciones = productoLogica.ObtenerListaPresentaciones();
            cbxPresentacion.DataSource = presentaciones;
            cbxPresentacion.DisplayMember = "descripcion";
            cbxPresentacion.ValueMember = "ID_presentacion";
            cbxPresentacion.SelectedIndex = -1; // No seleccionar nada al inicio
            // Inicializar NumericUpDown
            nudUPB.Value = 0;
            nudBultosIniciales.Value = 0;
            nudUnidadesIniciales.Value = 0;

            // Mostrar panel Alta por defecto
            PAlta.Visible = true;
            PBaja.Visible = false;
            PModificacion.Visible = false;
        }

        // Validar que Nombre solo contenga letras y espacios
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNombre.Text.Length == 0 && char.IsLower(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtNombre, "Solo se permiten letras y espacios.");
            }
            else if (!char.IsControl(e.KeyChar) && txtNombre.Text.Length >= 30)
            {
                e.Handled = true;
                errorProvider1.SetError(txtNombre, "El nombre no debe exceder 30 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtNombre, "");
            }
        }

       
        private void txtPrecioUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                errorProvider1.SetError(txtPrecioUnit, "Solo se permiten números y coma decimal.");
            }
            else if (txtPrecioUnit.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtPrecioUnit, "Máximo 10 caracteres.");
            }
            else
            {
                errorProvider1.SetError(txtPrecioUnit, "");
            }
        }       

        private void numericUpDownUnidadesPorBulto_Validating(object sender, CancelEventArgs e)
        {
            if (nudUPB.Value <= 0)
            {
                errorProvider1.SetError(nudUPB, "Las unidades por bulto son obligatorias.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(nudUPB, "");
            }
        }

        private void btnCrearProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioUnit.Text) ||
                cbxFamilia.SelectedIndex == -1 ||
                cbxPresentacion.SelectedIndex == -1 ||
                cbxMarca.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtPrecioUnit.Text) ||
                nudUPB.Value <= 0 ||
                nudBultosIniciales.Value < 0 ||
                nudUnidadesIniciales.Value < 0)
            {
                MessageBox.Show("Por favor, complete todos los campos y/o verifique cantidades iniciales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Pedir confirmación para crear el producto
            var resultado = MessageBox.Show(
                "¿Está seguro que desea crear el producto con los datos ingresados?",
                "Confirmar alta de producto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Reemplaza el bloque dentro de btnCrearProducto_Click
            if (resultado == DialogResult.Yes)
            {
                int cod_producto = Convert.ToInt32(textBoxCodigo.Text);
                //Verificar si ya existe el producto
                var productoExistente = productoLogica.ObtenerProductoPresentacionPorCodigo(cod_producto);
                if(productoExistente!= null)
                {
                    MessageBox.Show("Ya existe un producto con ese código y presentación.", "Producto existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string nombre = txtNombre.Text.Trim();
                int id_familia = Convert.ToInt32(cbxFamilia.SelectedValue);
                int id_marca = Convert.ToInt32(cbxMarca.SelectedValue);
                int idProducto = productoLogica.CrearProducto(nombre, id_familia, id_marca);


                
                decimal precioLista = Convert.ToDecimal(txtPrecioUnit.Text);
                int unidades_bulto = Convert.ToInt32(nudUPB.Value);
                int bultosIniciales = Convert.ToInt32(nudBultosIniciales.Value);
                int unidadesIniciales = Convert.ToInt32(nudUnidadesIniciales.Value);
                int ID_presentacion = Convert.ToInt32(cbxPresentacion.SelectedValue);
                bool activo = true;
                 if (idProducto == -1)
                {
                    MessageBox.Show("Error al crear el producto:\n" + string.Join("\n", productoLogica.ErroresValidacion), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
               
                var producto_presentacion = productoLogica.CrearProductoPresentacion(idProducto, ID_presentacion, cod_producto, precioLista, unidades_bulto, activo);
                                                 

                if (producto_presentacion == null)
                {
                    MessageBox.Show("Error al crear el producto con presentacion:\n" + string.Join("\n", productoLogica.ErroresValidacion), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Producto creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLimpiarCampos_Click(sender, e);
                }
                //Crear stock si todavia no existe para este producto_presentacion
                var stockConsulta = productoLogica.ObtenerStockPorProductoYPresentacion(producto_presentacion.id_producto, producto_presentacion.ID_presentacion);
                if(stockConsulta == null)
                {
                    int stock_actual = unidadesIniciales + bultosIniciales * producto_presentacion.unidades_bulto;
                    var stockCreado = productoLogica.CrearStock(stock_actual, 20, producto_presentacion.id_producto, producto_presentacion.ID_presentacion);
                }
            }          

                
            
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtPrecioUnit.Clear();
            textBoxCodigo.Clear();

            cbxFamilia.SelectedIndex = -1;
            cbxPresentacion.SelectedIndex = -1;
            cbxMarca.SelectedIndex = -1;

            nudUPB.Value = 0;
            nudBultosIniciales.Value = 0;
            nudUnidadesIniciales.Value = 0;

            errorProvider1.Clear();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            PAlta.Visible = true;
            PBaja.Visible = false;
            PModificacion.Visible = false;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            PAlta.Visible = false;
            PBaja.Visible = true;
            PModificacion.Visible = false;
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            PAlta.Visible = false;
            PBaja.Visible = false;
            PModificacion.Visible = true;
        }
        private void textBoxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {            
            //permitir solo numeros y no mas de 10 caracteres
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBoxCodigo, "Solo se permiten números.");
            }
            else if(textBoxCodigo.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBoxCodigo, "No se permiten más de 10 caracteres.");
            }
            else
            {
                errorProvider1.SetError(textBoxCodigo, "");
            }
        }

      
    }
}
