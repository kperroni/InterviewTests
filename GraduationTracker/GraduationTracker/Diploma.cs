using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Diploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public int[] Requirements { get; set; }

        public static Diploma GetDiploma(int Id)
        {
            Diploma[] Diplomas = Repository.GetDiplomas();
            Diploma Diploma = null;

            for (int i = 0; i < Diplomas.Length; i++)
            {
                if (Id == Diplomas[i].Id)
                {
                    Diploma = Diplomas[i];
                }
            }
            return Diploma;

        }
    }
}
