using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO.ViewModels
{
    public class StudentViewModel
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public double Gpa { get; set; }
        public string ClassName { get; set; }
    }
}
