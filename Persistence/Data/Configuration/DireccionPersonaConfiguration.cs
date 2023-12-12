

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class DireccionPersonaConfiguration : IEntityTypeConfiguration<DireccionPersona>
{
    public void Configure(EntityTypeBuilder<DireccionPersona> builder)
    {
        {
            builder.ToTable("DireccionPersona");

            builder.Property(p => p.Direccion)
            .HasColumnType("varchar(255)");


            builder.HasOne(d => d.Persona)
            .WithMany(p => p.DireccionPersonas)
            .HasForeignKey(d => d.IdPersonaFk);

            builder.HasOne(d => d.TipoDireccion)
            .WithMany(p => p.DireccionPersonas)
            .HasForeignKey(d => d.IdTipoDireccionFk);


        }
    }
}