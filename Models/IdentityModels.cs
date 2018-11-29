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
    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ManagerhotelDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ManagerhotelDbContext context)
            : base(context)
        {
        }
    }
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole,
    CustomUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
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
        public virtual Massagesalon Massagesalon { get; set; }
        public virtual Bodybuildingclub Bodybuildingclub { get; set; }
        public virtual Disco Disco { get; set; } 
        public virtual CoffeeShop CoffeeShop { get; set; }
       

    }

    public class ManagerhotelDbContext : IdentityDbContext<ApplicationUser, CustomRole,
    int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ManagerhotelDbContext()
            : base("ManagerConnection")
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

        //    modelBuilder.Entity<ApplicationUser>()
        //        .HasRequired<CoffeeShop>(c => c.CoffeeShop)
        //        .WithMany(u => u.User)
        //        .HasForeignKey(f => f.CoffeeShop);
        //    modelBuilder.Entity<ApplicationUser>()
        //        .HasRequired<Bodybuildingclub>(b => b.Bodybuildingclub)
        //        .WithMany(u => u.User)
        //        .HasForeignKey(f => f.Bodybuildingclub);
        //    modelBuilder.Entity<ApplicationUser>()
        //        .HasRequired<Disco>(d => d.Disco)
        //        .WithMany(u => u.User)
        //        .HasForeignKey(f => f.Disco);
        //    modelBuilder.Entity<ApplicationUser>()
        //        .HasRequired<Massagesalon>(m => m.Massagesalon)
        //        .WithMany(u => u.User)
        //        .HasForeignKey(f => f.Massagesalon);

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