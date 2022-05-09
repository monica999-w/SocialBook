namespace SocialBook.Models
{
    public class Comment: BaseEntity
    {
        public int Id { get; set; }
        public Post? Post { get; set; }
        public Profile? CreatedBy { get; set; }
        public string? Content { get; set; }
        public Comment? ParentComment { get; set; }
        public virtual ICollection<Comment> ?SubComments { get; set; }

        public CommentStatus Status { get; set; }
    }
}
