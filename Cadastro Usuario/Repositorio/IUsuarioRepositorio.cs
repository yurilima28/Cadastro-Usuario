using Cadastro_Usuario.Models;
using System.Collections.Generic;

namespace Cadastro_Usuario.Repositorio
{
    public interface IUsuarioRepositorio
    {
        
        List<UsuarioModel> BuscarTodos();
        UsuarioModel ListarPorId(int id);
        UsuarioModel Adicionar (UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}

