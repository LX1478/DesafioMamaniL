using DesafioMamaniL.Models;
using System.Data.SqlClient;
using System.Data;

namespace DesafioMamaniL.Handler
{
    public class ManejadorProductoVenta
    {
        private static string connectionString = "Data Source=DESKTOP-K1HOTLS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void Insertar(ProductoVenta productoVendido)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("INSERT INTO ProductoVendido(Stock, IdProducto, IdVenta)" +
                    " VALUES(@Stock, @IdProducto, @IdVenta)", conn);
                comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = productoVendido.Stock1 });
                comando.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productoVendido.IdProducto1 });
                comando.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt) { Value = productoVendido.IdVenta1 });

                conn.Open();
                comando.ExecuteNonQuery();
            }
        }
    }
}
