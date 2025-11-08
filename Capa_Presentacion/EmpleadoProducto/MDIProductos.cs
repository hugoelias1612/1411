using Capa_Entidades;
using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArimaERP.EmpleadoProducto
{
    public partial class MDIProductos : Form
    {
        ClassUsuarioLogica usuarioLogica = new ClassUsuarioLogica();
        public MDIProductos()
        {
            InitializeComponent();
        }     

        private void AbrirFormEnPanel(Form formHijo)
        {
            // Si ya hay controles dentro del panel, los limpio
            pnlContent.Controls.Clear();

            // Configuro el form hijo
            formHijo.TopLevel = false;            // No será ventana independiente
            formHijo.FormBorderStyle = FormBorderStyle.None; // Sin bordes
            formHijo.Dock = DockStyle.Fill;       // Que ocupe todo el panel

            // Lo agrego al panel
            pnlContent.Controls.Add(formHijo);
            pnlContent.Tag = formHijo;

            // Muestro el formulario
            formHijo.Show();
        }        

        private void btnAlerta_Click(object sender, EventArgs e)
        {
           AbrirFormEnPanel(new FormAlerta());
        }

        private void btnABM_Click(object sender, EventArgs e)
        {
       
            AbrirFormEnPanel(new FormABM());
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {

            AbrirFormEnPanel(new FormComprar());
        }

        private void btnFMP_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormFMP());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormStock());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // cerrar formulario MDIProductos
            this.Close();
        }

        private void MDIProductos_Load(object sender, EventArgs e)
        {
            lblFecha.Text = lblFecha.Text + DateTime.Now.ToString("dd/MM/yyyy");
            lblHora.Text = lblHora.Text + DateTime.Now.ToString("HH:mm:ss");
            //Obtener usuario actual
            string usuarioActual = ObtenerUsuarioActual();
            //Obtener usuario por nombre
            var usuario = usuarioLogica.ObtenerUsuarioPorNombre(usuarioActual);
            //obtener nombre de empleado de tabla Empleado partir de nombre_usuario que corresponde al usuario actual
            Empleado empleado = new ClassEmpleadoLogica().ObtenerEmpleadoPorNombreUsuario(usuarioActual);
            if (empleado != null)
            {
                if (usuario.id_rol == 6)
                {
                    lblNombre.Text = $"Vendedor: {empleado.nombre} {empleado.apellido}";
                }
                else if (usuario.id_rol == 8)
                {
                    lblNombre.Text = $"Administrador: {empleado.nombre} {empleado.apellido}";
                }
                else if (usuario.id_rol == 7)
                {
                    lblNombre.Text = $"Empleado Sector Productos:{empleado.nombre} {empleado.apellido}";
                }

            }
        }
        private string ObtenerUsuarioActual()
        {
            return UsuarioSesion.Nombre; // Ejemplo: retorna el nombre del usuario desde una clase estática de sesión
        }
    }
}
