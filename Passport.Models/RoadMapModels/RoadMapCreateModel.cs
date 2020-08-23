using Passport.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Passport.Models.RoadMapModels
{
    public class RoadMapCreateModel
    {
        public string Name { get; set; }
        public string Speed { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Challenge Score Increase")]
        public Dictionary<string, string> ChallengeScoreIncrease { get; set; }

        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }
        public IEnumerable<SelectListItem> Experiences { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}