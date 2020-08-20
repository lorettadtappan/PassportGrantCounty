using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Models.CommentModels
{
    public class CommentListModel
    {
        public int CommentId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime? LastUpdated { get; set; }
        public int RepliesCount { get; set; }
    }
}
