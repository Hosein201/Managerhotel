using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Managerhotel.ViewModels
{
    public class CoffeeShopsCreateViewModel
    {
        [MaxLength(100)]
        [Display(Name = "نام غذا ")] 
        public string Eating { get; set; }

        [DataType(DataType.Date) ]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاریخ حضور")]
        public DateTime Attendancedate { get; set; }//زمان حضور

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:00-00-00-00}", ApplyFormatInEditMode = true)]
        [Display(Name = "زمان حضور")]
        public DateTime Attendancetime { get; set; }//زمان حضور
        [MaxLength(400)]
        [Display(Name = "سفارشات دیگر ")]
        public string Description { get; set; }
    }

}