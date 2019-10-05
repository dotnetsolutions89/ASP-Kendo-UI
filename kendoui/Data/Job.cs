using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kendoui.Data
{
    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string DueDate { get; set; }
        public string FinishDate { get; set; }
        public string Owner { get; set; }
    }
}
