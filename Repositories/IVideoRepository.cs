using TiktokApi.Entities;

namespace TiktokApi.Repositories
{
    public interface IVideoRepository
    {
        public Task<List<Video>> GetVideos(string searchString="", string authorId="", int pageIndex=1, int pageSize=20);
        public Task<Video> GetVideoById(string id);
        public Task<int> UploadVideo(Video video);
        public Task<int> DeleteVideoById(string id);
        public Task<int> EditVideo(Video video);
    }
}
