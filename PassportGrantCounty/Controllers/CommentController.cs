﻿using Microsoft.AspNet.Identity;
using Passport.Models.CommentModels;
using Passport.Services;
using System;
using System.Web.Http;
using System.Web.Mvc;

namespace PassportGrantCounty.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            var model = service.GetComments();
            return View(model);
        }
        // Add method here
        // GET
        public ActionResult Create()
        {
            return View();
        }
        // Add code here
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreateModel model)
        {
            if (ModelState.IsValid) return View(model);
            var service = CreateCommentService();
            if (service.CreateComment(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }
                ModelState.AddModelError("", "Note could not be created.");
                return View(model);
        }
        public ActionResult Details (int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentById(id);

            return View(model);
        }
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId);
            var service = new CommentService(userId);
            return service;
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
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
        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var note = commentService.GetCommentById(id);
            return Ok();
        }
        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();

            if (!service.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }
    }
}