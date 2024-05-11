using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> findAllPais()
        {
            var lista = await Task.Run(() => new DAORol().findAll());
            return Ok(lista);
        }
    }
}
