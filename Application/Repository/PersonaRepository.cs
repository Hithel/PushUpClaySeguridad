
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
         private readonly ApiContext _context;

        public PersonaRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Persona> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.Personas as IQueryable<Persona>;

            if (!string.IsNullOrEmpty(search.ToString()))
            {
                query = query.Where(p => p.Id.Equals(search));
            }

            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndez - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }

        public override async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas
            .FirstOrDefaultAsync(p => p.Id == id);
        }


        // Consulta 1
        public async Task<IEnumerable<Object>> GetEmpleadosSeguridad()
        {
            var result = await 
            (
                from e in _context.Personas
                where e.TipoPersona.Descripcion == "Empleado" 
                select new
                {
                    NombreEmpleado = e.Nombre,
                    IdEmpleado = e.IdPersona
                }
            ).ToListAsync();

            return result;

        }

        // Consulta 1 Paginada

        public async  Task<(int totalRegistros, IEnumerable<Object> registros)> GetEmpleadosSeguridadPaginado(int pageIndex, int pageSize, string search = null)
        {
            var query =  from e in _context.Personas
                            where e.TipoPersona.Descripcion == "Empleado" 
                            select new
                            {
                                NombreEmpleado = e.Nombre,
                                IdEmpleado = e.IdPersona
                            };
            
            if (!string.IsNullOrEmpty(search.ToString()))
            {
                query = query.Where(p => p.NombreEmpleado.Equals(search));
            }

            query = query.OrderBy(p => p.NombreEmpleado);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);

        }

        //Consulta 2 

        public async Task<IEnumerable<Object>> GetVigilantes()
        {
            var result = await 
            (
                 from e in _context.Personas
                where e.TipoPersona.Descripcion == "Empleado" && e.CategoriaPersona.NombreCategoria == "Vigilante"
                select new
                {
                    NombreEmpleado = e.Nombre,
                    IdEmpleado = e.IdPersona
                }
            ).ToListAsync();

            return result;


        }

        public async Task<(int totalRegistros, IEnumerable<Object> registros)> GetVigilantesPaginado(int pageIndex, int pageSize, string search = null)
        {
            var query =  from e in _context.Personas
                where e.TipoPersona.Descripcion == "Empleado" && e.CategoriaPersona.NombreCategoria == "Vigilante"
                select new
                {
                    NombreEmpleado = e.Nombre,
                    IdEmpleado = e.IdPersona
                };
            
            if (!string.IsNullOrEmpty(search.ToString()))
            {
                query = query.Where(p => p.NombreEmpleado.Equals(search));
            }

            query = query.OrderBy(p => p.NombreEmpleado);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }

        // Consulta 3

        public async Task<IEnumerable<Object>> GetNumerosEmpleados()
        {
             var result = await 
            (
                from e in _context.Personas
                where e.TipoPersona.Descripcion == "Empleado" && e.CategoriaPersona.NombreCategoria == "Vigilante"
                select new
                {
                    NombreEmpleado = e.Nombre,
                    IdEmpleado = e.IdPersona,
                    NumerosContacto =
                    (
                        from nc in _context.ContactoPersonas
                        select new
                        {
                            Contacto1 = nc.Descripcion,
                            Contacto2 = nc.Descripcion
                        }
                    ).Distinct()
                .ToList()
                }
            ).ToListAsync();

            return result;
        }

        public async  Task<(int totalRegistros, IEnumerable<Object> registros)> GetNumerosEmpleadosPaginados(int pageIndex, int pageSize, string search = null)
        {
            var query =  from e in _context.Personas
                where e.TipoPersona.Descripcion == "Empleado" && e.CategoriaPersona.NombreCategoria == "Vigilante"
                select new
                {
                    NombreEmpleado = e.Nombre,
                    IdEmpleado = e.IdPersona,
                    NumerosContacto =
                    (
                        from nc in _context.ContactoPersonas
                        select new
                        {
                            Contacto1 = nc.Descripcion,
                            Contacto2 = nc.Descripcion
                        }
                    ).Distinct()
                .ToList()
                };
            
            if (!string.IsNullOrEmpty(search.ToString()))
            {
                query = query.Where(p => p.NombreEmpleado.Equals(search));
            }

            query = query.OrderBy(p => p.NombreEmpleado);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }
    }