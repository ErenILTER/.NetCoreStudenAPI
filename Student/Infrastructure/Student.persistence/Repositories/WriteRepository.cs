using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Student.Application.Repositories;
using Student.Persistence.Contexts;
using StudentAPI.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Persistence.Repositories
{
    public class WriteRepositor<T> : IWriteRepository<T> where T : StudentsEntity
    {
        private readonly StudentAPIDbContext _context;
        public WriteRepositor(StudentAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T Model)
        {
            EntityEntry<T> entityEntry =  await Table.AddAsync(Model);
            return entityEntry.State == EntityState.Added;
        }
        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }
        public bool Remove(T Model)
        {
            EntityEntry<T> entityEntry = Table.Remove(Model);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }
        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.IDCard == Guid.Parse(id));
            return Remove(model);
        }
        public bool Update(T Model)
        {
            EntityEntry entityEntry = Table.Update(Model);
            return entityEntry.State!= EntityState.Modified;
        }
        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
