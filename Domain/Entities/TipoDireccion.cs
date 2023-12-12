namespace Domain.Entities;

public class TipoDireccion : BaseEntity
{
    public string Descripcion { get; set; }

    public ICollection<DireccionPersona> DireccionPersonas { get; set;}
}