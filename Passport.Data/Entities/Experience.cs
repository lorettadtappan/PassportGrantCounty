﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Data.Entities
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        internal string _ChallengeScoreIncrease { get; set; }
        [NotMapped]
        public Dictionary<string, string> ChallengeScoreIncrease
        {
            get { return _ChallengeScoreIncrease == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_ChallengeScoreIncrease); }
            set { _ChallengeScoreIncrease = JsonConvert.SerializeObject(value); }
        }
        [Required]
        [ForeignKey("RoadMap")]
        public int RoadMapId { get; set; }
        public virtual RoadMap RoadMaps { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
