namespace SocialBook.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string? LastName { get; set; }
        public string? FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }


        public ICollection<Post>? Posts { get; set; }
    }
}
