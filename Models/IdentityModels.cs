using System;
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
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Family { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }
        [MaxLength(1)]
        public string Gender { get; set; }
        [MaxLength(200)]
        public string PhotoFilePath { get; set; }
        public  Massagesalon Massagesalon { get; set; }
        public  Bodybuildingclub Bodybuildingclub { get; set; }
        public  Disco Disco { get; set; }
        public  CoffeeShop CoffeeShop { get; set; }
        
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
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder); //Facilities



        //    modelBuilder.Entity<Bodybuildingclub>()
        //        .HasMany(a => a.ApplicationUser)
        //        .WithRequired(b => b.Bodybuildingclub)
        //        .HasForeignKey(a => a.Id);

        //    modelBuilder.Entity<CoffeeShop>()
        //       .HasMany(a => a.ApplicationUser)
        //       .WithRequired(c => c.CoffeeShop)
        //       .HasForeignKey(a => a.Id);

        //    modelBuilder.Entity<Disco>()
        //       .HasMany(a => a.ApplicationUser)
        //       .WithRequired(d=> d.Disco)
        //       .HasForeignKey(a => a.Id);

        //    modelBuilder.Entity<Massagesalon>()
        //       .HasMany(a => a.ApplicationUser)
        //       .WithRequired(m=> m.Massagesalon)
        //       .HasForeignKey(a => a.Id);
        //}
    }
}