namespace ImmersionApi.Models
{
    public class HardSkill
    {
        private static int Count;

        public int? ID { get; set; }
        public string Name { get; set; }

        public HardSkill()
        {
            ID = ++Count;
        }
    }
}
