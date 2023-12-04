using Microsoft.AspNetCore.Mvc;
using teste.Models;

namespace teste.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!Util.Logado)
                return RedirectToAction("Index", "Login");

            return View();
        }
    }
}
