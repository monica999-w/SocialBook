using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialBook.Models
{
    public class Post:BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Image Name")]
        public string? ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }

        public string? Content { get; set; }
        public Profile? CreatedBy { get; set; }
        public PostStatus Status { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Reaction>? Reactions { get; set; }

    }
}
