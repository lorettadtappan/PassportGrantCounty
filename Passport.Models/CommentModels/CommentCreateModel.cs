using System.ComponentModel.DataAnnotations;


namespace Passport.Models.CommentModels
{
    public class CommentCreateModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 6 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }
        [MaxLength(8000)]
        public string Content { get; set; }
    }
}
