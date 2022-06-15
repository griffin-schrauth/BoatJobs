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
        [Route("id:guid")]
        [ActionName("GetJob")]
        public async Task<IActionResult> GetJob([FromRoute] Guid id)
        {
            var card = await boatsDbContext.Boats.FirstOrDefaultAsync(x=>x.Id == id);
            if(card != null)
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

            return CreatedAtAction(nameof(GetJob),boat.Id,boat);
        }

        // may need to add a Delete job but want to make that specific to user database
    }
}
