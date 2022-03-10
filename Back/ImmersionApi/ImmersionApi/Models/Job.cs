using ImmersionApi.Enums;

namespace ImmersionApi.Models
{
    public class Job
    {
        public int ID { get; private set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Category? Category { get; set; }

        public DateTime? BeginDate { get; set; }
        
        private int? YearLeft { get { return DateTime.Now.Year - BeginDate.Value.Year; } }

        public Job()
        {
            ID = ++Count;
        }

        private static int Count;

    }
}
