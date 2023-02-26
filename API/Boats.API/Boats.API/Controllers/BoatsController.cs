using AutoMapper;
using Boats.API.Data;
using Boats.API.IRepository;
using Boats.API.Models;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
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
        public BoatsController(BoatsDbContext boatsDbContext, IUnitOfWork unitOfWork, ILogger<BoatsController> logger, IMapper mapper)
        {
            this.boatsDbContext = boatsDbContext;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]//get all jobs but with limits
        //Get all jobs that have been posted
        [ResponseCache(CacheProfileName = "120SecondsDuration")]
        public async Task<IActionResult> GetAllJobs([FromQuery] RequestParams requestParams)
        { 
            var boats = await _unitOfWork.Boats.GetPagedList(requestParams);
            var results = _mapper.Map<IList<BoatDTO>>(boats);
            return Ok(results);          
        }
        /*
        [HttpGet]//get all jobs updaated to get all jobs on different pages ^^
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
                return StatusCode(500, "Internal server error. Please Try Again");
            }

        }*/
        
        [HttpGet]
        [ResponseCache(CacheProfileName = "120SecondsDuration")]
        [Route("{id:guid}")]
        [ActionName("GetJob")]
        public async Task<IActionResult> GetJob([FromRoute] Guid id)
        {           
            var job = await _unitOfWork.Boats.Get(q => q.Id == id);
            var result = _mapper.Map<BoatDTO>(job);
            return Ok(result);         
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateBoatDTO boatDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Invalid POST attempt in  {nameof(CreateJob)} ");
                return BadRequest(ModelState);
            }
            
            var job = _mapper.Map<Boat>(boatDTO);
            //job.Id = Guid.NewGuid();
            await _unitOfWork.Boats.Insert(job);
            await _unitOfWork.Save();

            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
            //_logger.LogInformation("Adding A Job");
            //boatDTO.Id = Guid.NewGuid();
            //await boatsDbContext.Boats.AddAsync(boatDTO);

            //await boatsDbContext.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetJob), new {id = boatDTO.Id}, boatDTO);
        }

        //[Authorize(Roles = "Administrator")] can add this back later
        [Authorize]
        [HttpPut("{id:guid}")] 
        public async Task<IActionResult> UpdateJob(Guid id,[FromBody] UpdateBoatDTO boatDTO)
        {
            if(!ModelState.IsValid || id == Guid.Empty)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateJob)}");
                return BadRequest(ModelState);
            }
                
            var job = await _unitOfWork.Boats.Get(q => q.Id == id);//converted to string to compare int and guid types
            if (job == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateJob)}");
                return BadRequest("Submitted data is invalid");
            }
            _mapper.Map(boatDTO, job);
            _unitOfWork.Boats.Update(job);
            await _unitOfWork.Save();

            return NoContent();
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
