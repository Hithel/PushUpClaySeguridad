namespace Domain.Entities;

public class ContactoPersona : BaseEntity
{
    public string Descripcion { get; set; }
    public int IdPersonaFk { get; set; }
    public Persona Persona { get; set; }
    public int IdTipoContactoFk { get; set; }
    public TipoContacto TipoContacto { get; set; }
}