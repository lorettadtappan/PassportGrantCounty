using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Models.StampModels
{
    public class StampListModel
    {
        public int StampId { get; set; }
        public string Explorer { get; set; }
        public string Name { get; set; }
        [Display(Name = "Stamp Level")]
        public int StampLevel { get; set; }
    }
}
