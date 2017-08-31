using SwirlFeed.Models;

namespace SwirlFeed.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        public IUserRepository UserRepository { get; }
        public IFriendRepository FriendRepository { get; }
        public IPostRepository PostRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            FriendRepository = new FriendRepository(_context);
            PostRepository = new PostRepository(_context);
        }

        public int Complete() => _context.SaveChanges();
    }
}