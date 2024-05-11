using API_ProyectoDSWI.Models;
using API_ProyectoDSWI.Repository.DAOFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProyectoDSWI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> findAllProducto()
        {
            var lista = await Task.Run(() => new DAOProducto().findAll());
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> saveProducto(Producto m)
        {
            var mensaje = await Task.Run(() => new DAOProducto().save(m));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<ActionResult> updateProducto(Producto m)
        {
            var mensaje = await Task.Run(() => new DAOProducto().update(m));
            return Ok(mensaje);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> findByIdProducto(int codigo)
        {
            var cliente = await Task.Run(() => new DAOProducto().findById(codigo));
            return Ok(cliente);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> deleteByIdProducto(int codigo)
        {
            var mensaje = await Task.Run(() => new DAOProducto().deleteById(codigo));
            return Ok(mensaje);
        }
    }
}
