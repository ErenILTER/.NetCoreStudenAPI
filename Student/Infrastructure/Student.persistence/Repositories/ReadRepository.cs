using Microsoft.EntityFrameworkCore;
using Student.Application.Repositories;
using Student.Persistence.Contexts;
using StudentAPI.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Student.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : StudentsEntity
    {
        private readonly StudentAPIDbContext _context;
        public ReadRepository(StudentAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracing = true)
        {
            var query = Table.AsQueryable();
            if (!tracing)
               query = query.AsNoTracking();
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracing = true)
        { 
            var query = Table.Where(method);
            if (!tracing)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetSingeleAsync(Expression<Func<T, bool>> method, bool tracing = true)
        { 
            var query =Table.AsQueryable();
            if(!tracing)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
        public async Task<T> GetByIdAsync(string id, bool tracing = true)
        //=> await Table.FirstOrDefaultAsync(data => data.IDCard == int.Parse(id));
        //=> await Table.FindAsync(id);
        {
            var query = Table.AsQueryable();
            if (!tracing)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.IDCard == int.Parse(id));
        }
    }
}
