using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Managerhotel.Models
{
    [Table("Bodybuildingclub", Schema = "Facilities")]
    public class Bodybuildingclub
    {
        [Key]//PK
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity
        public int BodybuildingclubId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاریخ حضور")]
        public DateTime Attendancedate { get; set; }//زمان حضور
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:00-00-00}", ApplyFormatInEditMode = true)]
        [Display(Name = "زمان حضور")]
        public DateTime Attendancetime { get; set; }//زمان حضور
        [MaxLength(400),Display(Name ="توضیحات")]
        public string Description { get; set; }
        public virtual List<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ApplicationUser User { get; set; }





    }
}