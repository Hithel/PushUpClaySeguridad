
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
    {
         private readonly ApiContext _context;

        public DepartamentoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Departamento> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.Departamentos as IQueryable<Departamento>;

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

        public override async Task<Departamento> GetByIdAsync(int id)
        {
            return await _context.Departamentos
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }