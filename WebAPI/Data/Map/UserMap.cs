﻿﻿﻿﻿﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Models;

namespace WebAPI.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Role).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserKey).IsRequired().HasMaxLength(32);
            
            // Relationships
            builder.HasMany(u => u.Clientes)
                .WithOne()
                .HasForeignKey(c => c.UsuarioId);

            builder.HasMany(u => u.Tarefas)
                .WithOne()
                .HasForeignKey(t => t.UsuarioId);
        }
    }
}
