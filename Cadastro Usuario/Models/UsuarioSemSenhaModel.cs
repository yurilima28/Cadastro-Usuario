﻿using Cadastro_Usuario.Enums;
using System.ComponentModel.DataAnnotations;
using System;

namespace Cadastro_Usuario.Models
{
    public class UsuarioSemSenhaModel
    {
            public int Id { get; set; }
            [Required(ErrorMessage = "Digite o nome do usuário")]
            public string Nome { get; set; }
            [Required(ErrorMessage = "Digite o login do usuário")]
            public string Login { get; set; }
            [Required(ErrorMessage = "Digite o e-mail do usuário")]
            [EmailAddress(ErrorMessage = " O e-mail informado não é valido")]
            public string Email { get; set; }
            [Required (ErrorMessage ="Digite o perfil do usuário")]
            public PerfilEnum Perfil { get; set; }
            
        

    }
}
