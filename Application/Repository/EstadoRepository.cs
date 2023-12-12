
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class EstadoRepository : GenericRepository<Estado>, IEstado
    {
         private readonly ApiContext _context;

        public EstadoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Estado>> GetAllAsync()
        {
            return await _context.Estados
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Estado> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.Estados as IQueryable<Estado>;

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

        public override async Task<Estado> GetByIdAsync(int id)
        {
            return await _context.Estados
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }