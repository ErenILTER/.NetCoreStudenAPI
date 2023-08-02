using StudentAPI.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{
    public class StudentInformations : StudentsEntity
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentAge { get; set; }
        public ICollection<StudentClubs> StudentClub { get; set; }
    }
}
