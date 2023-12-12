
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class TurnoRepository : GenericRepository<Turno>, ITurno
    {
         private readonly ApiContext _context;

        public TurnoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Turno>> GetAllAsync()
        {
            return await _context.Turnos
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Turno> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.Turnos as IQueryable<Turno>;

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

        public override async Task<Turno> GetByIdAsync(int id)
        {
            return await _context.Turnos
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }