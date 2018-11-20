using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DotNetMeetup.Blazor.Shared.Models
{
    public class Meetup : EntityBase
    {
        [Required]
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<Attendee> Attendees { get; set; }
    }
}
