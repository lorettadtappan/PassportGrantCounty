using Passport.Contracts;
using Passport.Data;
using Passport.Models;
using Passport.Data.Entities;
using Passport.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }
    }
    public bool CreateComment(CommentCreateModel model)
    {
        var entity =
            new Comment()
            {
                OwnerId = _userId,
                Title = model.Title,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };

        using (var ctx = new ApplicationDbContext())
        {
            ctx.Comments.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }
    public IEnumerable<CommentListModel> GetComments()
    {
        using (var ctx = new ApplicationDbContext())
        {
            var query =
                ctx
                    .Comments
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new CommentListModel
                            {
                                CommentId = e.CommentId,
                                Title = e.Title,
                                CreatedUtc = e.CreatedUtc
                            }
                    );

            return query.ToArray();
        }
    }
    public CommentDetailModel GetCommentById(int id)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Comments
                    .Single(e => e.CommentId == id && e.OwnerId == _userId);
            return
                new CommentDetail
                {
                    CommentId = entity.CommentId,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
        }
    }
    public bool UpdateCommentModel(CommentEdit model)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Comments
                    .Single(e => e.CommentId == model.CommentId && e.OwnerId == _userId);

            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return ctx.SaveChanges() == 1;
        }
    }
    public bool DeleteComment(int commentId)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Comments
                    .Single(e => e.CommentId == commentId && e.OwnerId == _userId);

            ctx.Comments.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}