using Microsoft.AspNet.Identity;
using Passport.Models.CommentModels;
using Passport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassportGrantCounty.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        public IHttpActionResult Get()
        {
            Service commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);
        }
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
    }
}