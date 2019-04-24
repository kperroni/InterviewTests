// <copyright file="GraduationTracker.cs" company="Xello">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>




/**
 * 
 * 
 * 
 * 
    1. get all students that have passed Math with a passing grade of 50 or above.
    2. get all students that have failed Science
    3. get list of students grouped by student id + highest graded course
 * 
 * 
 * 
 * 
 **/




namespace Graduation.BAL
{
    using System;
    using System.Collections.Generic;
    using Graduation.Models;
    using Graduation.Repository;
    using Graduation.Utilities;

    /// <summary>
    /// Business logic to track graduation logic.
    /// </summary>
    public class GraduationTracker
    {
        /// <summary>
        /// Business Logic to determine if the students has graduated
        /// </summary>
        /// <param name="student">Student info</param>
        /// <param name="diploma">Diploma info</param>
        /// <returns>Tuple<bool, STANDING></returns>
        public Tuple<bool, STANDING> HasGraduated(Student student, Diploma diploma)
        {
            try
            {
                var average = this.CalculateAverage(student, diploma);

                var hasGraduated = this.ProcessAverage(average);

                return hasGraduated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busines Logic to derieve average
        /// </summary>
        /// <param name="student">Student info</param>
        /// <param name="diploma">Diploma info</param>
        /// /// <returns>average</returns>
        private int CalculateAverage(Student student, Diploma diploma)
        {
            try
            {
                var credits = 0;
                var average = 0;
                for (int i = 0; i < diploma.Requirements.Length; i++)
                {
                    for (int j = 0; j < student.Courses.Length; j++)
                    {
                        var requirement = Repository.GetRequirement(diploma.Requirements[i]);

                        for (int k = 0; k < requirement.Courses.Length; k++)
                        {
                            if (requirement.Courses[k] == student.Courses[j].Id)
                            {
                                average += student.Courses[j].Mark;
                                if (student.Courses[j].Mark > requirement.MinimumMark)
                                {
                                    credits += requirement.Credits;
                                }
                            }
                        }
                    }
                }

                return average / student.Courses.Length;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Process Average and derieve Standing
        /// </summary>
        /// <param name="average">average</param>
        /// <returns>hasGraduated</returns>
        private Tuple<bool, STANDING> ProcessAverage(int average)
        {
            var standing = this.GetStanding(average);

            switch (standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING>(false, standing);
                case STANDING.Average:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.SumaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);
                default:
                    return new Tuple<bool, STANDING>(false, standing);
            }
        }

        /// <summary>
        ///  Function to get Standing based on average.
        /// </summary>
        /// <param name="average">int value</param>
        /// <returns>Standinh enum</returns>
        private STANDING GetStanding(int average)
        {
            if (average < 50)
            {
                return STANDING.Remedial;
            }
            else if (average < 80)
            {
                return STANDING.Average;
            }
            else if (average < 95)
            {
                return STANDING.MagnaCumLaude;
            }
            else if (average <= 100)
            {
                return STANDING.MagnaCumLaude;
            }
            else
            {
                return STANDING.None;
            }
        }
        /// <summary>
        ///   1. get all students that have passed Math with a passing grade of 50 or above.
        /// </summary>
        /// <param name="passingMark">default 50 but in case it changes let us make it easy by passing</param>
        private List<Student> GetListOfStudentPassedInMath(int passingMark = 50)
        {
            List<Student> passedStudents = new List<Student>();
            //List<Student> allStudents = new List<Student>();
            var allStudents = Repository.GetStudents();
            foreach (Student eachStudent in allStudents)
            {
                foreach (Course eachCourse in eachStudent.Courses)
                {
                    if (eachCourse.Name == "Math" && eachCourse.Mark >= passingMark)
                    {
                        passedStudents.Add(eachStudent);
                    }
                }

            }
            return passedStudents;
        }

        /// <summary>
        ///   1. get all students that have failed science.
        /// </summary>
        /// <param name="passingMark">default 50 but in case it changes let us make it easy by passing</param>
        private List<Student> GetListOfStudentFailedInSceince(int passingMark = 50)
        {
            List<Student> failedStudents = new List<Student>();
            //List<Student> allStudents = new List<Student>();
            var allStudents = Repository.GetStudents();
            foreach (Student eachStudent in allStudents)
            {
                foreach (Course eachCourse in eachStudent.Courses)
                {
                    if (eachCourse.Name == "Science" && eachCourse.Mark < passingMark)
                    {
                        failedStudents.Add(eachStudent);
                    }
                }

            }
            return failedStudents;
        }


        /// <summary>
        ///  get list of students grouped by student id + highest graded course
        /// </summary>
        private List<Student> GetListOfStudentWithHighestGradeCourses()
        {
            List<Student> StudentWithHighestGradeCourse = new List<Student>();
            //List<Student> allStudents = new List<Student>();
            int latestMaxMark = 0;
            Course highestGradeCourse = new Course();
            var allStudents = Repository.GetStudents();
            foreach (Student eachStudent in allStudents)
            {
                //eachStudent.Courses.
                foreach (Course eachCourse in eachStudent.Courses)
                {
                    if (latestMaxMark < eachCourse.Mark)
                    {
                        latestMaxMark = eachCourse.Mark;
                        highestGradeCourse = eachCourse;
                    }
                }
                StudentWithHighestGradeCourse.Add(new Student
                {
                    Id = eachStudent.Id,
                    Courses = new Course[]
                    {
                        new Course
                        {
                            Id = highestGradeCourse.Id,
                            Mark = highestGradeCourse.Mark,
                            Name = highestGradeCourse.Name
                        }
                    }
                }
                );
            }
            return StudentWithHighestGradeCourse;
        }
    }
}
