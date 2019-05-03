namespace GraduationTracker
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
        public int[] Courses { get; set; }

        public static Requirement GetRequirement(int Id)
        {
            var requirements = Repository.GetRequirements();
            Requirement requirement = null;

            for (int i = 0; i < requirements.Length; i++)
            {
                if (Id == requirements[i].Id)
                {
                    requirement = requirements[i];
                }
            }
            return requirement;
        }
    }
}
