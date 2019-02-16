using System;
using System.ComponentModel.DataAnnotations;
namespace Mess.Resources
{
    public class LoginResource
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "MIN_PASSWORD_LENGTH")]
        public string Password { get; set; }
    }
}