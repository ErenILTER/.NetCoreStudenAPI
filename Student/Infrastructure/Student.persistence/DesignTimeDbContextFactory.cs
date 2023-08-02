using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Student.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Persistence
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StudentAPIDbContext>
    {
        public StudentAPIDbContext CreateDbContext(string[] args)
        {

            DbContextOptionsBuilder<StudentAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
