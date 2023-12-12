

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class TipoDireccionConfiguration : IEntityTypeConfiguration<TipoDireccion>
{
    public void Configure(EntityTypeBuilder<TipoDireccion> builder)
    {
        {
            builder.ToTable("TipoDireccion");

            builder.Property(p => p.Descripcion)
            .HasColumnType("varchar(255)");

        }
    }
}
