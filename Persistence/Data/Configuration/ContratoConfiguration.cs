

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        {
            builder.ToTable("Contrato");

            builder.HasOne(p => p.Cliente)
            .WithMany(p => p.ContratoCLientes)
            .HasForeignKey(p => p.IdClienteFk);
            
            builder.Property(p => p.FechaContrato)
            .HasColumnType("Date");

            builder.HasOne(p => p.Empleado)
            .WithMany(p => p.ContratoEmpleados)
            .HasForeignKey(p => p.IdEmpleadoFk);

            builder.Property(p => p.FechaFin)
            .HasColumnType("Date");

            builder.HasOne(p => p.Estado)
            .WithMany(p => p.Contratos)
            .HasForeignKey(p => p.IdEmpleadoFk);


        }
    }
}