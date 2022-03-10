namespace ImmersionApi.Models
{
    public class Diploma
    {
        private static int Count;

        public int? ID { get; set; }
        public string Name { get; set; }

        public Diploma()
        {
            ID = ++Count;
        }
    }
}
