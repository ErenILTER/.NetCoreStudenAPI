using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentAPI.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : StudentsEntity
    {
        Task<bool> AddAsync(T Model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T Model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T Model);
        Task<int> SaveAsync();
    }
}
