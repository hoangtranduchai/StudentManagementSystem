using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DTO.Entities
{
    [Table("ClassRoom")]
    public class ClassRoom
    {
        public ClassRoom()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassRoomId { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
