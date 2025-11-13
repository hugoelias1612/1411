using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Capa_Utilidades;


namespace Capa_Datos
{
    public class UsuarioDatos
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ArimaERP;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";

        public USUARIO ObtenerUsuarioPorNombre(string nombre)
        {
            USUARIO usuario = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT u.nombre, u.contraseña, u.estado, u.id_rol, r.descripcion 
                                 FROM USUARIOS u 
                                 JOIN ROL r ON u.id_rol = r.id_rol 
                                 WHERE u.nombre = @nombre AND u.estado = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new USUARIO
                    {
                        nombre = reader["nombre"].ToString(),
                        contraseña = reader["contraseña"].ToString(),
                        estado = Convert.ToBoolean(reader["estado"]),
                        id_rol = Convert.ToInt32(reader["id_rol"]),
                        rol_descripcion = reader["descripcion"].ToString()
                    };
                }
            }

            return usuario;
        }

        public USUARIO AutenticarUsuario(string nombre, string contraseñaPlano)
        {
            USUARIO usuario = ObtenerUsuarioPorNombre(nombre);

            if (usuario != null && PasswordHasher.VerifyPassword(contraseñaPlano, usuario.contraseña))
            {
                return usuario;
            }

            return null;
        }
    }
}

