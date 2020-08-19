using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Data.Entities
{
    public class Background
    {
        [Key]
        public int BackgroundId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        internal string _AdventureLog { get; set; }
        [NotMapped]
        public Dictionary<string, string> AdventureLog
        {
            get { return _AdventureLog == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_AdventureLog); }
            set { _AdventureLog = JsonConvert.SerializeObject(value); }
        }
    }
}