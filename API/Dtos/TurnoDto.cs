

using Domain.Entities;

namespace API.Dtos;
    public class TurnoDto : BaseEntity
    {
            public string NombreTurno { get; set; }
    public TimeOnly HoraTurnoInicio { get; set; }
    public TimeOnly HoraTurnoFin { get; set; }
    }
