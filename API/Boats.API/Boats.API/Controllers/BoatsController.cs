using Boats.API.Data;
using Boats.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boats.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoatsController : Controller
    {
        private readonly BoatsDbContext boatsDbContext;

        public BoatsController(BoatsDbContext boatsDbContext)
        {
            this.boatsDbContext = boatsDbContext;
        }


        [HttpGet]
        //Get all jobs that have been posted
        public async Task<IActionResult> GetAllJobs()
        {
            var boats = await boatsDbContext.Boats.ToListAsync();
            return Ok(boats);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetJob")]
        public async Task<IActionResult> GetJob([FromRoute] Guid id)
        {
            var card = await boatsDbContext.Boats.FirstOrDefaultAsync(x => x.Id == id);
            if (card != null)
            {
                return Ok(card);
            }
            return NotFound("Card not found");
        }

        [HttpPost]
        public async Task<IActionResult> AddJob([FromBody] Boat boat)
        {
            boat.Id = Guid.NewGuid();
            await boatsDbContext.Boats.AddAsync(boat);

            await boatsDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJob), boat.Id, boat);
        }

        // below will be all the API calls for the user accounts
        //GRIFFIN WE NEED TO MAKE A SEPERATE CONTROLLER FOR EACH TABLE :)

        //    [HttpGet]
        //    [Route("{id:guid}")]
        //    [ActionName("GetUser")]
        //    public async Task<IActionResult> GetUser([FromRoute] Guid id)
        //    {
        //        var userInfo = await boatsDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        //        if (userInfo != null)
        //        {
        //            return Ok(userInfo);
        //        }
        //        return NotFound("User not found");
        //    }




        //    [HttpPost]
        //    public async Task<IActionResult> AddUser([FromBody] User user)
        //    {
        //        user.Id = Guid.NewGuid();
        //        await boatsDbContext.Users.AddAsync(user);
        //        await boatsDbContext.SaveChangesAsync();
        //        return CreatedAtAction(nameof(GetUser),user.Id,user);
        //    }
        //}
    }
}
