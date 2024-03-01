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
    public class FeedbackController : ControllerBase
    {
        private readonly IRepository<Feedback> _repository;
        private readonly IMapper _mapper;

        public FeedbackController(IRepository<Feedback> repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Feedback> feedbacks = await _repository.GetAll();
            IEnumerable<FeedbackDTO> feedbacksDTO = _mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks)!;
            return Ok(feedbacksDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feedback = await _repository.GetById(id);
            if (feedback == null)
                return NotFound(new { Message = "There is no Feedback with this Id." });

            FeedbackDTO feedbackDTO = _mapper.Map<FeedbackDTO>(feedback)!;
            return Ok(new { Message = "Feedback found.", Feedback = feedbackDTO });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] FeedbackDTO feedbackDTO)
        {
            var feedbackFromDb = await _repository.GetById(id);
            if (feedbackFromDb == null)
                return NotFound("There is no Feedback with this Id.");

            feedbackDTO.ID = id;

            var feedback = _mapper.Map<Feedback>(feedbackDTO)!;
            var feedbackUpdated = await _repository.Update(feedback);
            var feedbackUpdatedDTO = _mapper.Map<FeedbackDTO>(feedbackUpdated);

            return (feedbackUpdated != null) ? Ok(new { Message = "Feedback Updated.", Feedback = feedbackUpdatedDTO }) : BadRequest("Something went wrong...");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FeedbackDTO feedbackDTO)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDTO)!;
            var feedbackAdded = await _repository.Add(feedback);
            var feedbackAddedDTO = _mapper.Map<FeedbackDTO>(feedbackAdded)!;

            return (feedbackAdded != null) ? CreatedAtAction(nameof(GetById), new { id = feedbackAddedDTO.ID }, new { Message = "Feedback Added.", Feedback = feedbackAddedDTO }) : BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return (await _repository.Delete(id)) ? Ok("ok : feedback deleted") : BadRequest();
        }


    }
}
