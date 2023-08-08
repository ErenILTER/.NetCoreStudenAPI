using StudentAPI.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : StudentsEntity
    {
        IQueryable<T> GetAll(bool tracing = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracing = true);
        Task<T> GetSingeleAsync(Expression<Func<T, bool>> method, bool tracing = true);
        Task<T> GetByIdAsync(string id, bool tracing = true);

    }
}
