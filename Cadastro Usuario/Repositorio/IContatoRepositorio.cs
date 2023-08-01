using Cadastro_Usuario.Models;
using System.Collections.Generic;

namespace Cadastro_Usuario.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar (ContatoModel contato);

    }
}
