using StudentManagement.DTO.Entities;
using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;

namespace StudentManagement.DAL
{
    public class StudentDbContext : DbContext
    {
        static StudentDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public StudentDbContext() : base("name=DefaultConnection") { }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
    }
}