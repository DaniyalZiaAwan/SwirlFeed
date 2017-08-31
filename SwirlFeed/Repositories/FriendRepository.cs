using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SwirlFeed.Models;

namespace SwirlFeed.Repositories
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        public FriendRepository(DbContext context) : base(context)
        {
        }

        public List<Friend> GetAllWithRelatedData(string userId)
        {
            return DbContext.Friends.Include(f => f.User1)
                                    .Include(f => f.User1.Posts)
                                    .Include(f => f.User2)
                                    .Include(f => f.User2.Posts)
                                    .Where(f => f.User1Id == userId || f.User2Id == userId)
                                    .ToList();
        }

        public List<Post> GetFriendsPosts(string userId, List<Friend> friends)
        {
            var posts = new List<Post>();
            foreach (var friend in friends)
                posts = friend.AddPostsToUser(userId);

            return posts;
        }

        internal ApplicationDbContext DbContext => Context as ApplicationDbContext;
    }
}