
using Microsoft.EntityFrameworkCore;
using TiktokApi.Migrations;

namespace TiktokApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
       
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsExits(string id)
        {
            var result = await _context.Users.SingleAsync(user => user.Id == id);
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
