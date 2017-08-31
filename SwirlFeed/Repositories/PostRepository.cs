using System.Data.Entity;
using SwirlFeed.Models;

namespace SwirlFeed.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context) { }
    }
}