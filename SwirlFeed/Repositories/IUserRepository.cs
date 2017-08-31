using SwirlFeed.Models;

namespace SwirlFeed.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetWithRelatedData(string userId);
    }
}
