using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.DTOs;
using AutoMapper;
using CoVoyageur.API.Data;
using CoVoyageur.Core.Models;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using CoVoyageur.API.Repositories.Interfaces;

namespace CoVoyageur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IRepository<Ride> _repository;
        private readonly IMapper _mapper;

        public RideController(IRepository<Ride> repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Ride> rides = await _repository.GetAll();
            IEnumerable<RideDTO> ridesDTO = _mapper.Map<IEnumerable<RideDTO>>(rides)!;
            return Ok(ridesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ride = await _repository.GetById(id);
            if (ride == null)
                return NotFound(new { Message = "There is no Ride with this Id." });

            RideDTO rideDTO = _mapper.Map<RideDTO>(ride)!;
            return Ok(new { Message = "Ride found.", Ride = rideDTO });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] RideDTO rideDTO)
        {
            var rideFromDb = await _repository.GetById(id);
            if (rideFromDb == null)
                return NotFound("There is no Ride with this Id.");

            rideDTO.ID = id;

            var ride = _mapper.Map<Ride>(rideDTO)!;
            var rideUpdated = await _repository.Update(ride);
            var rideUpdatedDTO = _mapper.Map<RideDTO>(rideUpdated);

            return (rideUpdated != null) ? Ok(new { Message = "Ride Updated.", Ride = rideUpdatedDTO }) : BadRequest("Something went wrong...");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RideDTO rideDTO)
        {
            var ride = _mapper.Map<Ride>(rideDTO)!;
            var rideAdded = await _repository.Add(ride);
            var rideAddedDTO = _mapper.Map<RideDTO>(rideAdded)!;

            return (rideAdded != null) ? CreatedAtAction(nameof(GetById), new { id = rideAddedDTO.ID }, new { Message = "Ride Added.", Ride = rideAddedDTO }) : BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return (await _repository.Delete(id)) ? Ok("ok : ride deleted") : BadRequest();
        }


    }
}