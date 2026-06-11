using StudentManagement.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DAL
{
    public class DbInitializer : CreateDatabaseIfNotExists<StudentDbContext>
    {
        protected override void Seed(StudentDbContext context)
        {
            var class1 = new ClassRoom { ClassName = "24T_KHDL" };
            var class2 = new ClassRoom { ClassName = "24T_DT1" };
            var class3 = new ClassRoom { ClassName = "24T_DT2" };
            var class4 = new ClassRoom { ClassName = "24T_DT3" };
            var class5 = new ClassRoom { ClassName = "24T_DT4" };
            var class6 = new ClassRoom { ClassName = "24T_DT5" };
            var class7 = new ClassRoom { ClassName = "24T_Nhat1" };
            var class8 = new ClassRoom { ClassName = "24T_Nhat2" };

            context.ClassRooms.AddRange(new ClassRoom[] { class1, class2, class3, class4, class5, class6, class7, class8 });
            context.SaveChanges(); // Lưu trước để có ClassRoomId tự tăng

            context.Students.AddRange(new Student[]
            {
                new Student { StudentId = "101", FullName = "Nguyễn Văn A", Gender = true, DateOfBirth = new DateTime(2006, 1, 1), Gpa = 3.2, ClassRoomId = class1.ClassRoomId },
                new Student { StudentId = "102", FullName = "Nguyễn Văn B", Gender = true, DateOfBirth = new DateTime(2006, 2, 2), Gpa = 4.0, ClassRoomId = class1.ClassRoomId },
                new Student { StudentId = "103", FullName = "Nguyễn Văn C", Gender = true, DateOfBirth = new DateTime(2006, 2, 5), Gpa = 3.5, ClassRoomId = class1.ClassRoomId },
                new Student { StudentId = "104", FullName = "Lê Thị A", Gender = false, DateOfBirth = new DateTime(2006, 2, 9), Gpa = 3.3, ClassRoomId = class1.ClassRoomId },
                new Student { StudentId = "105", FullName = "Lê Thị B", Gender = false, DateOfBirth = new DateTime(2006, 2, 15), Gpa = 3.6, ClassRoomId = class1.ClassRoomId },
                new Student { StudentId = "106", FullName = "Trần Văn A", Gender = true, DateOfBirth = new DateTime(2006, 2, 20), Gpa = 3.9, ClassRoomId = class1.ClassRoomId },

                new Student { StudentId = "107", FullName = "Nguyễn Văn A", Gender = true, DateOfBirth = new DateTime(2006, 1, 26), Gpa = 3.2, ClassRoomId = class2.ClassRoomId },
                new Student { StudentId = "108", FullName = "Nguyễn Văn D", Gender = true, DateOfBirth = new DateTime(2006, 1, 14), Gpa = 3.8, ClassRoomId = class2.ClassRoomId },
                new Student { StudentId = "109", FullName = "Nguyễn Văn E", Gender = true, DateOfBirth = new DateTime(2006, 6, 4), Gpa = 3.4, ClassRoomId = class2.ClassRoomId },
                new Student { StudentId = "110", FullName = "Lê Thị C", Gender = false, DateOfBirth = new DateTime(2006, 6, 10), Gpa = 3.5, ClassRoomId = class2.ClassRoomId },
                new Student { StudentId = "111", FullName = "Lê Thị D", Gender = false, DateOfBirth = new DateTime(2006, 6, 16), Gpa = 3.9, ClassRoomId = class2.ClassRoomId },
                new Student { StudentId = "112", FullName = "Trần Văn B", Gender = true, DateOfBirth = new DateTime(2006, 6, 14), Gpa = 3.1, ClassRoomId = class2.ClassRoomId },
                new Student { StudentId = "113", FullName = "Trần Văn C", Gender = true, DateOfBirth = new DateTime(2006, 6, 18), Gpa = 3.7, ClassRoomId = class2.ClassRoomId },
                new Student { StudentId = "114", FullName = "Trần Văn D", Gender = true, DateOfBirth = new DateTime(2006, 6, 26), Gpa = 3.6, ClassRoomId = class2.ClassRoomId },

                new Student { StudentId = "115", FullName = "Nguyễn Văn A", Gender = true, DateOfBirth = new DateTime(2006, 2, 1), Gpa = 3.2, ClassRoomId = class3.ClassRoomId },
                new Student { StudentId = "116", FullName = "Nguyễn Văn F", Gender = true, DateOfBirth = new DateTime(2006, 2, 1), Gpa = 3.9, ClassRoomId = class3.ClassRoomId },
                new Student { StudentId = "117", FullName = "Nguyễn Văn G", Gender = true, DateOfBirth = new DateTime(2006, 3, 1), Gpa = 3.1, ClassRoomId = class3.ClassRoomId },
                new Student { StudentId = "118", FullName = "Lê Thị E", Gender = false, DateOfBirth = new DateTime(2006, 4, 1), Gpa = 3.5, ClassRoomId = class3.ClassRoomId },
                new Student { StudentId = "119", FullName = "Lê Thị F", Gender = false, DateOfBirth = new DateTime(2006, 5, 1), Gpa = 3.7, ClassRoomId = class3.ClassRoomId },
                new Student { StudentId = "120", FullName = "Trần Văn E", Gender = true, DateOfBirth = new DateTime(2006, 8, 1), Gpa = 3.3, ClassRoomId = class3.ClassRoomId },
                new Student { StudentId = "121", FullName = "Trần Văn F", Gender = true, DateOfBirth = new DateTime(2006, 6, 1), Gpa = 3.6, ClassRoomId = class3.ClassRoomId },

                new Student { StudentId = "122", FullName = "Nguyễn Văn A", Gender = true, DateOfBirth = new DateTime(2006, 5, 10), Gpa = 3.2, ClassRoomId = class4.ClassRoomId },
                new Student { StudentId = "123", FullName = "Nguyễn Văn H", Gender = true, DateOfBirth = new DateTime(2006, 5, 18), Gpa = 3.8, ClassRoomId = class4.ClassRoomId },
                new Student { StudentId = "124", FullName = "Nguyễn Văn I", Gender = true, DateOfBirth = new DateTime(2006, 5, 14), Gpa = 3.5, ClassRoomId = class4.ClassRoomId },
                new Student { StudentId = "125", FullName = "Lê Thị G", Gender = false, DateOfBirth = new DateTime(2006, 6, 7), Gpa = 3.4, ClassRoomId = class4.ClassRoomId },
                new Student { StudentId = "126", FullName = "Lê Thị H", Gender = false, DateOfBirth = new DateTime(2006, 6, 10), Gpa = 3.6, ClassRoomId = class4.ClassRoomId },

                new Student { StudentId = "127", FullName = "Nguyễn Văn A", Gender = true, DateOfBirth = new DateTime(2006, 6, 18), Gpa = 3.2, ClassRoomId = class5.ClassRoomId },
                new Student { StudentId = "128", FullName = "Nguyễn Văn J", Gender = true, DateOfBirth = new DateTime(2006, 6, 18), Gpa = 3.5, ClassRoomId = class5.ClassRoomId },
                new Student { StudentId = "129", FullName = "Nguyễn Văn K", Gender = true, DateOfBirth = new DateTime(2006, 6, 1), Gpa = 3.8, ClassRoomId = class5.ClassRoomId },
                new Student { StudentId = "130", FullName = "Lê Thị I", Gender = false, DateOfBirth = new DateTime(2006, 6, 16), Gpa = 3.4, ClassRoomId = class5.ClassRoomId },
                new Student { StudentId = "131", FullName = "Lê Thị J", Gender = false, DateOfBirth = new DateTime(2006, 8, 5), Gpa = 3.6, ClassRoomId = class5.ClassRoomId },

                new Student { StudentId = "132", FullName = "Nguyễn Văn A", Gender = true, DateOfBirth = new DateTime(2006, 8, 4), Gpa = 3.1, ClassRoomId = class6.ClassRoomId },
                new Student { StudentId = "133", FullName = "Nguyễn Văn L", Gender = true, DateOfBirth = new DateTime(2006, 8, 9), Gpa = 3.9, ClassRoomId = class6.ClassRoomId },
                new Student { StudentId = "134", FullName = "Nguyễn Văn M", Gender = true, DateOfBirth = new DateTime(2006, 8, 7), Gpa = 3.4, ClassRoomId = class6.ClassRoomId },
                new Student { StudentId = "135", FullName = "Lê Thị K", Gender = false, DateOfBirth = new DateTime(2006, 8, 3), Gpa = 3.6, ClassRoomId = class6.ClassRoomId },
                new Student { StudentId = "136", FullName = "Lê Thị L", Gender = false, DateOfBirth = new DateTime(2006, 10, 11), Gpa = 3.5, ClassRoomId = class6.ClassRoomId },

                new Student { StudentId = "137", FullName = "Nguyễn Văn A", Gender = true, DateOfBirth = new DateTime(2006, 10, 19), Gpa = 3.7, ClassRoomId = class7.ClassRoomId },
                new Student { StudentId = "138", FullName = "Nguyễn Văn N", Gender = true, DateOfBirth = new DateTime(2006, 10, 14), Gpa = 3.3, ClassRoomId = class7.ClassRoomId },
                new Student { StudentId = "139", FullName = "Nguyễn Văn O", Gender = true, DateOfBirth = new DateTime(2006, 10, 5), Gpa = 3.4, ClassRoomId = class7.ClassRoomId },
                new Student { StudentId = "140", FullName = "Lê Thị M", Gender = false, DateOfBirth = new DateTime(2006, 10, 5), Gpa = 3.6, ClassRoomId = class7.ClassRoomId },
                new Student { StudentId = "141", FullName = "Lê Thị N", Gender = false, DateOfBirth = new DateTime(2006, 12, 5), Gpa = 3.8, ClassRoomId = class7.ClassRoomId },

                new Student { StudentId = "142", FullName = "Nguyễn Văn A", Gender = true, DateOfBirth = new DateTime(2006, 10, 5), Gpa = 3.9, ClassRoomId = class8.ClassRoomId },
                new Student { StudentId = "143", FullName = "Nguyễn Văn P", Gender = true, DateOfBirth = new DateTime(2006, 10, 4), Gpa = 3.7, ClassRoomId = class8.ClassRoomId },
                new Student { StudentId = "144", FullName = "Nguyễn Văn Q", Gender = true, DateOfBirth = new DateTime(2006, 10, 1), Gpa = 3.8, ClassRoomId = class8.ClassRoomId },
                new Student { StudentId = "145", FullName = "Lê Thị O", Gender = false, DateOfBirth = new DateTime(2006, 10, 6), Gpa = 3.3, ClassRoomId = class8.ClassRoomId },
                new Student { StudentId = "146", FullName = "Lê Thị P", Gender = false, DateOfBirth = new DateTime(2006, 10, 7), Gpa = 3.1, ClassRoomId = class8.ClassRoomId }
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
