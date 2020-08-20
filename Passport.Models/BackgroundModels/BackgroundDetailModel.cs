using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Models.BackgroundModels
{
    public class BackgroundDetailModel
    {
        public int BackgroundId { get; set; }
        public string Name { get; set; }
        [Display(Name = "AdventureLog")]
        public Dictionary<string, string> AdventureLog { get; set; }
    }
}