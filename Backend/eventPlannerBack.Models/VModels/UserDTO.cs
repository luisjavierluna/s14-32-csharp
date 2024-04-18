using eventPlannerBack.Models.Entidades;

namespace eventPlannerBack.Models.VModels
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImage { get; set; }
        public string Role { get; set; }
        public string CUIT { get; set; }
        public string ContractorId { get; set; }
        public string ClientId { get; set; }
    }
}
