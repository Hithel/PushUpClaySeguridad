

namespace Domain.Interfaces;
    public interface  IUnitOfWork
    {
        ICategoriaPersona CategoriaPersonas { get;  }
        IContactoPersona ContactoPersonas { get;  }
        IContrato Contratos { get; }
        ICiudad Ciudades { get; }
        IDepartamento Departamentos { get; }
        IDireccionPersona DireccionPersonas { get; }
        IEstado Estados { get; }
        IPais Paises { get; }
        IPersona Personas { get; }
        IProgramacion Programaciones { get; }
        ITipoContacto TipoContactos { get; }
        ITipoDireccion  TipoDirecciones { get; }
        ITipoPersona TipoPersonas { get; }
        ITurno Turnos { get; }
        IRol Roles { get; }
        IUser Users { get; }
        Task<int> SaveAsync();
    }
