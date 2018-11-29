using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Managerhotel.Models
{
    [Table("Disco", Schema = "Facilities")]
    public class Disco
    {
       [Key]//PK
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity
        public int DiscoId { get; set; }
        [Required,Display(Name =("شماره رزرو"))]
        public string ReservationnumberDc { get; set; }
        [MaxLength(100),Display(Name ="منو نوشیدنی")]
        public string Drinking { get; set; }
        [Display(Name = "تاریخ حضور")]
        public DateTime Attendancedate { get; set; }//زمان حضور
        [Display(Name = "زمان حضور")]
        public DateTime Attendancetime { get; set; }//زمان حضور
        [MaxLength(400)]
        [Display(Name = "توضیحات ")]
        public string Description { get; set; }
        public virtual List<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ApplicationUser User { get; set; }




    }
}