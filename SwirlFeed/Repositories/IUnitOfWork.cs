namespace SwirlFeed.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IFriendRepository FriendRepository { get; }
        IPostRepository PostRepository { get; }

        int Complete();
    }
}