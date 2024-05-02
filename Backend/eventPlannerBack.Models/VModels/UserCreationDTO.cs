namespace eventPlannerBack.Models.VModels
{

    public class UserCreationDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ProfileImage { get; set; }
        public string PhoneNumber { get; set; }
    }
}
