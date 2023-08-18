﻿using Cadastro_Usuario.Models;
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
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(id);
            return View(usuario);
        }


        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);

                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
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
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "usuário apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Houve um erro ao tentar apagar o usuário";

                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao apagar o usuário, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");

            }
        }
        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil,

                    };
                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao alterar o usuário: {erro.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}
