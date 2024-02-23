using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.DTOs;
using CoVoyageur.API.Data;

namespace CoVoyageur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FeedbackDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDTO>>> GetFeedbackDTO()
        {
          if (_context.FeedbackDTO == null)
          {
              return NotFound();
          }
            return await _context.FeedbackDTO.ToListAsync();
        }

        // GET: api/FeedbackDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDTO>> GetFeedbackDTO(int id)
        {
          if (_context.FeedbackDTO == null)
          {
              return NotFound();
          }
            var feedbackDTO = await _context.FeedbackDTO.FindAsync(id);

            if (feedbackDTO == null)
            {
                return NotFound();
            }

            return feedbackDTO;
        }

        // PUT: api/FeedbackDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbackDTO(int id, FeedbackDTO feedbackDTO)
        {
            if (id != feedbackDTO.ID)
            {
                return BadRequest();
            }

            _context.Entry(feedbackDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackDTOExists(id))
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

        // POST: api/FeedbackDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedbackDTO>> PostFeedbackDTO(FeedbackDTO feedbackDTO)
        {
          if (_context.FeedbackDTO == null)
          {
              return Problem("Entity set 'FilRougeRefaitContext.FeedbackDTO'  is null.");
          }
            _context.FeedbackDTO.Add(feedbackDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedbackDTO", new { id = feedbackDTO.ID }, feedbackDTO);
        }

        // DELETE: api/FeedbackDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackDTO(int id)
        {
            if (_context.FeedbackDTO == null)
            {
                return NotFound();
            }
            var feedbackDTO = await _context.FeedbackDTO.FindAsync(id);
            if (feedbackDTO == null)
            {
                return NotFound();
            }

            _context.FeedbackDTO.Remove(feedbackDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbackDTOExists(int id)
        {
            return (_context.FeedbackDTO?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
