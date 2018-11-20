using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetMeetup.Blazor.Shared.Models
{
    public class Attendee
    {
        public long UserId { get; set; }
        public long MeetupId { get; set; }
        public bool WillAttend { get; set; }
    }
}
