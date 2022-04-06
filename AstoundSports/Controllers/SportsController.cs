using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
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
    }
}
