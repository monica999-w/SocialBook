namespace SocialBook.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IProfileRepository ProfileRepository { get; }
        IPostRepository PostRepository { get; }
        ICommentRepository CommentRepository { get; }
        IReactionRepository ReactionRepository { get; }

        void Save();
    }
}
