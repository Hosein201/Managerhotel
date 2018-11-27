namespace Managerhotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ree : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Facilities.Disco", "ReservationnumberDc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Facilities.Disco", "ReservationnumberDc", c => c.Int(nullable: false));
        }
    }
}
