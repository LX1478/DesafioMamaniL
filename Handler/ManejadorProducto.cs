using DesafioMamaniL.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DesafioMamaniL.Handler
{
    public static class ManejadorProducto
    {
        private static string connectionString = "Data Source=DESKTOP-K1HOTLS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static int Modificar(Producto producto)
        {
            int n = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("UPDATE Producto SET Descripciones = @descripciones," +
                    " Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock, IdUsuario" +
                    " = @idUsuario WHERE Id = @idProducto", conn);
                comando.Parameters.Add(new SqlParameter("descripciones", SqlDbType.VarChar) { Value = producto.Descripciones1 });
                comando.Parameters.Add(new SqlParameter("costo", SqlDbType.Money) { Value = producto.Costo1 });
                comando.Parameters.Add(new SqlParameter("precioVenta", SqlDbType.Money) { Value = producto.PrecioVenta1 });
                comando.Parameters.Add(new SqlParameter("stock", SqlDbType.Int) { Value = producto.Stock1 });
                comando.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario1 });
                comando.Parameters.Add(new SqlParameter("idProducto", SqlDbType.BigInt) { Value = producto.Id1 });

                conn.Open();
                n = comando.ExecuteNonQuery();
            }
            return n;
        }

        public static int Insertar(Producto producto)
        {
            int n = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand comando = new SqlCommand("INSERT INTO Producto(Descripciones, Costo, PrecioVenta, " +
                    "Stock, IdUsuario) VALUES (@descripciones, @costo, @precioVenta, @stock, @idUsuario)", conn);
                comando.Parameters.Add(new SqlParameter("descripciones", SqlDbType.VarChar) { Value = producto.Descripciones1 });
                comando.Parameters.Add(new SqlParameter("costo", SqlDbType.Money) { Value = producto.Costo1 });
                comando.Parameters.Add(new SqlParameter("precioVenta", SqlDbType.Money) { Value = producto.PrecioVenta1 });
                comando.Parameters.Add(new SqlParameter("stock", SqlDbType.Int) { Value = producto.Stock1 });
                comando.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario1 });
                conn.Open();
                n = comando.ExecuteNonQuery();

            }
            return n;
        }

        public static int Eliminar(long id)
        {
            int n = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("DELETE FROM ProductoVendido WHERE IdProducto = @idProducto " +
                    "DELETE FROM Producto WHERE Id = @idProducto", conn);
                comando.Parameters.Add(new SqlParameter("@idProducto", SqlDbType.BigInt) { Value = id });

                conn.Open();
                n = comando.ExecuteNonQuery();
            }
            return n;
        }

        public static void RestarStock(long idProducto, int stock)
        {
            int stockProducto = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT Stock FROM Producto WHERE Id = @IdProducto", conn);
                comando.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = idProducto });

                conn.Open();
                stockProducto = Convert.ToInt32(comando.ExecuteScalar());
                if (stockProducto >= stock)
                {
                    SqlCommand comando2 = new SqlCommand("UPDATE Producto SET Stock -= @Stock " +
                        "WHERE Id = @IdProducto", conn);
                    comando2.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = stock });
                    comando2.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = idProducto });

                    comando2.ExecuteNonQuery();
                }
            }
        }
    }
}
