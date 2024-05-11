using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioDetalleController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> findAllUsuarioDetalle()
        {
            var lista = await Task.Run(() => new DAOUsuario().findAllUsuarioDetalle());
            return Ok(lista);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> findByIdClienteDetalle(int codigo)
        {
            var cliente = await Task.Run(() => new DAOUsuario().findByIdUsuarioDetalle(codigo));
            return Ok(cliente);
        }
    }
}
