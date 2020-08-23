using PagedList;
using Passport.Models.RoadMapModels;
using Passport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassportGrantCounty.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoadMapController : Controller
    {
        private readonly RoadMapService _roadMapService;
        public RoadMapController()
        {
            _roadMapService = new RoadMapService();
        }
        // GET: RoadMap
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

            var model = _roadMapService.GetAllRoadMaps();
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
        // GET: RoadMap/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: RoadMap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoadMapCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (_roadMapService.Create(model))
            {
                TempData["SaveResult"] = "Road Map Created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to create road map");
            return View(model);
        }
        // GET: RoadMap/Details/{id}
        public ActionResult Details(int roadMapId)
        {
            var model = _roadMapService.GetRoadMapDetailViewById(roadMapId);

            return View(model);
        }
        // POST: RoadMap/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int roadMapId)
        {
            _roadMapService.Delete(roadMapId);
            TempData["SaveResult"] = "RoadMap deleted";
            return RedirectToAction("Index");
        }
        // GET: RoadMap/Edit/{id}
        public ActionResult Edit(int roadMapId)
        {
            var details = _roadMapService.GetRoadMapDetailById(roadMapId);
            var model = new RoadMapUpdateModel
            {
                RoadMapId = details.RoadMapId,
                Name = details.Name,
                Speed = details.Speed,
                IsActive = details.IsActive,
                ChallengeScoreIncrease = details.ChallengeScoreIncrease,
                ExperienceId = details.ExperienceId,
            };
            return View(model);
        }
        // POST: RoadMap/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoadMapUpdateModel model, int roadMapId)
        {
            if (model.RoadMapId != roadMapId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (_roadMapService.Edit(model))
            {
                TempData["SaveResult"] = "RoadMap edited";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to edit roadMap");
            return View(model);
        }
    }
}