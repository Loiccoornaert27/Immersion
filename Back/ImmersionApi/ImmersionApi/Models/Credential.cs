using System.ComponentModel.DataAnnotations;

namespace ImmersionApi.Models
{
    public class Credential
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
