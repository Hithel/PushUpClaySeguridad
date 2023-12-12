namespace Domain.Entities;

public class Programacion : BaseEntity
{
    public int IdContratoFk { get; set; }
    public Contrato Contrato { get; set; }
    public int IdTurnoFk { get; set; }
    public Turno Turno { get; set; }
    public int IdEmpleadoFk { get; set; }
    public Persona Empleado { get; set; }    
}