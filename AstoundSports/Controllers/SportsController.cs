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
    [Route("api/sports")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public SportsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSport([FromBody] SportForCreationDto sport)
        {
            if (sport == null)
            {
                _logger.LogError("Sport for creation object sent from cliente is null.");
                return BadRequest("SportForCreationDto object is null.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SportForCreationDto object.");
                return UnprocessableEntity(ModelState);
            }

            var sportEntity = _mapper.Map<Sport>(sport);

            _repository.Sport.CreateSport(sportEntity);
            await _repository.SaveAsync();

            var sportToReturn = _mapper.Map<SportDto>(sportEntity);

            return CreatedAtRoute("SportById", new { id = sportToReturn.Id }, sportToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSport(Guid id)
        {
            var sport = await _repository.Sport.GetSportAsync(id, trackChanges: false);

            if (sport == null)
            {
                _logger.LogInfo($"Sport with id: {id} doesn't exist in the database.");

                return NotFound();
            }

            _repository.Sport.DeleteSport(sport);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpGet("{id}", Name = "SportById")]
        public async Task<IActionResult> GetSport(Guid id)
        {
            var sport = await _repository.Sport.GetSportAsync(id, trackChanges: false);

            if (sport == null)
            {
                _logger.LogInfo($"Sport with id: {id} doesn't exist in the database.");

                return NotFound();
            }

            var sportDto = _mapper.Map<SportDto>(sport);

            return Ok(sportDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetSports()
        {
            var sports = await _repository.Sport.GetSportsAsync(trackChanges: false);
            var sportDto = _mapper.Map<IEnumerable<SportDto>>(sports);

            return Ok(sportDto);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateSport(Guid id, [FromBody] JsonPatchDocument<SportForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var sportEntity = await _repository.Sport.GetSportAsync(id, trackChanges: true);
            if (sportEntity == null)
            {
                _logger.LogInfo($"Sport with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var sportToPatch = _mapper.Map<SportForUpdateDto>(sportEntity);

            patchDoc.ApplyTo(sportToPatch, ModelState);

            TryValidateModel(sportToPatch);
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(sportToPatch, sportEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSport(Guid id, [FromBody] SportForUpdateDto sport)
        {
            if (sport == null)
            {
                _logger.LogError("Sport for update object sent from cliente is null.");
                return BadRequest("SportForUpdateDto is null.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SportForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var sportEntity = await _repository.Sport.GetSportAsync(id, trackChanges: true);
            if (sportEntity == null)
            {
                _logger.LogInfo($"sport with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(sport, sportEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
