using AutoMapper;
using Boats.API.Data;
using Boats.API.IRepository;
using Boats.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boats.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoatsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly BoatsDbContext boatsDbContext;

        private readonly ILogger<BoatsController> _logger;
        private readonly IMapper _mapper;
        public BoatsController(BoatsDbContext boatsDbContext,IUnitOfWork unitOfWork, ILogger<BoatsController> logger, IMapper mapper)
        {
            this.boatsDbContext = boatsDbContext;
            _logger = logger; 
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }


        [HttpGet]
        //Get all jobs that have been posted
        public async Task<IActionResult> GetAllJobs()
        {
            try
            {
                var boats = await _unitOfWork.Boats.GetAll();
                var results = _mapper.Map<IList<BoatDTO>>(boats);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetAllJobs)}");
                return StatusCode(500,"Internal server error. Please Try Again");
            }
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetJob")]
        public async Task<IActionResult> GetJob([FromRoute] Guid id)
        {
            try
            {
                var job = await _unitOfWork.Boats.Get( q => q.Id == id);
                var result = _mapper.Map<BoatDTO>(job);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetAllJobs)}");
                return StatusCode(500, "Internal server error. Please Try Again");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddJob([FromBody] Boat boat)
        {

            _logger.LogInformation("Adding A Job");
            boat.Id = Guid.NewGuid();
            await boatsDbContext.Boats.AddAsync(boat);

            await boatsDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJob), new {id = boat.Id}, boat);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteJob([FromRoute] Guid id)
        {
            _logger.LogInformation("Deleting A Job");
            var existingJob = await boatsDbContext.Boats.FirstOrDefaultAsync(x => x.Id == id);
            if (existingJob != null)
            {
                boatsDbContext.Remove(existingJob); 
                await boatsDbContext.SaveChangesAsync();
                return Ok(existingJob);
            }
            return NotFound("Job not found");
        }

       
    }
}
