namespace Domain.Entities;
public class Persona : BaseEntity
{
    public string IdPersona { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaRegistro { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public int IdCategoriaPersonaFk { get; set; }
    public CategoriaPersona CategoriaPersona { get; set; }
    public int IdCiudadFk { get; set; }
    public Ciudad Ciudad { get; set; }

    public ICollection<ContactoPersona> ContactoPersonas { get; set; }
    public ICollection<Programacion> Programaciones { get; set; }
    public ICollection<Contrato> Contratos { get; set; }
    public ICollection<DireccionPersona> DireccionPersonas { get; set; }
    public ICollection<Contrato> ContratoCLientes { get; set; }
    public ICollection<Contrato> ContratoEmpleados { get; set; }

}