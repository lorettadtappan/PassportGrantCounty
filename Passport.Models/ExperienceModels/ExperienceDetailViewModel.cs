using Passport.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Models.ExperienceModels
{
    public class ExperienceDetailViewModel
    {
        public int ExperienceId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Challenge Score Increase")]
        public Dictionary<string, string> ChallengeScoreIncrease { get; set; }
        public Dictionary<string, string> RoadMaps { get; set; }
        public Dictionary<string, string> Stamps { get; set; }
        public int RoadMapId { get; set; }
        public virtual ICollection<RoadMap> RoadMap { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}