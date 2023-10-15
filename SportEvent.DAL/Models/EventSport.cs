using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.DAL.Models
{
    public class EventSport : ModelBase
    {
        public DateTime EventDate { get; set; } 
        public string EventName { get; set; } 
        public string EventType { get; set; }
        public Organizer Organizer { get; set; }
    }
}
