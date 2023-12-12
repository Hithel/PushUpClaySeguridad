

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class PaisRepository : GenericRepository<Pais>, IPais
    {
         private readonly ApiContext _context;

        public PaisRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.Paises as IQueryable<Pais>;

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

        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }