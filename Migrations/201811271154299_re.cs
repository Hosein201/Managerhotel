namespace Managerhotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class re : DbMigration
    {
        public override void Up()
        {
            AddColumn("Facilities.Massagesalon", "ReservationNumberCo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Facilities.Massagesalon", "ReservationNumberCo");
        }
    }
}
