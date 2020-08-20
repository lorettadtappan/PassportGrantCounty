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
        bool CreateRoadMapComment(CommentCreateModel model);
        bool CreateExperienceComment(CommentCreateModel model);
        bool CreateStampComment(CommentCreateModel model);
        bool Edit(CommentUpdateModel model);
        bool Delete(int CommentId);
        IEnumerable<CommentListModel> GetAllCommentsByRoadMapId(int roadMapId);
        IEnumerable<CommentListModel> GetAllCommentsByExperienceId(int experienceId);
        IEnumerable<CommentListModel> GetAllCommentsByStampId(int stampId);
        CommentListModel GetCommentById(int CommentId);
    }
}
