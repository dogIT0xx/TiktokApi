using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiktokApi.Entities;
using TiktokApi.Migrations;

namespace TiktokApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VideoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Video
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideos()
        {
            var videos = await _context.Videos.ToListAsync();
            return Ok(videos);
        }

        // GET: api/Video/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(Guid id)
        {
            var video = await _context.Videos.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // PUT: api/Video/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(Guid id, Video video)
        {
            if (id != video.Id)
            {
                return BadRequest();
            }

            _context.Entry(video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
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

        // POST: api/Video
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Video>> PostVideo(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideo", new { id = video.Id }, video);
        }

        // DELETE: api/Video/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(Guid id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoExists(Guid id)
        {
            return _context.Videos.Any(e => e.Id == id);
        }
    }
}
