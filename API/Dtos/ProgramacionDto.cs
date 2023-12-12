

using Domain.Entities;

namespace API.Dtos;
    public class ProgramacionDto : BaseEntity
    {
        public int IdContratoFk { get; set; }

    public int IdTurnoFk { get; set; }

    public int IdEmpleadoFk { get; set; }

    }