using System;
using System.ComponentModel.DataAnnotations;

namespace Passport.Data.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Your Note")]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}