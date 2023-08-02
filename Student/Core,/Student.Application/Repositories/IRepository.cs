using Microsoft.EntityFrameworkCore;
using StudentAPI.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.Repositories
{
    public interface IRepository<T> where T : StudentsEntity
    {
        DbSet<T> Table { get; }
    }
}
