using Passport.Data;
using Passport.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Passport.Models.ExperienceModels;

namespace PassportGrantCounty.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        private readonly ExperienceService _experienceService;
        private readonly ApplicationDbContext _ctx;
        public ExperienceController()
        {
            _experienceService = new ExperienceService();
            _ctx = new ApplicationDbContext();
        }
        // GET: Experience
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

            var model = _experienceService.GetAllExperiences();
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
        // GET: Experience/Details/{id}
        public ActionResult Details(int experienceId)
        {
            var model = _experienceService.GetExperienceDetailViewById(experienceId);
            return View(model);
        }
        // POST: Experience/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int experienceId)
        {
            _experienceService.Delete(experienceId);
            TempData["SaveResult"] = "Experience deleted";
            return RedirectToAction("Index");
        }
        // GET: Experience/Create
        public ActionResult Create()
        {
            var roadMaps = _ctx.RoadMaps.ToList();
            var dropdownList = new SelectList(roadMaps.Select(e => new SelectListItem
            {
                Value = e.RoadMapId.ToString(),
                Text = e.Name
            }).ToList(), "Value", "Text");
            var model = new ExperienceCreateModel
            {
                RoadMaps = dropdownList
            };
            return View(model);
        }
        // POST: Experience/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExperienceCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (_experienceService.Create(model))
            {
                TempData["SaveResult"] = "Experience created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to create experience");
            return View(model);
        }
        // GET: Experience/Edit/{id}
        public ActionResult Edit(int experienceId)
        {
            var detail = _experienceService.GetExperienceDetailById(experienceId);
            var model = new ExperienceUpdateModel
            {
                ExperienceId = detail.ExperienceId,
                Name = detail.Name,
                ChallengeScoreIncrease = detail.ChallengeScoreIncrease,
            };
            return View(model);
        }
        // POST: Experience/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExperienceUpdateModel model, int experienceId)
        {
            model.RoadMaps = new SelectList(_ctx.RoadMaps, "Id", "Name");
            if (model.ExperienceId != experienceId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (_experienceService.Edit(model))
            {
                TempData["SaveResult"] = "Experience updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to update experience");
            return View(model);
        }
    }
}