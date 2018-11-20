using DotNetMeetup.Blazor.Data;
using DotNetMeetup.Blazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMeetup.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        AppDataContext _dataContext;

        public UsersController(AppDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _dataContext.Users.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<ActionResult<User>> Get(long id)
        {
            var localUser = await _dataContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (localUser == null)
                return NotFound();
            else
                return Ok(localUser);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _dataContext.AddAsync(user).Result;
            await _dataContext.SaveChangesAsync();

            return CreatedAtRoute("GetUser", new { id = result.Entity.Id }, result.Entity);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(long id, User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var localUser = _dataContext.Users.FirstOrDefault(x => x.Id == id);
            if (localUser == null)
                return NotFound();

            localUser.Name = user.Name;
            localUser.Email = user.Email;

            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(long id)
        {
            var localUser = _dataContext.Users.FirstOrDefault(x => x.Id == id);
            if (localUser == null)
                return NotFound();

            _dataContext.Users.Remove(localUser);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
