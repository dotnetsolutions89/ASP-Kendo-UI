using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kendoui.Models;
using kendoui.Services;
using Microsoft.AspNetCore.Mvc;

namespace kendoui.Controllers
{
    public class JobController : Controller
    {
        private readonly JobService _service;

        public JobController(JobService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}