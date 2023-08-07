using Cadastro_Usuario.Models;
using System.Collections.Generic;

namespace Cadastro_Usuario.Repositorio
{
    public interface IContatoRepositorio
    {
        // Parametro de entrada int id 

        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar (ContatoModel contato);
        ContatoModel Atualziar(ContatoModel contato);
        bool Apagar(int id);
    }
}
