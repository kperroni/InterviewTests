// <copyright file="Repository.cs" company="Xello">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Graduation.Repository
{
    using Graduation.Models;

    /// <summary>
    /// Class holding repository and supprted functions.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Reterive specific Student info from diploma repo
        /// </summary>
        /// <param name="id">identity key</param>
        /// <returns>Student Model</returns>
        public static Student GetStudent(int id)
        {
            Student student = null;
            var students = GetStudents();

            for (int i = 0; i < students.Length; i++)
            {
                if (id == students[i].Id)
                {
                    student = students[i];
                }
            }

            return student;
        }

        /// <summary>
        /// Reterive specific Diploma info from diploma repo
        /// </summary>
        /// <param name="id">Identify</param>
        /// <returns>Diploma Model</returns>
        public static Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            Diploma diploma = null;

            for (int i = 0; i < diplomas.Length; i++)
            {
                if (id == diplomas[i].Id)
                {
                    diploma = diplomas[i];
                }
            }

            return diploma;
        }

        /// <summary>
        /// Reterive specific Requirement info from requirement repo
        /// </summary>
        /// <param name="id">Identify</param>
        /// <returns>Requirement Model</returns>
        public static Requirement GetRequirement(int id)
        {
            var requirements = GetRequirements();
            Requirement requirement = null;

            for (int i = 0; i < requirements.Length; i++)
            {
                if (id == requirements[i].Id)
                {
                    requirement = requirements[i];
                }
            }

            return requirement;
        }

        /// <summary>
        /// Reterive specific Requirement info from requirement repo
        /// </summary>
        /// <param name="id">Identify</param>
        /// <returns>Requirement Model</returns>
        private static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[]{100,102,103,104}
                }
            };
        }

        /// <summary>
        /// Get All Requirements from database
        /// </summary>
        /// <returns>Requirement list</returns>
        public static Requirement[] GetRequirements()
        {
            return new[]
            {
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new int[]{1}, Credits=1 },
                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new int[]{2}, Credits=1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new int[]{3}, Credits=1},
                    new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new int[]{4}, Credits=1 }
                };
        }

        /// <summary>
        /// Get All Student info from database
        /// </summary>
        /// <returns>Student list</returns>
        public static Student[] GetStudents()
        {
            return new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark = 95 },
                        new Course{Id = 2, Name = "Science", Mark = 40 },
                        new Course{Id = 3, Name = "Literature", Mark = 60 },
                        new Course{Id = 4, Name = "Physichal Education", Mark = 23 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark = 80 },
                        new Course{Id = 2, Name = "Science", Mark = 49 },
                        new Course{Id = 3, Name = "Literature", Mark = 68 },
                        new Course{Id = 4, Name = "Physichal Education", Mark = 55 }
                   }
               },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark= 70 },
                        new Course{Id = 2, Name = "Science", Mark= 90 },
                        new Course{Id = 3, Name = "Literature", Mark= 20 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=60 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark= 50 },
                        new Course{Id = 2, Name = "Science", Mark=30 },
                        new Course{Id = 3, Name = "Literature", Mark=20 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=10 }
                    }
                }
            };
        }
    }
}
