using System;
using Microsoft.AspNetCore.Identity;

namespace Mess.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}