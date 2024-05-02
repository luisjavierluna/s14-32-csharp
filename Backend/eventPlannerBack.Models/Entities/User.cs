using eventPlannerBack.Models.Entidades;
using Microsoft.AspNetCore.Identity;


namespace eventPlannerBack.Models.Entities
{
    public  class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
