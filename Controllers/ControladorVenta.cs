using DesafioMamaniL.Handler;
using DesafioMamaniL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMamaniL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorVenta : ControllerBase
    {
        [HttpPost("{idUsuario}")]
        public string CargarVenta([FromRoute]long idUsuario, [FromBody]Producto[] arrayProductos)
        {
            List<Producto> productos = new List<Producto>();
            productos = arrayProductos.ToList();
            ManejadorVenta.CargarVenta(idUsuario, productos);
            return "Venta cargada";
        }
    }
}
