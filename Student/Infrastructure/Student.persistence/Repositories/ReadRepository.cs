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

        public IQueryable<T> GetAll()
        => Table; 
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);
        public async Task<T> GetSingeleAsync(Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);
        public async Task<T> GetByIdAsync(string id)
            //=> await Table.FirstOrDefaultAsync(data => data.IDCard == int.Parse(id));
            => await Table.FindAsync(id);
    }
}
