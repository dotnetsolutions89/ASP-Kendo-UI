using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using kendoui.Data;
using kendoui.Models;
using kendoui.Services;
using Microsoft.AspNetCore.Mvc;

namespace kendoui.Controllers
{
    public class JobController : Controller
    {
        private readonly JobService _service;
        private readonly ApplicationDbContext _context;

        public JobController(JobService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _service.GetAll();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult Create(JobViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _service.Add(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Jobs_Update([DataSourceRequest] DataSourceRequest request, Job job)
        {
            if (job != null && ModelState.IsValid)
            {
                _service.Update(job);
            }

            return Json(new[] { job }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Jobs_Destroy([DataSourceRequest] DataSourceRequest request, Job job)
        {
            if (job != null)
            {
                _service.Destroy(job);
            }

            return Json(new[] { job }.ToDataSourceResult(request, ModelState));
        }
    }
}