using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> findAllPais()
        {
            var lista = await Task.Run(() => new DAODistrito().findAll());
            return Ok(lista);
        }
    }
}
