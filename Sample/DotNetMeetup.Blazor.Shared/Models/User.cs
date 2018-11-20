using System.ComponentModel.DataAnnotations;

namespace DotNetMeetup.Blazor.Shared.Models
{
    public class User : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
