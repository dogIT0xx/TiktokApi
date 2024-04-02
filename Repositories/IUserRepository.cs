using TiktokApi.Entities;

namespace TiktokApi.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> IsExits(string id);
    }
}
