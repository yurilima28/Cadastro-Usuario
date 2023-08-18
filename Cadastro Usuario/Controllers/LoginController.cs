using Microsoft.AspNetCore.Mvc;

namespace Cadastro_Usuario.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
