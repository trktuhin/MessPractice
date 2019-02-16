using System.ComponentModel.DataAnnotations;

namespace Mess.Resources
{
    public class RegisterResource
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "MIN_PASSWORD_LENGTH")]
        public string Password { get; set; }
    }
}