using Cadastro_Usuario.Models;
using Cadastro_Usuario.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cadastro_Usuario.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
           List<ContatoModel> contatos =  _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        { 
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
