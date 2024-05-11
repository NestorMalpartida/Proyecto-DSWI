using FE_ProyectoDSWI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace FE_ProyectoDSWI.Controllers
{
    public class ProductoController : Controller
    {
        public async Task<IActionResult> findAll()
        {
            List<ProductoDetalle> lista;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/ProductoDetalle");
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<ProductoDetalle>>(apiResponse);
                }
                else
                {
                    lista = new List<ProductoDetalle>();
                }

            }

            return View(await Task.Run(() => lista));
        }

        public async Task<List<Marca>> findAllMarca()
        {
            List<Marca> lista;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Marca");
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Marca>>(apiResponse);
                }
                else
                {
                    lista = new List<Marca>();
                }

            }
            return lista;

        }

        public async Task<IActionResult> save()
        {
            ViewBag.listaMarca = new SelectList(await findAllMarca(), "codigo", "descripcion");
            return View(await Task.Run(() => new Producto()));
        }

        [HttpPost]
        public async Task<IActionResult> save(Producto reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Producto");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("", content);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    mensaje = apiResponse;

                }
                ViewBag.mensaje = mensaje;
                return RedirectToAction("findAll");

            }

        }
        public async Task<IActionResult> update(int codigo)
        {
            Producto reg = new Producto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Producto/");
                HttpResponseMessage response = await client.GetAsync(codigo.ToString());

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<Producto>(apiResponse);

                }

                ViewBag.listaRol = new SelectList(await findAllMarca(), "codigo", "descripcion", reg.codigoMarca);
                return View(await Task.Run(() => reg));

            }

        }
        [HttpPost]
        public async Task<IActionResult> update(Producto reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:7083/api/Producto/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("codigo", content);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    mensaje = apiResponse;

                }

                ViewBag.mensaje = mensaje;
                return RedirectToAction("findAll");

            }
        }

        public async Task<IActionResult> details(int codigo)
        {
            ProductoDetalle reg = new ProductoDetalle();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/ProductoDetalle/");
                HttpResponseMessage response = await client.GetAsync(codigo.ToString());
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reg = JsonConvert.DeserializeObject<ProductoDetalle>(apiResponse);
                }
            }

            return View(reg);
        }
        public async Task<IActionResult> delete(int codigo)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7083/api/Producto/");
                HttpResponseMessage response = await client.DeleteAsync(codigo.ToString());

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    mensaje = apiResponse;
                }
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("findAll");
        }
    }
}
