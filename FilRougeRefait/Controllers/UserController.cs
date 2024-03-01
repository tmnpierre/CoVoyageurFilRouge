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
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserController(IRepository<User> repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<User> users = await _repository.GetAll();
            IEnumerable<UserDTO> usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users)!;
            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetById(id);
            if (user == null)
                return NotFound(new { Message = "There is no User with this Id." });

            UserDTO userDTO = _mapper.Map<UserDTO>(user)!;
            return Ok(new { Message = "User found.", User = userDTO });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UserDTO userDTO)
        {
            var userFromDb = await _repository.GetById(id);
            if (userFromDb == null)
                return NotFound("There is no User with this Id.");

            userDTO.ID = id;

            var user = _mapper.Map<User>(userDTO)!;
            var userUpdated = await _repository.Update(user);
            var userUpdatedDTO = _mapper.Map<UserDTO>(userUpdated);

            return (userUpdated != null) ? Ok(new { Message = "User Updated.", User = userUpdatedDTO }) : BadRequest("Something went wrong...");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO)!;
            var userAdded = await _repository.Add(user);
            var userAddedDTO = _mapper.Map<UserDTO>(userAdded)!;

            return (userAdded != null) ? CreatedAtAction(nameof(GetById), new { id = userAddedDTO.ID }, new { Message = "User Added.", User = userAddedDTO }) : BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return (await _repository.Delete(id)) ? Ok("ok : user deleted") : BadRequest();
        }


    }
}