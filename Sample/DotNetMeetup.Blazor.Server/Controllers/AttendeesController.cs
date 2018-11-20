using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMeetup.Blazor.Data;
using DotNetMeetup.Blazor.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMeetup.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        AppDataContext _dataContext;

        public AttendeesController(AppDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPut]
        public async Task<IActionResult> Put(Attendee attendee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var localAttendee = await _dataContext.FindAsync<Attendee>(attendee.MeetupId, attendee.UserId);

            if (localAttendee != null)
                localAttendee.WillAttend = attendee.WillAttend;
            else
                _dataContext.Add<Attendee>(attendee);

            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}