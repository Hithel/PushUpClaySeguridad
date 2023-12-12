
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class ContratoRepository : GenericRepository<Contrato>, IContrato
    {
         private readonly ApiContext _context;

        public ContratoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Contrato>> GetAllAsync()
        {
            return await _context.Contratos
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Contrato> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.Contratos as IQueryable<Contrato>;

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

        public override async Task<Contrato> GetByIdAsync(int id)
        {
            return await _context.Contratos
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }