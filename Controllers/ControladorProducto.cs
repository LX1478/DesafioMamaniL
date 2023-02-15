using DesafioMamaniL.Handler;
using DesafioMamaniL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMamaniL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorProducto : ControllerBase
    {
        [HttpPost]
        public string CrearProducto([FromBody] Producto producto)
        {
            return (ManejadorProducto.Insertar(producto) == 0) ? "Producto no insertado" : "Producto insertado";
        }

        [HttpPut]
        public string ModificarProducto([FromBody] Producto producto)
        {
            return (ManejadorProducto.Modificar(producto) == 0) ? "Producto no modificado" : "Producto modificado";
        }

        [HttpDelete("{id}")]
        public string EliminarProducto([FromRoute]long id)
        {
        return (ManejadorProducto.Eliminar(id) == 0) ? "Producto no eliminado" : "Producto eliminado";
        }
    }
}
