using SocialBook.Data;
using SocialBook.Models;
using SocialBook.Repositories.Interfaces;

namespace SocialBook.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SocialBookContext _socialBookContext;
        private IProfileRepository? _profileRepository;
        private IPostRepository? _postRepository;
        private ICommentRepository? _commentRepository;
        private IReactionRepository? _reactionRepository;




        public IProfileRepository ProfileRepository
        {
            get
            {
                if (_profileRepository == null)
                {
                    _profileRepository = new ProfileRepository(_socialBookContext);
                }

                return _profileRepository;
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                if (_postRepository == null)
                {
                    _postRepository = new PostRepository(_socialBookContext);
                }

                return _postRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_socialBookContext);
                }

                return _commentRepository;
            }
        }

        public IReactionRepository ReactionRepository
        {
            get
            {
                if (_reactionRepository == null)
                {
                    _reactionRepository = new ReactionRepository(_socialBookContext);
                }

                return _reactionRepository;
            }
        }



        public RepositoryWrapper(SocialBookContext socialBookContext)
        {
            _socialBookContext = socialBookContext;
        }

        public void Save()
        {
            _socialBookContext.SaveChanges();
        }
    }
}



