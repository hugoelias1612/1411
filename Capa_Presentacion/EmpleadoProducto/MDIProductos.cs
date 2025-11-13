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
using ArimaERP;


namespace ArimaERP.EmpleadoProducto
{
    public partial class MDIProductos : Form
    {
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



        private void lblRol_Click(object sender, EventArgs e)
        {

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
            lblNombre.Text = $"Nombre: {UsuarioSesion.Nombre}";
            lblRol.Text = $"Rol: {UsuarioSesion.RolDescripcion}";
            lblFecha.Text = $"Fecha: {DateTime.Now:dd/MM/yyyy}";
        }
    }
}
