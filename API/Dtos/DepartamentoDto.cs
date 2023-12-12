
using Domain.Entities;

namespace API.Dtos;
    public class DepartamentoDto : BaseEntity
    {
    public string NombreDepartamento { get; set; }
    public int IdPaisFk { get; set; }
    }
