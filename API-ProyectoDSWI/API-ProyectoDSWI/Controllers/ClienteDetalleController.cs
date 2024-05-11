using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteDetalleController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> findAllClienteDetalle()
        {
            var lista = await Task.Run(() => new DAOCliente().findAllClienteDetalle());
            return Ok(lista);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> findByIdClienteDetalle(int codigo)
        {
            var cliente = await Task.Run(() => new DAOCliente().findByIdClienteDetalle(codigo));
            return Ok(cliente);
        }
    }
}
