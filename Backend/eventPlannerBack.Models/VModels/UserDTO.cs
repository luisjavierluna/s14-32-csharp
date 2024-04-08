using eventPlannerBack.Models.Entidades;

namespace eventPlannerBack.Models.VModels
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public Contractor Contractor { get; set; }
        public Client Client { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
