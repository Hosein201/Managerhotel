using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Managerhotel.Models
{
    [Table("CoffeeShop", Schema = "Facilities")]
    public class CoffeeShop
    {
       [Key]//PK
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity
        public int CoffeeShopId { get; set; }
        [Required ,Display(Name ="شماره رزرو")]
        public string ReservationNumberCo { get; set; }
        [MaxLength(100)]
        [Display(Name = "نام غذا ")]
        public string Eating { get; set; }
        [Display(Name = "تاریخ حضور")]
        public DateTime Attendancedate { get; set; }//زمان حضور
        [Display(Name = "زمان حضور")]
        public DateTime Attendancetime { get; set; }//زمان حضور
        [MaxLength(400)]
        [Display(Name = "سفارشات دیگر ")]
        public string Description { get; set; }

        public virtual List<ApplicationUser> User { get; set; }
        public virtual int ApplicationUserUserId { get; set; }//foreng






    }
}