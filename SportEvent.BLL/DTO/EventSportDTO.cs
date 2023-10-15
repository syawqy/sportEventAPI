using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.BLL.DTO
{
    public class EventSportDTO
    {
        public DateTime EventDate { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public OrganizerDTO Organizer { get; set; }
    }
}
