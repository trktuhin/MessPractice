using System;

namespace Mess.Resources
{
    public class AuthDataResource
    {
        public string Token { get; set; }

        public DateTime ExpireTime { get; set; }

        public string UserId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

    }
}