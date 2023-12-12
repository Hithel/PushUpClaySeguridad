

using Domain.Entities;

namespace API.Dtos;
    public class CiudadDto : BaseEntity
    {
        public string NombreCiudad { get; set; }
        public int IdDepartamentoFk { get; set; }
    }
