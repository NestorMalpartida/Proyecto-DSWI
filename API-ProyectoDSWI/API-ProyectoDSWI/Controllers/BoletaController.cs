using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> findAllBoleta()
        {
            var lista = await Task.Run(() => new DAOBoleta().findAll());
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> saveBoleta(Boleta c)
        {
            var mensaje = await Task.Run(() => new DAOBoleta().save(c));
            return Ok(mensaje);
        }
        [HttpGet("{codigo}")]
        public async Task<ActionResult> findByIdProducto(int codigo)
        {
            var cliente = await Task.Run(() => new DAOBoleta().findById(codigo));
            return Ok(cliente);
        }
    }
}
