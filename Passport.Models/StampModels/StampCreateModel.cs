using Passport.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Models.StampModels
{
    public class StampCreateModel
    {
        public string Name { get; set; }
        [Display(Name = "Stamp Level")]
        public int StampLevel { get; set; }
        public RoadMap RoadMaps { get; set; }
    }
}
