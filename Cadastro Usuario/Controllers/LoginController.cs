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
        private readonly IEmail _email;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email) 
        { 
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            // Se o usuário estiver logado, redicrecionar para a home
            if(_sessao.BuscarSessaoDoUsuario() !=null) return RedirectToAction("Index", "Home");
            return View();
        }
        public IActionResult RedefinirSenha()
        {
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
        [HttpPost] 
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email , redefinirSenhaModel.Login);
                    if(usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é:{novaSenha}";

                      bool emailEnviado = _email.Enviar(usuario.Email, "Cadastro de usuário - Nova senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu e-mail cadastrado uma nova senha";
                        }else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o e-mail. Por favor, tente novamente.";

                        }
                        
                        return RedirectToAction("Index", "Login");
                    }
                   
                }
                return View("Index");
            }
            catch(Exception erro)
            {
                TempData["MensagemEroo"] = $"Ops, não conseguimos redefinir sua senha, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }  






    }
}
