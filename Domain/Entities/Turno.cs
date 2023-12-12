namespace Domain.Entities;

public class Turno : BaseEntity
{
    public string NombreTurno { get; set; }
    public TimeOnly HoraTurnoInicio { get; set; }
    public TimeOnly HoraTurnoFin { get; set; }

    public ICollection<Programacion> Programaciones { get; set; }
}