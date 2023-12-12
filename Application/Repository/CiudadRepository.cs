
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
    {
         private readonly ApiContext _context;

        public CiudadRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Ciudad>> GetAllAsync()
        {
            return await _context.Ciudades
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Ciudad> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.Ciudades as IQueryable<Ciudad>;

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

        public override async Task<Ciudad> GetByIdAsync(int id)
        {
            return await _context.Ciudades
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }