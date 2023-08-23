using Cadastro_Usuario.Data;
using Cadastro_Usuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro_Usuario.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        public ContatoModel BuscarPorID(int id)
        {
            return _context.Clientes.FirstOrDefault(x => x.Id == id);
        }
        
        public List<ContatoModel> BuscarTodos(int usuarioId)
        {
            return _context.Clientes.Where(x => x.UsuarioId ==  usuarioId).ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Clientes.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoModel Atualziar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorID(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do cliente");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _context.Clientes.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = BuscarPorID(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na deleção do cliente!");

            _context.Clientes.Remove(contatoDB);
            _context.SaveChanges();
            return true;

        }
    }
}