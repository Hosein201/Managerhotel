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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity
        public int DiscoId { get; set; }
        [Required]
        public int ReservationnumberDc { get; set; }
        [MaxLength(100)]
        public string Drinking { get; set; }
        public DateTime Attendance { get; set; }//زمان حضور
        public DateTime Plan { get; set; }
        [MaxLength(400)]
        public string Description { get; set; }
        public virtual List<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}