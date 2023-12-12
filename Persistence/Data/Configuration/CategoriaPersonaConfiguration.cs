

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class CategoriaPersonaConfiguration : IEntityTypeConfiguration<CategoriaPersona>
{
    public void Configure(EntityTypeBuilder<CategoriaPersona> builder)
    {
        {
            builder.ToTable("CategoriaPersona");

            builder.Property(p => p.NombreCategoria)
            .HasColumnType("varchar(255)");

        }
    }
}
