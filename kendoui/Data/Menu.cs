using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kendoui.Data
{
    public class Menu
    {
        public int MenuId { get; set; }
        public int ParentMenuId { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
    }
}
