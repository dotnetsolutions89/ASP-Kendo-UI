using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kendoui.Models
{
    public class JobViewModel
    {
        [Required]
        [Display(Name = "İşin Adı")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Bildirim Tarihi")]
        public string DueDate { get; set; }

        [Display(Name = "Çözüm Tarihi")]
        public string FinishDate { get; set; }

        [Required]
        [Display(Name = "İşin Sahibi")]
        public string Owner { get; set; }
    }
}
