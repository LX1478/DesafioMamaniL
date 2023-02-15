using DesafioMamaniL.Models;
using System.Data;
using System.Data.SqlClient;

namespace DesafioMamaniL.Handler
{
    public static class ManejadorUsuario
    {
        private static string connectionString = "Data Source=DESKTOP-K1HOTLS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static int Modificar (Usuario usuario)
        {
            int n = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("UPDATE Usuario SET Nombre = @nombre, " +
                    "Apellido = @apellido, NombreUsuario = @nombreUsuario, Contraseña = @contraseña, " +
                    "Mail = @mail WHERE Id = @idUsuario", conn);

                comando.Parameters.Add(new SqlParameter("nombre", SqlDbType.VarChar) { Value = usuario.Nombre1 });
                comando.Parameters.Add(new SqlParameter("apellido", SqlDbType.VarChar) { Value = usuario.Apellido1 });
                comando.Parameters.Add(new SqlParameter("nombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario1 });
                comando.Parameters.Add(new SqlParameter("contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña1 });
                comando.Parameters.Add(new SqlParameter("mail", SqlDbType.VarChar) { Value = usuario.Mail1 });
                comando.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.BigInt) { Value = usuario.Id1 });
                conn.Open();
                n = comando.ExecuteNonQuery();
            }
            return n;
        }
    }
}
