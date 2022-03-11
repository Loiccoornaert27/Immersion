namespace ImmersionApi.Models
{
    public class UserProfil
    {
        public int ID { get; set; }
        public Job Job { get; set; }
        public List<SoftSkill> SoftSkills { get; set; }
        public List<HardSkill> HardSkills { get; set; }
        public List<Diploma> Diplomas { get; set; }
    }
}
