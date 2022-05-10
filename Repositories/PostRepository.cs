using SocialBook.Repositories;
using SocialBook.Data;
using SocialBook.Models;
using SocialBook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace SocialBook.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(SocialBookContext postContext)
               : base(postContext)
        {
        }

        public async Task<Post?> GetById(int id)
        {
            var post = await context.Post
                .FirstOrDefaultAsync(m => m.Id == id);

            if (post == null)
            {
                return null;
            }

            var comments = await context.Comment
                .Include(s => s.CreatedBy)
                .Where(s => s.Post == post)
                .ToListAsync();

            var reactios = await context.Reaction
                .Include(s => s.CreatedBy)
                .Where(s => s.Post == post)
                .ToListAsync();
            
            post.Comments = comments;
            post.Reactions = reactios;

            return post;
        }

        public async void Add(Post post)
        {
            context.Add(post);
            await context.SaveChangesAsync();
        }
        
        public async void Modify(Post post)
        {
            context.Update(post);
            await context.SaveChangesAsync();
        }
        
        public bool Exists(int id)
        {
            return context.Post.Any(e => e.Id == id);
        }

        public async void Delete(Post post)
        {
            context.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetList()
        {
            return await context.Post.ToListAsync();
        }
    }
    
}