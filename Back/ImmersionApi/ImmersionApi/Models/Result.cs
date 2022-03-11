namespace ImmersionApi.Models
{
    public class Result
    {
        private static int _count;
        public int? ID {get; set;}
        public List<SoftSkill> SoftSkillsNeeded { get; set; }
        public List<HardSkill> HardSkillsNeeded { get; set; }
        public List<Diploma> DiplomasNeeded { get; set; }

        public List<SoftSkill> SoftSkills { get; set; }
        public List<HardSkill> HardSkills { get; set; }
        public List<Diploma> Diplomas { get; set; }

        public Result()
        {
            ID = ++_count;
        }
    }
}
