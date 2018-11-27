using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Managerhotel.ViewModels
{
    public class MassagesalonsCreateViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاریخ حضور")]
        public DateTime Attendancedate { get; set; }//زمان حضور
        [Display(Name = "زمان حضور")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:00-00-00-00}", ApplyFormatInEditMode = true)]
        public DateTime Attendancetime { get; set; }//زمان حضور
        [MaxLength(400), Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}