using Student.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StudentAPI.Domain.Entities.Students
{
    public class StudentsEntity
    {
        [Key]
        public int IDCard { get; set; }
    }
}
