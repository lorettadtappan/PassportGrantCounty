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
    public bool Create(CommentCreateModel model)
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
    public IEnumerable<CommentListModel> GetCommentById()
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
}