using Cadastro_Usuario.Helper;
using Cadastro_Usuario.Models;
using Cadastro_Usuario.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cadastro_Usuario.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao) 
        { 
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // Se o usuário estiver logado, redicrecionar para a home
            if(_sessao.BuscarSessaoDoUsuario() !=null) return RedirectToAction("Index", "Home");
            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);
                    if(usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha)) 
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);  
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida";

                    }

                     TempData["MensagemErro"] = $"Login ou senha inválidos";

                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $" Não conseguimos realizer seu login: {erro.Message}";

                return RedirectToAction("Index");
            }
        }
    }
}
