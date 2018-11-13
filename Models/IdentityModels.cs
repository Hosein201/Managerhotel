using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Managerhotel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Managerhotel.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        [Key]//PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity
        public Massagesalon Massagesalon { get; set; }
        public Bodybuildingclub Bodybuildingclub{ get; set; }
        public Disco Disco { get; set; }
        public CoffeeShop CoffeeShop { get; set; }
    }
    
    public class ManagerhotelDbContext : IdentityDbContext<ApplicationUser>
    {
        public ManagerhotelDbContext()
            : base("ManagerConnection", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<Bodybuildingclub> Bodybuildingclub { get; set; }
        public virtual DbSet<Massagesalon> Massagesalon { get; set; }
        public virtual DbSet<Disco> Disco { get; set; }
        public virtual DbSet<CoffeeShop> CoffeeShop { get; set; }
       

        public static ManagerhotelDbContext Create()
        {
            return new ManagerhotelDbContext();
        }
    }
}