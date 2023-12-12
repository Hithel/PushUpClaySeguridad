

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
{
    public void Configure(EntityTypeBuilder<ContactoPersona> builder)
    {
        {
            builder.ToTable("ContactoPersona");

            builder.Property(p => p.Descripcion)
            .HasColumnType("varchar(255)");

            builder.HasIndex(p => p.Descripcion)
            .IsUnique();

            builder.HasOne(d => d.Persona)
            .WithMany(p => p.ContactoPersonas)
            .HasForeignKey(d => d.IdPersonaFk);

            builder.HasOne(d => d.TipoContacto)
            .WithMany(p => p.ContactoPersonas)
            .HasForeignKey(d => d.IdTipoContactoFk);

        }
    }
}