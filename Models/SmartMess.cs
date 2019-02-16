using System;

namespace Mess.Models
{
    public class SmartMess
    {
        public int MessId { get; set; }
        public string MessName { get; set; }
        public SmartUser Owner { get; set; }
        public string OwnerId { get; set; }
        public string location { get; set; }
        public DateTime DateCreated { get; set; }
        public string Currency { get; set; }
        public DateTime LastUpdated { get; set; }

        public SmartMess(){
            
        }
    }
}