using System.ComponentModel.DataAnnotations;

namespace eventPlannerBack.Models.VModels
{

    public class UserCreationDTO
    {
        //[Required]
        //[EmailAddress(ErrorMessage ="El correo registrado no es Valido")]
        public string Email {  get; set; }

        // [Required]
        public string Name { get; set; }

        // [Required]
        public string Surname { get;set; }

        //[Required]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
     
    }
}
