using ArimaERP.EmpleadoClientes;
using Capa_Entidades;
using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArimaERP.Administrador
{
    public partial class FormPanelAdministrador : Form
    {
        
        public FormPanelAdministrador()
        {
            InitializeComponent();
        }

        private void FormPanelAdministrador_Load(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy - hh:mm tt", new System.Globalization.CultureInfo("es-ES"));
            lblFECHA.Text = fecha;
            //Obtener usuario actual
            string usuarioActual = ObtenerUsuarioActual();
            //obtener nombre de empleado de tabla Empleado partir de nombre_usuario que corresponde al usuario actual
            Empleado empleado = new ClassEmpleadoLogica().ObtenerEmpleadoPorNombreUsuario(usuarioActual);
            if (empleado != null)
            {
                label2.Text = $"Bienvenido, Administrador: {empleado.nombre} {empleado.apellido}";
            }
        }
        private string ObtenerUsuarioActual()
        {
            // Aquí debes implementar la lógica para obtener el nombre del usuario actual
            return UsuarioSesion.Nombre; // Ejemplo: retorna el nombre del usuario desde una clase estática de sesión
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //volver al login
            this.Close();
          

        }

        private void gbxAdmin_Enter(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //abrir formulario clientes
            MDIClientes mDIClientes = new MDIClientes();
            mDIClientes.StartPosition = FormStartPosition.CenterScreen;
            FormClosedEventHandler value1 = (s, args) => this.Show();
            FormClosedEventHandler value = value1;
            mDIClientes.FormClosed += value;
            mDIClientes.Show();
            this.Hide();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //abrir formulario productos
            EmpleadoProducto.MDIProductos mDIProductos = new EmpleadoProducto.MDIProductos();
            mDIProductos.StartPosition = FormStartPosition.CenterScreen;
            FormClosedEventHandler value1 = (s, args) => this.Show();
            FormClosedEventHandler value = value1;
            mDIProductos.FormClosed += value;
            mDIProductos.Show();
            this.Hide();
        }

        private void btnPreventista_Click(object sender, EventArgs e)
        {
            //abrir formulario preventista
            Preventista.MDIPreventista mDIPreventista = new Preventista.MDIPreventista();
            mDIPreventista.StartPosition = FormStartPosition.CenterScreen;
            FormClosedEventHandler value1 = (s, args) => this.Show();
            FormClosedEventHandler value = value1;
            mDIPreventista.FormClosed += value;
            mDIPreventista.Show();
            this.Hide();

        }

        private void Accion2_Click(object sender, EventArgs e)
        {
            //abrir formulario agregar rol
            FormAgregarRol formAgregarRol = new FormAgregarRol();
            formAgregarRol.StartPosition = FormStartPosition.CenterScreen;
            FormClosedEventHandler value1 = (s, args) => this.Show();
            FormClosedEventHandler value = value1;
            formAgregarRol.FormClosed += value;
            formAgregarRol.Show();
            this.Hide();
        }

        private void Accion1_Click(object sender, EventArgs e)
        {
            //abrir formulario registrar usuario
            FormRegistrarUsuario formRegistrarUsuario = new FormRegistrarUsuario();
            formRegistrarUsuario.StartPosition = FormStartPosition.CenterScreen;
            FormClosedEventHandler value1 = (s, args) => this.Show();
            FormClosedEventHandler value = value1;
            formRegistrarUsuario.FormClosed += value;
            formRegistrarUsuario.Show();
            this.Hide();

        }

        private void Accion3_Click(object sender, EventArgs e)
        {
            //abrir formulario FormReportes
            FormReportes formReportes = new FormReportes();
            formReportes.StartPosition = FormStartPosition.CenterScreen;
            FormClosedEventHandler value1 = (s, args) => this.Show();
            FormClosedEventHandler value = value1;
            formReportes.FormClosed += value;
            formReportes.Show();
            this.Hide();
        }


        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            //abrir FormAuditoria
            //abrir formulario clientes
            FormAuditoria formAuditoria = new FormAuditoria();
            formAuditoria.StartPosition = FormStartPosition.CenterScreen;
            FormClosedEventHandler value1 = (s, args) => this.Show();
            FormClosedEventHandler value = value1;
            formAuditoria.FormClosed += value;
            formAuditoria.Show();
            this.Hide();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            // Nombre de la base a respaldar
            string nombreBaseDatos = "ArimaERP"; // cámbialo si tu BD tiene otro nombre

            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Seleccioná la carpeta donde querés guardar el backup";

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    // El usuario canceló
                    return;
                }

                string carpeta = dialog.SelectedPath;

                // Nombre del archivo: ArimaERP_2025-11-13_153000.bak
                string nombreArchivo = $"{nombreBaseDatos}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string rutaCompleta = Path.Combine(carpeta, nombreArchivo);

                try
                {
                    string connectionString = ConfigurationManager
                        .ConnectionStrings["ConexionBackup"]
                        .ConnectionString;

                    using (var conexion = new SqlConnection(connectionString))
                    {
                        conexion.Open();

                        string sqlBackup = $@"
BACKUP DATABASE [{nombreBaseDatos}]
TO DISK = @ruta
WITH INIT, STATS = 5";

                        using (var comando = new SqlCommand(sqlBackup, conexion))
                        {
                            comando.Parameters.AddWithValue("@ruta", rutaCompleta);
                            comando.CommandTimeout = 0; // por si tarda
                            comando.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show(
                        $"Backup generado correctamente.\n\nUbicación:\n{rutaCompleta}",
                        "Backup exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Ocurrió un error al generar el backup:\n\n" + ex.Message,
                        "Error al hacer backup",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

    }
}