using Passport.Contracts;
using Passport.Data;
using Passport.Data.Entities;
using Passport.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
            _ctx = new ApplicationDbContext();
        }
        public bool CreateRoadMapComment(CommentCreateModel model)
        {
            var entity = new Comment()
            {
                OwnerId = _userId,
                Content = model.Content,
                DateCreated = DateTime.Now,
                RoadMapId = model.ParentId
            };
            _ctx.Comments.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool CreateExperienceComment(CommentCreateModel model)
        {
            var entity = new Comment()
            {
                OwnerId = _userId,
                Content = model.Content,
                DateCreated = DateTime.Now,
                ExperienceId = model.ParentId
            };
            _ctx.Comments.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool CreateStampComment(CommentCreateModel model)
        {
            var entity = new Comment()
            {
                OwnerId = _userId,
                Content = model.Content,
                DateCreated = DateTime.Now,
                StampId = model.ParentId
            };
            _ctx.Comments.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int commentId)
        {
            var entity = _ctx.Comments.Single(e => e.CommentId == commentId);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(CommentUpdateModel model)
        {
            var entity = _ctx.Comments.Single(e => e.CommentId == model.CommentId);
            if (entity != null)
            {
                entity.Content = model.Content;
                entity.LastUpdated = DateTime.Now;
            }
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<CommentListModel> GetAllCommentsByRoadMapId(int roadMapId)
        {
            var commentList = _ctx.Comments
                .Where(e => e.RoadMapId == roadMapId && e.IsDeleted == false)
                .Select(e => new CommentListModel
                {
                    CommentId = e.CommentId,
                    Author = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName,
                    Content = e.Content,
                    DateCreated = e.DateCreated,
                    LastUpdated = e.LastUpdated,
                    RepliesCount = e.Replies.Where(reply => reply.IsDeleted == false).Count()
                }).ToList();
            return commentList;
        }

        public IEnumerable<CommentListModel> GetAllCommentsByExperienceId(int experienceId)
        {
            var commentList = _ctx.Comments
                .Where(e => e.ExperienceId == experienceId && e.IsDeleted == false)
                .Select(e => new CommentListModel
                {
                    CommentId = e.CommentId,
                    Author = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName,
                    Content = e.Content,
                    DateCreated = e.DateCreated,
                    LastUpdated = e.LastUpdated,
                    RepliesCount = e.Replies.Where(reply => reply.IsDeleted == false).Count()
                }).ToList();
            return commentList;
        }

        public IEnumerable<CommentListModel> GetAllCommentsByStampId(int stampId)
        {
            var commentList = _ctx.Comments
                .Where(e => e.StampId == stampId && e.IsDeleted == false)
                .Select(e => new CommentListModel
                {
                    CommentId = e.CommentId,
                    Author = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName,
                    Content = e.Content,
                    DateCreated = e.DateCreated,
                    LastUpdated = e.LastUpdated,
                    RepliesCount = e.Replies.Where(reply => reply.IsDeleted == false).Count()
                }).ToList();
            return commentList;
        }

        public CommentListModel GetCommentById(int commentId)
        {
            var entity = _ctx.Comments.Single(e => e.CommentId == commentId);
            var model = new CommentListModel
            {
                Author = _ctx.Users.FirstOrDefault(u => u.Id == entity.OwnerId.ToString()).UserName,
                Content = entity.Content,
                DateCreated = entity.DateCreated,
                LastUpdated = entity.LastUpdated,
                CommentId = entity.CommentId,
                RepliesCount = entity.Replies.Where(reply => reply.IsDeleted == false).Count()
            };
            return model;
        }
    }
}