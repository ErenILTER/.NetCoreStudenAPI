using Student.Application.Repositories;
using Student.Domain.Entities;
using Student.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Persistence.Repositories
{
    public class StudentClubsWriteRepository : WriteRepositor<StudentClubs>, IStudentClubsWriteRepository
    {
        public StudentClubsWriteRepository(StudentAPIDbContext context) : base(context)
        {
        }
    }
}
