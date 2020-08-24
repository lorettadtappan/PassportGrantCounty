﻿using PagedList;
using Passport.Models.BackgroundModels;
using Passport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassportGrantCounty.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BackgroundController : Controller
    {
        private readonly BackgroundService _backgroundService;
        public BackgroundController()
        {
            _backgroundService = new BackgroundService();
        }
        [AllowAnonymous]
        // GET: Background
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Name = String.IsNullOrEmpty(sortOrder) ? "nameDescending" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var model = _backgroundService.GetAllBackgrounds();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(e => e.Name.ToLower().Contains(searchString.ToLower()));
            }
            switch (sortOrder)
            {
                case "nameDescending":
                    model = model.OrderByDescending(m => m.Name);
                    break;
                default: // Name ascending
                    model = model.OrderBy(m => m.Name);
                    break;
            }

            int pageSize = 25;
            int pageNumber = (page ?? 1);

            return View(model.ToPagedList(pageNumber, pageSize));
        }
        // GET: Background/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Background/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BackgroundCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (_backgroundService.Create(model))
            {
                TempData["SaveResult"] = "Background Created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "There was an error creating the background");
            return View(model);
        }
        // GET: Background/Edit/{id}
        public ActionResult Edit(int backgroundId)
        {
            var background = _backgroundService.GetBackgroundById(backgroundId);
            var model = new BackgroundUpdateModel()
            {
                BackgroundId = background.BackgroundId,
                Name = background.Name,
                AdventureLog = background.AdventureLog
            };
            return View(model);
        }
        // POST: Background/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BackgroundUpdateModel model, int backgroundId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.BackgroundId != backgroundId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (_backgroundService.Edit(model))
            {
                TempData["SaveResult"] = "Background Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "There was an error updating the background");
            return View(model);
        }
        // POST: Background/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int backgroundId)
        {
            _backgroundService.Delete(backgroundId);
            TempData["SaveResult"] = "Background Deleted";
            return RedirectToAction("Index");
        }

        // GET: Background/Details/{id}
        public ActionResult Details(int backgroundId)
        {
            var model = _backgroundService.GetBackgroundById(backgroundId);
            return View(model);
        }
    }
}