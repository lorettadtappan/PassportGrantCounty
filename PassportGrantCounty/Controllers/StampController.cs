using PagedList;
using Passport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassportGrantCounty.Controllers
{
    public class StampController : Controller
    {
        private readonly StampService _stampService;
        public StampController()
        {
            _stampService = new StampService();
        }
        // GET: Stamp
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CreatorSortParam = sortOrder == "Explorer" ? "explorerDescending" : "Explorer";
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "nameDescending" : "";
            ViewBag.StampLevelSortParam = sortOrder == "StampLevel" ? "stampLevelDescending" : "StampLevel";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var model = _stampService.GetAllStamps();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(e => e.Name.ToLower().Contains(searchString.ToLower()) || e.Explorer.ToLower().Contains(searchString.ToLower()));
            }
            switch (sortOrder)
            {
                case "Explorer":
                    model = model.OrderBy(m => m.Explorer);
                    break;
                case "explorerDescending":
                    model = model.OrderByDescending(m => m.Explorer);
                    break;
                case "StampLevel":
                    model = model.OrderBy(m => m.StampLevel);
                    break;
                case "stampLevelDescending":
                    model = model.OrderByDescending(m => m.StampLevel);
                    break;
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
        // GET: Stamp/Details/{id}
        public ActionResult Details(int stampId)
        {
            var model = _stampService.GetStampDetailViewById(stampId);
            return View(model);
        }
    }
}