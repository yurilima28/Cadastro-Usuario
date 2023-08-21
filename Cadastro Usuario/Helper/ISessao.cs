using Cadastro_Usuario.Models;

namespace Cadastro_Usuario.Helper
{
    public interface ISessao 
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
