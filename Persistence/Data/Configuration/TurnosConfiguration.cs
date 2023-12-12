

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class TurnosConfiguration : IEntityTypeConfiguration<Turno>
{
    public void Configure(EntityTypeBuilder<Turno> builder)
    {
        {
            builder.ToTable("Turno");

            builder.Property(p => p.NombreTurno)
            .HasColumnType("varchar(255)");

            builder.Property(p => p.HoraTurnoInicio)
            .HasColumnType("Time");

            builder.Property(p => p.HoraTurnoFin)
            .HasColumnType("Time");

        }
    }
}