

using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoriaPersona,CategoriaPersonaDto>().ReverseMap();
        CreateMap<Ciudad,CiudadDto>().ReverseMap();
        CreateMap<ContactoPersona,ContactoPersonaDto>().ReverseMap();
        CreateMap<Contrato,ContratoDto>().ReverseMap();
        CreateMap<Departamento,DepartamentoDto>().ReverseMap();
        CreateMap<DireccionPersona,DireccionPersonaDto>().ReverseMap();
        CreateMap<Estado,EstadoDto>().ReverseMap();
        CreateMap<Pais,PaisDto>().ReverseMap();
        CreateMap<Persona,PersonaDto>().ReverseMap();
        CreateMap<Programacion,ProgramacionDto>().ReverseMap();
        CreateMap<TipoContacto,TipoContactoDto>().ReverseMap();
        CreateMap<TipoDireccion,TipoContactoDto>().ReverseMap();
        CreateMap<TipoPersona,TipoPersonaDto>().ReverseMap();
        CreateMap<Turno,TurnoDto>().ReverseMap();
        CreateMap<User,UserDto>().ReverseMap();
        CreateMap<User, RegisterDto>().ReverseMap();
        CreateMap<Rol,RolDto>().ReverseMap();
        

    }
}