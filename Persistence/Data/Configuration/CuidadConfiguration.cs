
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class CuidadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        {
            builder.ToTable("Cuidad");

            builder.Property(p => p.NombreCiudad)
            .HasColumnType("varchar(255)");

             builder.HasOne(p => p.Departamento)
                .WithMany(p => p.Ciudades)
                .HasForeignKey(p => p.IdDepartamentoFk);


        }
    }
}