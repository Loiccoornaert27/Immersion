namespace ImmersionApi.Models
{
    public class RegularProfil
    {
        public int ID { get; set; }
        public Job Job { get; set; }
        public List<SoftSkill> SoftSkillsNeeded { get; set; }
        public List<HardSkill> HardSkillsNeeded { get; set; }
        public List<Diploma> DiplomasNeeded { get; set; }

        public List<SoftSkill> SoftSkills { get; set; }
        public List<HardSkill> HardSkills { get; set; }
        public List<Diploma> Diplomas { get; set; }
    }
}
