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
       // [Key]//PK
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity
        public int BodybuildingclubId { get; set; }
        [Display(Name = "تاریخ حضور")]
        public DateTime Attendancedate { get; set; }//زمان حضور
        [Display(Name = "زمان حضور")]
        public DateTime Attendancetime { get; set; }//زمان حضور
        [MaxLength(400),Display(Name ="توضیحات")]
        public string Description { get; set; }

        public virtual List<ApplicationUser> User { get; set; }

    }
}