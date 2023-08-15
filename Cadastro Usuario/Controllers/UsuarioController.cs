using Cadastro_Usuario.Models;
using Cadastro_Usuario.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Cadastro_Usuario.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();    

            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);

                    TempData["MenssagemSucesso"] = "Usuario cadastrado com sucesso!";
                    return RedirectToAction("Index");   
                }

                return View(usuario);

            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Houve um erro ao cadastrar o usuário, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
