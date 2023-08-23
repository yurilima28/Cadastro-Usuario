using Cadastro_Usuario.Filters;
using Cadastro_Usuario.Helper;
using Cadastro_Usuario.Models;
using Cadastro_Usuario.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cadastro_Usuario.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessao _sessao;
        public ContatoController(IContatoRepositorio contatoRepositorio, ISessao sessao)
        {
            _contatoRepositorio = contatoRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
           UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
           List<ContatoModel> contatos =  _contatoRepositorio.BuscarTodos(usuarioLogado.Id);
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
           ContatoModel contato = _contatoRepositorio.BuscarPorID(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarPorID(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
               bool apagado = _contatoRepositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Houve um erro ao tentar apagar o cliente";

                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao apagar o cliente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");

            }
        }


        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contato.UsuarioId = usuarioLogado.Id;

                    contato = _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);

            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Houve um erro ao cadastrar o cliente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Editar (ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   contato = _contatoRepositorio.Atualziar(contato);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao alterar o cadastro: {erro.Message}";
                return RedirectToAction("Index");
               
            }
        }
    }
}
