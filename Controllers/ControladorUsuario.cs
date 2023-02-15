using DesafioMamaniL.Handler;
using DesafioMamaniL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMamaniL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorUsuario : ControllerBase
    {
        [HttpPut]
        public string ModificarUsuario([FromBody]Usuario usuario)
        {
            return (ManejadorUsuario.Modificar(usuario) == 0) ? "Usuario no actualizado" : "Usuario actualizado";
        }
    }
}
