namespace ImmersionApi.Models
{
    public class UserProfil
    {
        public int ID { get; set; }
        public Job Job { get; set; }
        public List<int> SoftSkills { get; set; }
        public List<int> HardSkills { get; set; }
        public List<int> Diplomas { get; set; }
    }
}
