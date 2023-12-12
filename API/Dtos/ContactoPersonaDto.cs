
using Domain.Entities;

namespace API.Dtos;
    public class ContactoPersonaDto : BaseEntity
    {
    public string Descripcion { get; set; }
    public int IdPersonaFk { get; set; }

    public int IdTipoContactoFk { get; set; }       
    }
