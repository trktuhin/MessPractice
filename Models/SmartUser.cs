using System;

namespace Mess.Models
{
    public class SmartUser
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}