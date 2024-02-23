using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.DTOs;
using CoVoyageur.API.Data;

namespace CoVoyageur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservationDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationDTO()
        {
          if (_context.ReservationDTO == null)
          {
              return NotFound();
          }
            return await _context.ReservationDTO.ToListAsync();
        }

        // GET: api/ReservationDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservationDTO(int id)
        {
          if (_context.ReservationDTO == null)
          {
              return NotFound();
          }
            var reservationDTO = await _context.ReservationDTO.FindAsync(id);

            if (reservationDTO == null)
            {
                return NotFound();
            }

            return reservationDTO;
        }

        // PUT: api/ReservationDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationDTO(int id, ReservationDTO reservationDTO)
        {
            if (id != reservationDTO.ID)
            {
                return BadRequest();
            }

            _context.Entry(reservationDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationDTOExists(id))
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

        // POST: api/ReservationDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> PostReservationDTO(ReservationDTO reservationDTO)
        {
          if (_context.ReservationDTO == null)
          {
              return Problem("Entity set 'FilRougeRefaitContext.ReservationDTO'  is null.");
          }
            _context.ReservationDTO.Add(reservationDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationDTO", new { id = reservationDTO.ID }, reservationDTO);
        }

        // DELETE: api/ReservationDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationDTO(int id)
        {
            if (_context.ReservationDTO == null)
            {
                return NotFound();
            }
            var reservationDTO = await _context.ReservationDTO.FindAsync(id);
            if (reservationDTO == null)
            {
                return NotFound();
            }

            _context.ReservationDTO.Remove(reservationDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationDTOExists(int id)
        {
            return (_context.ReservationDTO?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
