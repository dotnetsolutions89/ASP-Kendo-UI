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

        public IEnumerable<Job> GetAll()
        {
            return _context.Jobs.ToList();
        }

        public void Update(Job job)
        {
            _context.Entry(GetAll().FirstOrDefault(p => p.JobId == job.JobId)).CurrentValues.SetValues(job);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var job = _context.Jobs.Find(id);

            if (job != null)
            {
                _context.Remove(job);
                _context.SaveChanges();
            }
        }

        public void Destroy(Job job)
        {
            var target = GetAll().FirstOrDefault(p => p.JobId == job.JobId);
            if (target != null)
            {
                _context.Jobs.Remove(target);
                _context.SaveChanges();
            }
        }
    }
}
