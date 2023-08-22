using System.ComponentModel.DataAnnotations;

namespace Cadastro_Usuario.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail")]
        public string Email { get; set; }
    }
}
