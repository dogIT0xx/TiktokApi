using Microsoft.AspNetCore.Mvc;
using TiktokApi.DTOs.Request;

namespace TiktokApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController() { }

        [HttpPost("register")]
        public ActionResult Register(RegisterRequest request)
        {
            return null;
        }

        [HttpPost("send-code")]
        public ActionResult SendCode(SendCodeRequest request)
        {
            return null;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginRequest request)
        {
            return null;
        }

        // GET: api/<UserController>
        [HttpGet("{id}")]
        public ActionResult GetUserById(string id)
        {
            return null;
        }

        [HttpPost("refresh-token")]
        public ActionResult RefreshToken()
        {
            return null;
        }

        [HttpPost("change-password")]
        public ActionResult ChangePassword(ChangePasswordRequest request)
        {
            return null;
        }

        [HttpPost("forgot-password")]
        public ActionResult ForgotPassword(ForgotPasswordRequest request)
        {
            return null;
        }

        [HttpPost("reset-password")]
        public ActionResult ResetPassword(ResetPasswordRequest request)
        {
            return null;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateInfo(UpdateInfoUserRequest request)
        {
            return null;
        }
    }
}
