using Passport.Models.CommentModels;

namespace Passport.Contracts
{
    public interface ICommentService
    {
        bool Edit(CommentUpdateModel model);
        bool Delete(int CommentId);
        CommentListModel GetCommentById(int CommentId);
    }
}
