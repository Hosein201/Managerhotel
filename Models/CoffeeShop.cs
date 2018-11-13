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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity
        public int CoffeeShopId { get; set; }
        [Required]
        public int ReservationNumberCo { get; set; }
        [MaxLength(100)]
        public string Eating { get; set; }
        public DateTime Attendance { get; set; }//زمان حضور
        [MaxLength(400)]
        public string Description { get; set; }
        public virtual List<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ApplicationUser User { get; set; }




    }
}