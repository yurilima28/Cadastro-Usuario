using Cadastro_Usuario.Models;
using System.Collections.Generic;

namespace Cadastro_Usuario.Repositorio
{
    public interface IContatoRepositorio
    {
        // Parametro de entrada int id 
        List<ContatoModel> BuscarTodos(int usuarioId);
        ContatoModel BuscarPorID(int id);
        ContatoModel Adicionar (ContatoModel contato);
        ContatoModel Atualziar(ContatoModel contato);
        bool Apagar(int id);
    }
}
