using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> findAllUsuario()
        {
            var lista = await Task.Run(() => new DAOUsuario().findAll());
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> saveUsuario(Usuario u)
        {
            var mensaje = await Task.Run(() => new DAOUsuario().save(u));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<ActionResult> updateUsuario(Usuario u)
        {
            var mensaje = await Task.Run(() => new DAOUsuario().update(u));
            return Ok(mensaje);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> findByIdUsuario(int codigo)
        {
            var cliente = await Task.Run(() => new DAOUsuario().findById(codigo));
            return Ok(cliente);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> deleteByIdUsuario(int codigo)
        {
            var mensaje = await Task.Run(() => new DAOUsuario().deleteById(codigo));
            return Ok(mensaje);
        }
    }
}
