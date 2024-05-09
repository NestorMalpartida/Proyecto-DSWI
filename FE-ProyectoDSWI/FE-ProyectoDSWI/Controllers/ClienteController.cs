using Microsoft.AspNetCore.Mvc;

namespace FE_ProyectoDSWI.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
