using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaDetalleController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> findAllMarcaDetalle()
        {
            var lista = await Task.Run(() => new DAOMarca().findAllMarcaDetalle());
            return Ok(lista);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> findByIdMarcaDetalle(int codigo)
        {
            var cliente = await Task.Run(() => new DAOMarca().findByIdMarcaDetalle(codigo));
            return Ok(cliente);
        }
    }
}
