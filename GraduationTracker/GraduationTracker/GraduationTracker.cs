using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public static Tuple<bool, STANDING> HasGraduated(Diploma Diploma, Student Student)
        {      
            STANDING Standing = GetStanding(GetAverage(Diploma, Student));

            switch (Standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING>(false, Standing);
                case STANDING.Average:
                    return new Tuple<bool, STANDING>(true, Standing);
                case STANDING.SumaCumLaude:
                    return new Tuple<bool, STANDING>(true, Standing);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(true, Standing);

                default:
                    return new Tuple<bool, STANDING>(false, Standing);
            } 
        }

        private static STANDING GetStanding(float Average)
        {
            if (Average < 50)
                return STANDING.Remedial;
            else if (Average < 80)
                return STANDING.Average;
            else if (Average < 95)
                return STANDING.SumaCumLaude;
            else
                return STANDING.MagnaCumLaude;
        }

        private static float GetAverage(Diploma Diploma, Student Student)
        {
            int Credits = 0;
            float Marks = 0;

            for (int i = 0; i < Diploma.Requirements.Length; i++)
            {
                for (int j = 0; j < Student.Courses.Length; j++)
                {
                    Requirement Requirement = Requirement.GetRequirement(Diploma.Requirements[i]);

                    for (int k = 0; k < Requirement.Courses.Length; k++)
                    {
                        if (Requirement.Courses[k] == Student.Courses[j].Id)
                        {
                            Marks += Student.Courses[j].Mark;
                            if (Student.Courses[j].Mark > Requirement.MinimumMark)
                            {
                                Credits += Requirement.Credits;
                            }
                        }
                    }
                }
            }

            return Marks / Student.Courses.Length;
        }
    }
}
