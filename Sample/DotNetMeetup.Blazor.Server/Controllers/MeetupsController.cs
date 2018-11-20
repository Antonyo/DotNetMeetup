using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMeetup.Blazor.Data;
using DotNetMeetup.Blazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetMeetup.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupsController : ControllerBase
    {
        AppDataContext _dataContext;

        public MeetupsController(AppDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/Meetups
        [HttpGet]
        public async Task<IEnumerable<Meetup>> GetAsync()
        {
            return await _dataContext.Meetups.Include(x => x.Attendees).OrderByDescending(x => x.Date).AsNoTracking().ToListAsync();
        }
    }
}
