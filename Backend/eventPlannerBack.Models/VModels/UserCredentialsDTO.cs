using System.ComponentModel.DataAnnotations;

namespace eventPlannerBack.Models.VModels
{
    public class UserCredentialsDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
