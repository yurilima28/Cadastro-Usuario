using Cadastro_Usuario.Data.Map;
using Cadastro_Usuario.Models;
using Microsoft.EntityFrameworkCore;


namespace Cadastro_Usuario.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
       
        public DbSet<ContatoModel> Clientes { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
