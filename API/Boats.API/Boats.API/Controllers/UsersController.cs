using Boats.API.Data;
using Boats.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boats.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly BoatsDbContext boatsDbContext;
        public UsersController(BoatsDbContext boatsDbContext)
        {
            this.boatsDbContext = boatsDbContext;
        }



        [HttpGet]
        //Get all users that are in database
        public async Task<IActionResult> GetAllJobs()
        {
            var users = await boatsDbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetUser")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await boatsDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("Card not found");
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            user.Id = Guid.NewGuid();
            await boatsDbContext.Users.AddAsync(user);

            await boatsDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { user.Id }, user);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var existinguser = await boatsDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existinguser != null)
            {
                boatsDbContext.Remove(existinguser);
                await boatsDbContext.SaveChangesAsync();
                return Ok(existinguser);
            }
            return NotFound("Job not found");
        }


    }
}
