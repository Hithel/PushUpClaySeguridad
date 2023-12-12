

using Domain.Entities;

namespace API.Dtos;
    public class ContratoDto : BaseEntity
    {
    public DateOnly FechaContrato { get; set; }
    public DateOnly FechaFin { get; set; }
    public int IdClienteFk { get; set; }

    public int IdEmpleadoFk { get; set; }

    public int IdEstadoFk { get; set; }

    }
