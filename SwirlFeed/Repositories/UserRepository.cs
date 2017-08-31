using System.Data.Entity;
using System.Linq;
using SwirlFeed.Models;

namespace SwirlFeed.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext DbContext => Context as ApplicationDbContext;

        public ApplicationUser GetWithRelatedData(string userId)
        {
            return DbContext.Users.Include(u => u.Posts)
                                   .Include(u => u.Posts.Select(p => p.Posted_By))
                                   .Include(u => u.Posts.Select(p => p.User_To))
                                   .SingleOrDefault(u => u.Id == userId);
        }
    }
}