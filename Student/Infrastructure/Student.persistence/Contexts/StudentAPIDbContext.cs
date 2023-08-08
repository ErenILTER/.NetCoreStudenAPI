using Microsoft.EntityFrameworkCore;
using Student.Domain.Entities;
using StudentAPI.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Persistence.Contexts
{
    public class StudentAPIDbContext : DbContext
    {
        public StudentAPIDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<StudentInformations> StudentInformation { get; set; }
    }
}
