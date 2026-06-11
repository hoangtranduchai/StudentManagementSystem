using System.Data.Entity;
using StudentManagement.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DAL
{
    public class StudentDal
    {
        private static StudentDal _instance;

        public static StudentDal Instance { 
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentDal();
                }
                return _instance;
            }
            private set { }
        }

        private StudentDal() { }

        public List<ClassRoom> GetAllClassRooms()
        {
            using (var db = new StudentDbContext())
            {
                return db.ClassRooms.ToList();
            }
        }

        public List<Student> GetStudentsByFilter(int classRoomId, string keyword)
        {
            using (var db = new StudentDbContext())
            {
                // 1. Khởi tạo truy vấn gốc (LUÔN CÓ INCLUDE ĐỂ TRÁNH DISPOSED)
                IQueryable<Student> query = db.Students.Include(s => s.ClassRoom);

                // 2. Cộng dồn bộ lọc Lớp học (nếu người dùng có chọn lớp)
                if (classRoomId > 0)
                {
                    query = query.Where(p => p.ClassRoomId == classRoomId);
                }

                // 3. Cộng dồn bộ lọc Từ khóa (nếu người dùng có nhập chữ)
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(p => p.FullName.ToLower().Contains(keyword.ToLower()) || p.StudentId.Contains(keyword));
                }

                // 4. Lệnh "Chốt hạ" (Execute): 
                // Khi gọi .ToList(), EF mới mang toàn bộ các lệnh .Where() ở trên ghép thành 1 câu SQL WHERE... AND... hoàn chỉnh.
                return query.ToList();
            }
        }

        public void AddStudent(Student student)
        {
            using (var db = new StudentDbContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var db = new StudentDbContext())
            {
                var current = db.Students.Find(student.StudentId);
                if (current != null)
                {
                    current.FullName = student.FullName;
                    current.Gender = student.Gender;
                    current.DateOfBirth = student.DateOfBirth;
                    current.Gpa = student.Gpa;
                    current.ClassRoomId = student.ClassRoomId;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteStudents(List<string> studentIds)
        {
            using (var db = new StudentDbContext())
            {
                var studentsToDelete = db.Students.Where(s => studentIds.Contains(s.StudentId)).ToList();
                db.Students.RemoveRange(studentsToDelete);
                db.SaveChanges();
            }
        }

        public Student GetStudentById(string studentId)
        {
            using (var db = new StudentDbContext())
            {
                return db.Students.Find(studentId);
            }
        }
    }
}
