using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Student
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public STANDING Standing { get; set; } = STANDING.None;

        public static Student GetStudent(int Id)
        {
            Student[] Students = Repository.GetStudents();
            Student Student = null;

            for (int i = 0; i < Students.Length; i++)
            {
                if (Id == Students[i].Id)
                {
                    Student = Students[i];
                }
            }
            return Student;
        }
    }

    
}
