using System.Collections.Generic;
using SwirlFeed.Models;

namespace SwirlFeed.Repositories
{
    public interface IFriendRepository : IRepository<Friend>
    {
        List<Friend> GetAllWithRelatedData(string userId);
        List<Post> GetFriendsPosts(string userId, List<Friend> friends);
    }
}
