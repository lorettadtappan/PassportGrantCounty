using Passport.Models.ReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Contracts
{
    public interface IReplyService
    {
        bool Create(ReplyCreateModel model);
        bool Edit(ReplyUpdateModel model);
        bool Delete(int replyId);
        IEnumerable<ReplyListModel> GetAllRepliesByCommentId(int commentId);
        ReplyListModel GetReplyById(int replyId);
    }
}