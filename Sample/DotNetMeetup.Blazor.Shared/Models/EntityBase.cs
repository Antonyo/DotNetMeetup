using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetMeetup.Blazor.Shared.Models
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
