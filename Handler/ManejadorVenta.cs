using DesafioMamaniL.Models;
using System.Data.SqlClient;
using System.Data;

namespace DesafioMamaniL.Handler
{
    public class ManejadorVenta
    {
        private static string connectionString = "Data Source=DESKTOP-K1HOTLS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static long Insertar(Venta venta)
        {
            long n = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("INSERT INTO Venta(Comentarios, IdUsuario)" +
                    "VALUES (@Comentario, @IdUsuario) SELECT @@IDENTITY", conn);

                comando.Parameters.Add(new SqlParameter("Comentario", SqlDbType.VarChar) { Value = venta.Comentarios1 });
                comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = venta.IdUsuario1 });

                conn.Open();
                n = Convert.ToInt64(comando.ExecuteScalar());
            }
            return n;
        }

        public static void CargarVenta(long idUsuario, List<Producto> productos)
        {
            Venta venta = new Venta();
            venta.IdUsuario1 = idUsuario;
            venta.Comentarios1 = "Venta exitosa3";

            long idVenta = Insertar(venta);

            foreach (Producto producto in productos)
            {
                ProductoVenta productoVenta = new ProductoVenta();
                productoVenta.Stock1 = producto.Stock1;
                productoVenta.IdProducto1 = producto.Id1;
                productoVenta.IdVenta1 = idVenta;

                ManejadorProductoVenta.Insertar(productoVenta);
                ManejadorProducto.RestarStock(producto.Id1, producto.Stock1);
            }
        }
    }
}
