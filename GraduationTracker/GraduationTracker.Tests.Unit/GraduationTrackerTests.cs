using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private const int DIPLOMA_ID = 1;
        [TestMethod]
        public void Graduates()
        {
            Diploma Diploma = Diploma.GetDiploma(DIPLOMA_ID);
            Student[] Students = Repository.GetStudents();

            List<Tuple<bool, STANDING>> GraduatedList = new List<Tuple<bool, STANDING>>();

            foreach(Student Student in Students)
            {
                GraduatedList.Add(GraduationTracker.HasGraduated(Diploma, Student));
                Console.WriteLine("Student: "+Student.Id + GraduationTracker.HasGraduated(Diploma, Student));
            }         
            Assert.IsTrue(GraduatedList.Any());
        }
    }
}
