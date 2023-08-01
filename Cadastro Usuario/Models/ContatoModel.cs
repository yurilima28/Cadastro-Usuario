﻿using System.ComponentModel.DataAnnotations;

namespace Cadastro_Usuario.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Digite o nome do cliente")]
        public string Nome { get; set; }
        [Required (ErrorMessage ="Digite o e-mail do cliente")]
        [EmailAddress(ErrorMessage =" Oe-mail informado não é valido")]
        public string Email { get; set;}
        [Required (ErrorMessage ="Digite o numero do cliente")]
        [Phone(ErrorMessage ="O celular informado não é valido")]
        public string Celular { get; set;}
    }
}
