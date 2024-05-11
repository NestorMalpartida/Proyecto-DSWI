using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> findAllCliente()
        {
            var lista = await Task.Run(() => new DAOCliente().findAll());
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> saveCliente(Cliente c)
        {
            var mensaje = await Task.Run(() => new DAOCliente().save(c));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<ActionResult> updateCliente(Cliente c)
        {
            var mensaje = await Task.Run(() => new DAOCliente().update(c));
            return Ok(mensaje);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> findByIdCliente(int codigo)
        {
            var cliente = await Task.Run(() => new DAOCliente().findById(codigo));
            return Ok(cliente);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> deleteByIdCliente(int codigo)
        {
            var mensaje = await Task.Run(() => new DAOCliente().deleteById(codigo));
            return Ok(mensaje);
        }
    }
}
