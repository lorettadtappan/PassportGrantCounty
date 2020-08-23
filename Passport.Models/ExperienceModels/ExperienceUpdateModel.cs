using Passport.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Passport.Models.ExperienceModels
{
    public class ExperienceUpdateModel
    {
        public int ExperienceId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Challenge Score Increase")]
        public Dictionary<string, string> ChallengeScoreIncrease { get; set; }
        public int RoadMapId { get; set; }
        public IEnumerable<SelectListItem> RoadMaps { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}