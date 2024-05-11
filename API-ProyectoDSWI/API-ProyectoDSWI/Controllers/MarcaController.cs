using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> findAllMarca()
        {
            var lista = await Task.Run(() => new DAOMarca().findAll());
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> saveMarca(Marca m)
        {
            var mensaje = await Task.Run(() => new DAOMarca().save(m));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<ActionResult> updateMarca(Marca m)
        {
            var mensaje = await Task.Run(() => new DAOMarca().update(m));
            return Ok(mensaje);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> findByIdMarca(int codigo)
        {
            var cliente = await Task.Run(() => new DAOMarca().findById(codigo));
            return Ok(cliente);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> deleteByIdMarca(int codigo)
        {
            var mensaje = await Task.Run(() => new DAOMarca().deleteById(codigo));
            return Ok(mensaje);
        }
    }
}
