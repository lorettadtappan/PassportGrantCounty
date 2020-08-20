using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Models.CommentModels
{
    public class CommentCreateModel
    {
        public string Content { get; set; }
        public int ParentId { get; set; }
    }
}
