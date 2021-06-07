using Passport.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Contracts
{
    public interface ICommentService
    {
        bool Edit(CommentUpdateModel model);
        bool Delete(int CommentId);
        CommentListModel GetCommentById(int CommentId);
    }
}
