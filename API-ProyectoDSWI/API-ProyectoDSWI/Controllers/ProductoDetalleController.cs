using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoDetalleController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> findAllProductoDetalle()
        {
            var lista = await Task.Run(() => new DAOProducto().findAllProductoDetalle());
            return Ok(lista);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> findByIdProductoDetalle(int codigo)
        {
            var cliente = await Task.Run(() => new DAOProducto().findByIdProductoDetalle(codigo));
            return Ok(cliente);
        }
    }
}
