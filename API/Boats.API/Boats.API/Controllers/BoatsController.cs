using Boats.API.Data;
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

        public async Task<IActionResult> PostJob()
        {
            
        }
    }
}
