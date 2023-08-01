using Cadastro_Usuario.Data;
using Cadastro_Usuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro_Usuario.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
           _bancoContext.Clientes.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

       
    }
}
