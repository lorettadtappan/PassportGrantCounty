using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Data.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        [ForeignKey("RoadMap")]
        public int? RoadMapId { get; set; }
        public virtual RoadMap RoadMap { get; set; }
        [ForeignKey("Experience")]
        public int? ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
        [ForeignKey("Stamp")]
        public int? StampId { get; set; }
        public virtual Stamp Stamp { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public bool IsDeleted { get; set; }
    }
}