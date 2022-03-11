namespace ImmersionApi.Models
{
    public class User
    {
        public int? ID { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { set ; get; }
        public bool? IsAdmin { get; set; }
        public string? Avatar { get; set; }
        public int? UserProfilID { get; set; }

        private static int Count { get; set; }

        public User()
        {
            ID = ++Count;
        }
    }
}
