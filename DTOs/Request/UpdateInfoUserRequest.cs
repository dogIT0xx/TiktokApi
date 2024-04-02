namespace TiktokApi.DTOs.Request
{
    public class UpdateInfoUserRequest
    {
        public string TiktokId { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
