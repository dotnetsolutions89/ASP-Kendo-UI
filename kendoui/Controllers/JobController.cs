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

        //public ActionResult TagHelper_Jobs_Read([DataSourceRequest] DataSourceRequest request)
        //{
        //    var items = _context.Jobs.Select(r => new Job
        //    {
        //        JobId = r.JobId,
        //        Title = r.Title,
        //        DueDate = r.DueDate,
        //        FinishDate = r.FinishDate,
        //        Owner = r.Owner
        //    });

        //    return Json(items.ToDataSourceResult(request));
        //}

        public IActionResult Create(JobViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _service.Add(model);

            return RedirectToAction("Index");
        }

        public ActionResult Jobs_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "Data")]IEnumerable<Job> jobs)
        {
            if (jobs.Any())
            {
                foreach (var job in jobs)
                {
                    _service.Destroy(job);
                }
            }

            return Json(jobs.ToDataSourceResult(request, ModelState));
        }
    }
}