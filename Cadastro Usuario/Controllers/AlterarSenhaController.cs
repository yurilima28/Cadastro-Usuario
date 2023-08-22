using Cadastro_Usuario.Helper;
using Cadastro_Usuario.Models;
using Cadastro_Usuario.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cadastro_Usuario.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio,ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuarioLogado =_sessao.BuscarSessaoDoUsuario();
                alterarSenhaModel.Id= usuarioLogado.Id; 

                if(ModelState.IsValid)
                {

                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada  com sucesso";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao alterar o usuário, detalhe do erro:{erro.Message}";

                return View("Index", alterarSenhaModel);
            }
        }
    }
}
