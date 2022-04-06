﻿using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
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

        [HttpGet("{id}", Name = "AthleteById")]
        public async Task<IActionResult> GetAthlete(Guid id)
        {
            var athlete = await _repository.Athlete.GetAhtleteAsync(id, trackChanges: false);

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
    }
}