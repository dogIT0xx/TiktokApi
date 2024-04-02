namespace TiktokApi.DTOs.Request
{
    public class GetVideosRequest
    {
        public string Search { get; set; }
        public string AuthorId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
