using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.DTOs;
using CoVoyageur.API.Data;

namespace CoVoyageur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RideController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RideDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RideDTO>>> GetRideDTO()
        {
          if (_context.RideDTO == null)
          {
              return NotFound();
          }
            return await _context.RideDTO.ToListAsync();
        }

        // GET: api/RideDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RideDTO>> GetRideDTO(int id)
        {
          if (_context.RideDTO == null)
          {
              return NotFound();
          }
            var rideDTO = await _context.RideDTO.FindAsync(id);

            if (rideDTO == null)
            {
                return NotFound();
            }

            return rideDTO;
        }

        // PUT: api/RideDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRideDTO(int id, RideDTO rideDTO)
        {
            if (id != rideDTO.ID)
            {
                return BadRequest();
            }

            _context.Entry(rideDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RideDTOExists(id))
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

        // POST: api/RideDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RideDTO>> PostRideDTO(RideDTO rideDTO)
        {
          if (_context.RideDTO == null)
          {
              return Problem("Entity set 'FilRougeRefaitContext.RideDTO'  is null.");
          }
            _context.RideDTO.Add(rideDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRideDTO", new { id = rideDTO.ID }, rideDTO);
        }

        // DELETE: api/RideDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRideDTO(int id)
        {
            if (_context.RideDTO == null)
            {
                return NotFound();
            }
            var rideDTO = await _context.RideDTO.FindAsync(id);
            if (rideDTO == null)
            {
                return NotFound();
            }

            _context.RideDTO.Remove(rideDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RideDTOExists(int id)
        {
            return (_context.RideDTO?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
