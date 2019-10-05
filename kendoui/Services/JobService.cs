using kendoui.Data;
using kendoui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kendoui.Services
{
    public class JobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(JobViewModel model)
        {
            var job = new Job
            {
                Title = model.Title,
                DueDate = model.DueDate,
                FinishDate = model.FinishDate,
                Owner = model.Owner
            };

            _context.Jobs.Add(job);
            _context.SaveChanges();
        }
    }
}
