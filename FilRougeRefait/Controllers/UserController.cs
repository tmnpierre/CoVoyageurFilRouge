using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.DTOs;
using CoVoyageur.API.Data;

namespace CoVoyageur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserDTO()
        {
            if (_context.UserDTO == null)
            {
                return NotFound();
            }
            return await _context.UserDTO.ToListAsync();
        }

        // GET: api/UserDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserDTO(int id)
        {
            if (_context.UserDTO == null)
            {
                return NotFound();
            }
            var userDTO = await _context.UserDTO.FindAsync(id);

            if (userDTO == null)
            {
                return NotFound();
            }

            return userDTO;
        }

        // PUT: api/UserDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDTO(int id, UserDTO userDTO)
        {
            if (id != userDTO.ID)
            {
                return BadRequest();
            }

            _context.Entry(userDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUserDTO(UserDTO userDTO)
        {
            if (_context.UserDTO == null)
            {
                return Problem("Entity set 'FilRougeRefaitContext.UserDTO'  is null.");
            }
            _context.UserDTO.Add(userDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDTO", new { id = userDTO.ID }, userDTO);
        }

        // DELETE: api/UserDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDTO(int id)
        {
            if (_context.UserDTO == null)
            {
                return NotFound();
            }
            var userDTO = await _context.UserDTO.FindAsync(id);
            if (userDTO == null)
            {
                return NotFound();
            }

            _context.UserDTO.Remove(userDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDTOExists(int id)
        {
            return (_context.UserDTO?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
