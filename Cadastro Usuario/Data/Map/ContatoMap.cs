using Cadastro_Usuario.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro_Usuario.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder) 
        { 
            builder.HasKey(x => x.Id);
           
            builder.HasOne(x => x.Usuario);
        }

    }
}
