

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        {
            builder.ToTable("Persona");

            builder.Property(p => p.IdPersona)
            .HasColumnType("varchar(255)");

            builder.HasIndex(p => p.IdPersona)
            .IsUnique();

            builder.Property(p => p.Nombre)
            .HasColumnType("varchar(255)");

            builder.Property(p => p.FechaRegistro)
            .HasColumnType("Date");

            builder.HasOne(d => d.TipoPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdTipoPersonaFk);

            builder.HasOne(d => d.CategoriaPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdCategoriaPersonaFk);

            builder.HasOne(d => d.Ciudad)
            .WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdCiudadFk);

        }
    }
}