using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Application.ViewModels.StudentInformations
{
    public class VM_StudentInformations_Update
    {
        public string IDCard { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentAge { get; set; }
    }
}
