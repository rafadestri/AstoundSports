using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstoundSports.Controllers
{
    [Route("api/athletes")]
    [ApiController]
    public class AthletesController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public AthletesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAthlete([FromBody] AthleteForCreationDto athlete)
        {
            if (athlete == null)
            {
                _logger.LogError("Athlete for creation object sent from cliente is null.");
                return BadRequest("AthleteForCreationDto object is null.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the AthleteForCreationDto object.");
                return UnprocessableEntity(ModelState);
            }

            var athleteEntity = _mapper.Map<Athlete>(athlete);

            _repository.Athlete.CreateAthlete(athleteEntity);
            await _repository.SaveAsync();

            var athleteToReturn = _mapper.Map<AthleteDto>(athleteEntity);

            return CreatedAtRoute("AthleteById", new { id = athleteToReturn.Id }, athleteToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAthlete(Guid id)
        {
            var athlete = await _repository.Athlete.GetAthleteAsync(id, trackChanges: false);

            if (athlete == null)
            {
                _logger.LogInfo($"Athlete with id: {id} doesn't exist in the database.");

                return NotFound();
            }

            _repository.Athlete.DeleteAthlete(athlete);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpGet("{id}", Name = "AthleteById")]
        public async Task<IActionResult> GetAthlete(Guid id)
        {
            var athlete = await _repository.Athlete.GetAthleteAsync(id, trackChanges: false);

            if (athlete == null)
            {
                _logger.LogInfo($"Athelte with id: {id} doesn't exist in the database.");

                return NotFound();
            }

            var athleteDto = _mapper.Map<AthleteDto>(athlete);

            return Ok(athleteDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAthletes()
        {
            var athletes = await _repository.Athlete.GetAthletesAsync(trackChanges: false);
            var atheletsDto = _mapper.Map<IEnumerable<AthleteDto>>(athletes);

            return Ok(atheletsDto);
        }

        [HttpGet("{athleteId}/burntCalories/{sportId}")]
        public async Task<IActionResult> GetBurntCalories(Guid athleteId, Guid sportId)
        {
            var athlete = await _repository.Athlete.GetAthleteAsync(athleteId, trackChanges: false);

            if (athlete == null)
            {
                _logger.LogInfo($"Athelte with id: {athleteId} doesn't exist in the database.");

                return NotFound();
            }

            var sport = await _repository.Sport.GetSportAsync(sportId, trackChanges: false);

            if (sport == null)
            {
                _logger.LogInfo($"Sport with id: {sportId} doesn't exist in the database.");

                return NotFound();
            }

            var athleteDto = _mapper.Map<AthleteDto>(athlete);

            return Ok(athleteDto);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateAthlete(Guid id, [FromBody] JsonPatchDocument<AthleteForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var athleteEntity = await _repository.Athlete.GetAthleteAsync(id, trackChanges: true);
            if (athleteEntity == null)
            {
                _logger.LogInfo($"Athlete with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var athleteToPAtch = _mapper.Map<AthleteForUpdateDto>(athleteEntity);

            patchDoc.ApplyTo(athleteToPAtch, ModelState);

            TryValidateModel(athleteToPAtch);
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(athleteToPAtch, athleteEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAthlete(Guid id, [FromBody] AthleteForUpdateDto athlete)
        {
            if (athlete == null)
            {
                _logger.LogError("Athlete for update object sent from cliente is null.");
                return BadRequest("AthleteForUpdateDto is null.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the AthleteForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var athleteEntity = await _repository.Athlete.GetAthleteAsync(id, trackChanges: true);
            if (athleteEntity == null)
            {
                _logger.LogInfo($"Athlete with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(athlete, athleteEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
