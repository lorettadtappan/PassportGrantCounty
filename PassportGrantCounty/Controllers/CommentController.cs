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
        private CommentService CreateCommentService()
        {
            var userId = Guid.NewGuid();
            if (User.Identity.IsAuthenticated)
            {
                userId = Guid.Parse(User.Identity.GetUserId());
            }

            return new CommentService(userId);
        }
        [AllowAnonymous]
        public PartialViewResult GetCommentsByRoadMapId(int roadMapId)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetAllCommentsByRoadMapId(roadMapId);

            return PartialView("Index", model);
        }
        [AllowAnonymous]
        public PartialViewResult GetCommentsByExperienceId(int experienceId)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetAllCommentsByExperienceId(experienceId);

            return PartialView("Index", model);
        }
        [AllowAnonymous]
        public PartialViewResult GetCommentsByStampId(int stampId)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetAllCommentsByStampId(stampId);

            return PartialView("Index", model);
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult CreateExperienceComment(CommentCreateModel model, int experienceId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var commentService = CreateCommentService();
            if (commentService.CreateExperienceComment(model))
            {
                TempData["SaveResult"] = "Comment Added";
                return RedirectToAction("Details", "Experience", new { ExperienceId = experienceId });
            }
            ModelState.AddModelError("", "Unable to add comment");
            return View(model);
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult CreateRoadMapComment(CommentCreateModel model, int roadMapId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var commentService = CreateCommentService();
            if (commentService.CreateRoadMapComment(model))
            {
                TempData["SaveResult"] = "Comment Added";
                return RedirectToAction("Details", "RoadMap", new { RoadMapId = roadMapId });
            }
            ModelState.AddModelError("", "Unable to add comment");
            return View(model);
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult CreateStampComment(CommentCreateModel model, int stampId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var commentService = CreateCommentService();
            if (commentService.CreateStampComment(model))
            {
                TempData["SaveResult"] = "Comment Added";
                return RedirectToAction("Details", "Stamp", new { StampId = stampId });
            }
            ModelState.AddModelError("", "Unable to add comment");
            return View(model);
        }

        // POST: Comment/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int commentId)
        {
            var commentService = CreateCommentService();
            commentService.Delete(commentId);
            TempData["SaveResult"] = "Comment Deleted!";
            return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: Comment/Edit/{id}
        [HttpPost]
        public ActionResult Edit(CommentUpdateModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var commentService = CreateCommentService();
            if (commentService.Edit(model))
            {
                TempData["SaveResult"] = "Comment Updated!";
                return Redirect(Request.UrlReferrer.ToString());
            }
            ModelState.AddModelError("", "Comment was not updated");
            return View(model);
        }
    }
}