
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class TipoDireccionRepository : GenericRepository<TipoDireccion>, ITipoDireccion
    {
         private readonly ApiContext _context;

        public TipoDireccionRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<TipoDireccion>> GetAllAsync()
        {
            return await _context.TipoDirecciones
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<TipoDireccion> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.TipoDirecciones as IQueryable<TipoDireccion>;

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

        public override async Task<TipoDireccion> GetByIdAsync(int id)
        {
            return await _context.TipoDirecciones
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }