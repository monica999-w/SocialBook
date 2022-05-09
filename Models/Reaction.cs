namespace SocialBook.Models
{
    public class Reaction:BaseEntity
    {

        public int Id { get; set; }
        public Profile? CreatedBy { get; set; }
        public Post ?Post { get; set; }
        public ReactionType Type { get; set; }
        public ReactionStatus Status { get; set; }
    }
}
