using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [StringLength(10)]
        public string StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public bool Gender { get; set; } // true: Male, false: Female

        public DateTime DateOfBirth { get; set; }

        public double Gpa { get; set; }

        public int ClassRoomId { get; set; }

        [ForeignKey("ClassRoomId")]
        public virtual ClassRoom ClassRoom { get; set; }
    }
}
