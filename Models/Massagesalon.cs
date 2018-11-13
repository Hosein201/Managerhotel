using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Managerhotel.Models
{
    [Table("Massagesalon", Schema= "Facilities")]
    public class Massagesalon
    {
        [Key]//PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity
        public int MassagesalonId { get; set; }
        public DateTime Attendance { get; set; }//زمان حضور
        public DateTime PlanWoman { get; set; }
        public DateTime PlanMan { get; set; }
        [MaxLength(100)]
        public string Massagelist { get; set; }
        [MaxLength(400)]
        public string Description { get; set; }
        public virtual List<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
    
}