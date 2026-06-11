using StudentManagement.DAL;
using StudentManagement.DTO.Entities;
using StudentManagement.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.BLL
{
    public class StudentBll
    {
        private static StudentBll _instance;

        public static StudentBll Instance { 
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentBll();
                }
                return _instance;
            }
            private set { }
        }

        public List<ComboboxItem> GetClassRoomComboboxItems()
        {
            return StudentDal.Instance.GetAllClassRooms()
                .Select(p => new ComboboxItem { Value = p.ClassRoomId, Text = p.ClassName }).ToList();
        }

        public List<StudentViewModel> GetStudentViews(int classRoomId, string keyword)
        {
            var list = StudentDal.Instance.GetStudentsByFilter(classRoomId, keyword);
            return list.Select(p => new StudentViewModel
            {
                StudentId = p.StudentId,
                FullName = p.FullName,
                Gender = p.Gender ? "Male" : "Female",
                DateOfBirth = p.DateOfBirth.ToString("yyyy-MM-dd"),
                Gpa = p.Gpa,
                ClassName = p.ClassRoom?.ClassName
            }).ToList();
        }

        public Student GetStudentByStudentId(string studentId)
        {
            return StudentDal.Instance.GetStudentById(studentId);
        }

        public void ExecuteSave(Student student, bool isAddMode)
        {
            if (string.IsNullOrWhiteSpace(student.StudentId) || string.IsNullOrWhiteSpace(student.FullName))
            {
                throw new ArgumentException("Student ID and Full Name are required!");
            }
            if (isAddMode)
            {
                var existingStudent = StudentDal.Instance.GetStudentById(student.StudentId);
                if (existingStudent != null)
                {
                    throw new Exception("This Student ID already exists in the system!");
                }

                StudentDal.Instance.AddStudent(student);
            }
            else
            {
                StudentDal.Instance.UpdateStudent(student);
            }
        }

        public void DeleteStudent(List<string> listStudentId)
        {
            StudentDal.Instance.DeleteStudents(listStudentId);
        }

        public List<StudentViewModel> GetSortedStudentViews(int classRoomId, string keyword, string sortBy)
        {
            var dataViews = GetStudentViews(classRoomId, keyword);
            switch (sortBy)
            {
                case "StudentId":
                    return dataViews.OrderBy(p => p.StudentId).ToList();
                case "FullName":
                    return dataViews.OrderBy(p => p.FullName).ToList();
                case "Gpa":
                    return dataViews.OrderBy(p => p.Gpa).ToList();
                default:
                    return dataViews;
            }
        }
    }
}
