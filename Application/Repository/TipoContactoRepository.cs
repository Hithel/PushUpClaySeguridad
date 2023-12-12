

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class TipoContactoRepository : GenericRepository<TipoContacto>, ITipoContacto
    {
         private readonly ApiContext _context;

        public TipoContactoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<TipoContacto>> GetAllAsync()
        {
            return await _context.TipoContactos
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<TipoContacto> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.TipoContactos as IQueryable<TipoContacto>;

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

        public override async Task<TipoContacto> GetByIdAsync(int id)
        {
            return await _context.TipoContactos
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }