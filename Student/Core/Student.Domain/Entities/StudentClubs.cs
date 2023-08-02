using Student.Domain.Entities;
using StudentAPI.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{

    public class StudentClubs : StudentsEntity
    {
        public int StudentClubId { get; set; }
        public string StudentClubName { get; set; }
        public ICollection<StudentInformations> StudentInformation { get; set; }




    }
}