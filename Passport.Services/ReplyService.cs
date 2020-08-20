using Passport.Contracts;
using Passport.Data;
using Passport.Data.Entities;
using Passport.Models.ReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Services
{
    public class ReplyService : IReplyService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _ctx = new ApplicationDbContext();
            _userId = userId;
        }
        public bool Create(ReplyCreateModel model)
        {
            var entity = new Reply()
            {
                OwnerId = _userId,
                Content = model.Content,
                DateCreated = DateTime.Now,
                CommentId = model.CommentId,
            };
            _ctx.Replies.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int replyId)
        {
            var entity = _ctx.Replies
                .Where(e => e.OwnerId == _userId)
                .Single(e => e.ReplyId == replyId);
            if (entity != null)
            {
                entity.IsDeleted = true;
            };
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(ReplyUpdateModel model)
        {
            var entity = _ctx.Replies
                .Where(e => e.OwnerId == _userId)
                .Single(e => e.ReplyId == model.ReplyId);
            if (entity != null)
            {
                entity.Content = model.Content;
                entity.LastUpdated = DateTime.Now;
            };
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<ReplyListModel> GetAllRepliesByCommentId(int commentId)
        {
            var repliesList = _ctx.Replies
                .Where(e => e.CommentId == commentId && e.IsDeleted == false)
                .Select(e => new ReplyListModel
                {
                    ReplyId = e.ReplyId,
                    Author = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName,
                    Content = e.Content,
                    DateCreated = e.DateCreated,
                    LastUpdated = e.LastUpdated
                }).ToList();
            return repliesList;
        }

        public ReplyListModel GetReplyById(int replyId)
        {
            var entity = _ctx.Replies.Single(e => e.ReplyId == replyId);
            var model = new ReplyListModel
            {
                ReplyId = entity.ReplyId,
                Author = _ctx.Users.FirstOrDefault(u => u.Id == entity.OwnerId.ToString()).UserName,
                Content = entity.Content,
                DateCreated = entity.DateCreated,
                LastUpdated = entity.LastUpdated
            };
            return model;
        }
    }
}