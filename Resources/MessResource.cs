using System;

namespace Mess.Resources
{
    public class MessResource
    {
        public int MessId { get; set; }
        public string MessName { get; set; }
        public string OwnerId { get; set; }
        public string location { get; set; }
        public DateTime DateCreated { get; set; }
        public string Currency { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}