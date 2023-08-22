using Cadastro_Usuario.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_Usuario.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
