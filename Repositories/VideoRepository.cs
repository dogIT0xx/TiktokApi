using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Versioning;
using TiktokApi.Entities;
using TiktokApi.Migrations;

namespace TiktokApi.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly ApplicationDbContext _context;

        public VideoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteVideoById(string id)
        {
            var video = await _context.Videos.FindAsync(id);
            if ( video == null)
            {
                return -1;
            }
            _context.Videos.Remove(video);
            return await _context.SaveChangesAsync(); ;
        }

        public async Task<int> EditVideo(Video video)
        {
            _context.Entry(video).State = EntityState.Modified;
            return await _context.SaveChangesAsync(); ;
        }

        public async Task<Video> GetVideoById(string id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public async Task<List<Video>> GetVideos(string searchString="", string authorId="", int pageIndex = 1, int pageSize = 15)
        {
            var queryable = _context.Videos.AsNoTracking();
            if (!searchString.IsNullOrEmpty())
            {
                queryable = queryable.Where(video => video.Title.Contains(searchString));
            }
            if (!authorId.IsNullOrEmpty())
            {
                queryable = queryable.Where(video => video.AuthorId == authorId);
            }
            var result = await queryable
                .Skip((pageIndex - 1) * pageSize)
                .Take(15)
                .ToListAsync();
            return result;
        }

        public async Task<int> UploadVideo(Video video)
        {
            var result = _context.Videos.Add(video);
            return await _context.SaveChangesAsync();
        }
    }
}
