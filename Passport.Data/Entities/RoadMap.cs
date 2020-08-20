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
    public class RoadMap
    {
        [Key]
        public int RoadMapId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Speed { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        internal string _ChallengeScoreIncrease { get; set; }
        [NotMapped]
        public Dictionary<string, string> ChallengeScoreIncrease
        {
            get { return _ChallengeScoreIncrease == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_ChallengeScoreIncrease); }
            set { _ChallengeScoreIncrease = JsonConvert.SerializeObject(value); }
        }
        internal string _Experiences { get; set; }
        [NotMapped]
        public Dictionary<string, string> Experiences
        {
            get { return _Experiences == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_Experiences); }
            set { _Experiences = JsonConvert.SerializeObject(value); }
        }
        internal string _Stamps { get; set; }
        [NotMapped]
        public Dictionary<string, string> Stamps
        {
            get { return _Stamps == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_Stamps); }
            set { _Stamps = JsonConvert.SerializeObject(value); }
        }
        [Required]
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}