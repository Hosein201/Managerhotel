namespace Managerhotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Facilities.Bodybuildingclub",
                c => new
                    {
                        BodybuildingclubId = c.Int(nullable: false, identity: true),
                        Attendancedate = c.DateTime(nullable: false),
                        Attendancetime = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.BodybuildingclubId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 50),
                        Family = c.String(maxLength: 50),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Gender = c.String(maxLength: 1),
                        PhotoFilePath = c.String(maxLength: 200),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Bodybuildingclub_BodybuildingclubId = c.Int(),
                        CoffeeShop_CoffeeShopId = c.Int(),
                        Disco_DiscoId = c.Int(),
                        Massagesalon_MassagesalonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Facilities.Bodybuildingclub", t => t.Bodybuildingclub_BodybuildingclubId)
                .ForeignKey("Facilities.CoffeeShop", t => t.CoffeeShop_CoffeeShopId)
                .ForeignKey("Facilities.Disco", t => t.Disco_DiscoId)
                .ForeignKey("Facilities.Massagesalon", t => t.Massagesalon_MassagesalonId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Bodybuildingclub_BodybuildingclubId)
                .Index(t => t.CoffeeShop_CoffeeShopId)
                .Index(t => t.Disco_DiscoId)
                .Index(t => t.Massagesalon_MassagesalonId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Facilities.CoffeeShop",
                c => new
                    {
                        CoffeeShopId = c.Int(nullable: false, identity: true),
                        ReservationNumberCo = c.String(nullable: false),
                        Eating = c.String(maxLength: 100),
                        Attendancedate = c.DateTime(nullable: false),
                        Attendancetime = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.CoffeeShopId);
            
            CreateTable(
                "Facilities.Disco",
                c => new
                    {
                        DiscoId = c.Int(nullable: false, identity: true),
                        ReservationnumberDc = c.Int(nullable: false),
                        Drinking = c.String(maxLength: 100),
                        Attendancedate = c.DateTime(nullable: false),
                        Attendancetime = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.DiscoId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Facilities.Massagesalon",
                c => new
                    {
                        MassagesalonId = c.Int(nullable: false, identity: true),
                        Attendancedate = c.DateTime(nullable: false),
                        Attendancetime = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.MassagesalonId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Massagesalon_MassagesalonId", "Facilities.Massagesalon");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Disco_DiscoId", "Facilities.Disco");
            DropForeignKey("dbo.AspNetUsers", "CoffeeShop_CoffeeShopId", "Facilities.CoffeeShop");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Bodybuildingclub_BodybuildingclubId", "Facilities.Bodybuildingclub");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Massagesalon_MassagesalonId" });
            DropIndex("dbo.AspNetUsers", new[] { "Disco_DiscoId" });
            DropIndex("dbo.AspNetUsers", new[] { "CoffeeShop_CoffeeShopId" });
            DropIndex("dbo.AspNetUsers", new[] { "Bodybuildingclub_BodybuildingclubId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("Facilities.Massagesalon");
            DropTable("dbo.AspNetUserLogins");
            DropTable("Facilities.Disco");
            DropTable("Facilities.CoffeeShop");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("Facilities.Bodybuildingclub");
        }
    }
}
