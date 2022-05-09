using SocialBook.Repositories;
using SocialBook.Data;
using SocialBook.Models;
using SocialBook.Repositories.Interfaces;

namespace SocialBook.Repositories
{
    public class CommentRepository: RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(SocialBookContext commentContext)
               : base(commentContext)
        {
        }

        public async Task<Comment?> GetById(int id) => await context.Comment.FindAsync(id);
        
        public async void Save(Comment comment)
        {
            comment.Status = CommentStatus.Active;

            context.Add(comment);
            await context.SaveChangesAsync();
        }

        public async void Update(Comment comment)
        {
            comment.ModifiedAt = new DateTime();

            context.Update(comment);
            await context.SaveChangesAsync();
        }

        public async void Remove(Comment comment)
        {
            context.Remove(comment);
            await context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return context.Comment.Any(e => e.Id == id);
        }

        public List<Comment> GetList()
        {
            return context.Comment.ToList();
        }
    }
}
