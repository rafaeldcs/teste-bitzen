using Microsoft.AspNetCore.Mvc;
using teste.Entidade;
using teste.Models;
using teste.Services.Interface;

namespace teste.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LogarSistema(string usuario, string senha)
        {
            try
            {
                var loginEntidade = new Login() { Senha = senha, Usuario = usuario };

                var logou = await _service.LogarSistema(loginEntidade);

                if (logou)
                {
                    Util.Logado = true;
                    return RedirectToAction("Index", "Home");
                }

                Util.Logado = false;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> CriarUsuario(string usuario, string senha)
        {
            try
            {
                var loginEntidade = new Login() { Senha = senha, Usuario = usuario };

                return Json(await _service.CriarUsuario(loginEntidade));
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}
