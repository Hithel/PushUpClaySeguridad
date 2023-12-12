

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        {
            builder.ToTable("Programacion");
            
            builder.HasOne(d => d.Contrato)
            .WithMany(p => p.Programaciones)
            .HasForeignKey(d => d.IdContratoFk);

            builder.HasOne(d => d.Turno)
            .WithMany(p => p.Programaciones)
            .HasForeignKey(d => d.IdTurnoFk);

            builder.HasOne(d => d.Empleado)
            .WithMany(p => p.Programaciones)
            .HasForeignKey(d => d.IdEmpleadoFk);
            
        }
    }
}