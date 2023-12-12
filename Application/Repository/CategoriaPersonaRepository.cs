

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class CategoriaPersonaRepository : GenericRepository<CategoriaPersona>, ICategoriaPersona
    {
         private readonly ApiContext _context;

        public CategoriaPersonaRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<CategoriaPersona>> GetAllAsync()
        {
            return await _context.CategoriaPersonas
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<CategoriaPersona> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.CategoriaPersonas as IQueryable<CategoriaPersona>;

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

        public override async Task<CategoriaPersona> GetByIdAsync(int id)
        {
            return await _context.CategoriaPersonas
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }