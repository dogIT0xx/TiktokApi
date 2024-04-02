using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiktokApi.DTOs.Request;
using TiktokApi.Entities;
using TiktokApi.Migrations;
using TiktokApi.Repositories;

namespace TiktokApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IVideoRepository _videoRepository;
        private readonly Cloudinary _cloudinary;

        public VideoController(ApplicationDbContext context, IVideoRepository videoRepository, Cloudinary cloudinary)
        {
            _context = context;
            _videoRepository = videoRepository;
            _cloudinary = cloudinary;
        }

        // GET: api/videos?search=""&authorId=""&pageIndex=""&pageSize=""
        [HttpGet]
        public async Task<ActionResult<Video>> GetVideos(GetVideosRequest getVideosRequest)
        {
            var videos = await _videoRepository.GetVideos(
                getVideosRequest.Search, 
                getVideosRequest.AuthorId, 
                getVideosRequest.PageIndex, 
                getVideosRequest.PageIndex);
            return (videos == null) ? NotFound() : Ok(videos);
        }

        // GET: api/Video/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideoById(string id)
        {
            var video = await _videoRepository.GetVideoById(id);
            return (video == null) ? NotFound() : Ok(video);
        }

        // POST: api/Video
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Video>> PostVideo(UploadVideoRequest uploadVideoDto)
        {
            // Handel upload video to scloud
            var video = uploadVideoDto.VideoSrc;
            var videoId = Guid.NewGuid();
            var stream = video.OpenReadStream();
            var extension = Path.GetExtension(video.FileName);
            var uploadParams = new CloudinaryDotNet.Actions.VideoUploadParams()
            {
                File = new FileDescription($"{videoId}{extension}", stream)
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            var videoEntity = new Video()
            {
                Id = videoId.ToString(),
                AuthorId = uploadVideoDto.AuthorId,
                Src = uploadResult.Url.ToString(),
                Duration = Convert.ToInt32(uploadResult.Duration),
                Title = uploadVideoDto.Title,
                SoundTrack = ""
            };

            var result =  await _videoRepository.UploadVideo(videoEntity);
            return (result < 0) ? BadRequest() : Ok();       
        }

        // PUT: api/Video/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(Video video)
        {
            var result = await _videoRepository.EditVideo(video);
            return (result < 0) ? NotFound() : NoContent();
        }

        // DELETE: api/Video/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(string id)
        {
            var result = await _videoRepository.DeleteVideoById(id);            
            return (result < 0) ? NotFound() : NoContent();
        }
    }
}
