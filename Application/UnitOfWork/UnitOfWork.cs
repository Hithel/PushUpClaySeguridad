using Application.Repository;
using Domain.Interfaces;
using Persistence;
using Persistence.Data.Configuration;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        
        private readonly ApiContext _context;


        
        private CategoriaPersonaRepository _categoriaPersona;
        private CiudadRepository _ciudad;
        private ContactoPersonaRepository _contactoPersona;
        private ContratoRepository _contrato;
        private DepartamentoRepository _departamento;
        private DireccionPersonaRepository _direccionPersona;
        private EstadoRepository _estado;
        private PaisRepository _pais;
        private PersonaRepository _persona;
        private ProgramacionRepository _programacion;
        private TipoContactoRepository _tipoContacto;
        private TipoDireccionRepository _tipoDireccion;
        private TipoPersonaRepository _tipoPersona;
        private TurnoRepository _turno;
        private UserRepository _users;
        private RolRepository _roles; 

     public UnitOfWork (ApiContext context)
        {
            _context = context;
        }

        // Controll de nulos para los repositorios

        public ICategoriaPersona CategoriaPersonas
        {
            get
            {
                if (_categoriaPersona == null)
                {
                    _categoriaPersona = new CategoriaPersonaRepository(_context);
                }
                return _categoriaPersona;
            }
        }
        public ICiudad Ciudades
        {
            get
            {
                if (_ciudad == null)
                {
                    _ciudad = new CiudadRepository(_context);
                }
                return _ciudad;
            }
        }
        public IContactoPersona ContactoPersonas
        {
            get
            {
                if (_contactoPersona == null)
                {
                    _contactoPersona = new ContactoPersonaRepository(_context);
                }
                return _contactoPersona;
            }
        }
        public IContrato Contratos
        {
            get
            {
                if (_contrato == null)
                {
                    _contrato = new ContratoRepository(_context);
                }
                return _contrato;
            }
        }
        public IDepartamento Departamentos
        {
            get
            {
                if (_departamento == null)
                {
                    _departamento = new DepartamentoRepository(_context);
                }
                return _departamento;
            }
        }
        public IDireccionPersona DireccionPersonas
        {
            get
            {
                if (_direccionPersona == null)
                {
                    _direccionPersona = new DireccionPersonaRepository(_context);
                }
                return _direccionPersona;
            }
        }
        public IEstado Estados
        {
            get
            {
                if (_estado == null)
                {
                    _estado = new EstadoRepository(_context);
                }
                return _estado;
            }
        }
        public IPais Paises
        {
            get
            {
                if (_pais == null)
                {
                    _pais = new PaisRepository(_context);
                }
                return _pais;
            }
        }
        public IPersona Personas
        {
            get
            {
                if (_persona == null)
                {
                    _persona = new PersonaRepository(_context);
                }
                return _persona;
            }
        }
        public IProgramacion Programaciones
        {
            get
            {
                if (_programacion == null)
                {
                    _programacion = new ProgramacionRepository(_context);
                }
                return _programacion;
            }
        }

        public ITipoContacto TipoContactos
        {
            get
            {
                if (_tipoContacto == null)
                {
                    _tipoContacto = new TipoContactoRepository(_context);
                }
                return _tipoContacto;
            }
        }
        public ITipoDireccion TipoDirecciones
        {
            get
            {
                if (_tipoDireccion == null)
                {
                    _tipoDireccion = new TipoDireccionRepository(_context);
                }
                return _tipoDireccion;
            }
        }

        public ITipoPersona TipoPersonas
        {
            get
            {
                if (_tipoPersona == null)
                {
                    _tipoPersona = new TipoPersonaRepository(_context);
                }
                return _tipoPersona;
            }
        }
        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public ITurno Turnos
        {
            get
            {
                if (_turno == null)
                {
                    _turno = new TurnoRepository(_context);
                }
                return _turno;
            }
        }

        public IRol Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }





    }
}
