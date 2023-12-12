
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class ContactoPersonaRepository : GenericRepository<ContactoPersona>, IContactoPersona
    {
         private readonly ApiContext _context;

        public ContactoPersonaRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<ContactoPersona>> GetAllAsync()
        {
            return await _context.ContactoPersonas
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<ContactoPersona> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.ContactoPersonas as IQueryable<ContactoPersona>;

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

        public override async Task<ContactoPersona> GetByIdAsync(int id)
        {
            return await _context.ContactoPersonas
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }