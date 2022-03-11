namespace ImmersionApi.Models
{
    public class SoftSkill
    {
        public int Id { get; set; }
        private static int _count;
        public string Name { get; set; }

        public SoftSkill()
        {
            Id = ++_count;
        }
    }
}
