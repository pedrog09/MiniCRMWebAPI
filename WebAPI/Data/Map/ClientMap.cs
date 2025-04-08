using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Models;

namespace WebAPI.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClientModel>
    {
        public void Configure(EntityTypeBuilder<ClientModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).HasMaxLength(150);
            builder.Property(x => x.Tipo).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CNPJ).HasMaxLength(18); // Formato: 00.000.000/0000-00
            builder.Property(x => x.CPF).HasMaxLength(14); // Formato: 000.000.000-00

            // Configuração da relação com UsuarioModel
            builder.HasOne<UserModel>()
                   .WithMany(u => u.Clientes)
                   .HasForeignKey(c => c.UsuarioId);
        }
    }
}
