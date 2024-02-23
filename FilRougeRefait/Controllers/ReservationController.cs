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
    public class ReservationController : ControllerBase
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IMapper _mapper;

        public ReservationController(IRepository<Reservation> repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Reservation> reservations = await _repository.GetAll();
            IEnumerable<ReservationDTO> reservationsDTO = _mapper.Map<IEnumerable<ReservationDTO>>(reservations)!;
            return Ok(reservationsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await _repository.GetById(id);
            if (reservation == null)
                return NotFound(new { Message = "There is no Reservation with this Id." });

            ReservationDTO reservationDTO = _mapper.Map<ReservationDTO>(reservation)!;
            return Ok(new { Message = "Reservation found.", Reservation = reservationDTO });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ReservationDTO reservationDTO)
        {
            var reservationFromDb = await _repository.GetById(id);
            if (reservationFromDb == null)
                return NotFound("There is no Reservation with this Id.");

            reservationDTO.ID = id;

            var reservation = _mapper.Map<Reservation>(reservationDTO)!;
            var reservationUpdated = await _repository.Update(reservation);
            var reservationUpdatedDTO = _mapper.Map<ReservationDTO>(reservationUpdated);

            return (reservationUpdated != null) ? Ok(new { Message = "Reservation Updated.", Reservation = reservationUpdatedDTO }) : BadRequest("Something went wrong...");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservationDTO reservationDTO)
        {
            var reservation = _mapper.Map<Reservation>(reservationDTO)!;
            var reservationAdded = await _repository.Add(reservation);
            var reservationAddedDTO = _mapper.Map<ReservationDTO>(reservationAdded)!;

            return (reservationAdded != null) ? CreatedAtAction(nameof(GetById), new { id = reservationAddedDTO.ID }, new { Message = "Reservation Added.", Reservation = reservationAddedDTO }) : BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return (await _repository.Delete(id)) ? Ok("ok : reservation deleted") : BadRequest();
        }


    }
}