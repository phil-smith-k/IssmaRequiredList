namespace IssmaRequiredList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMovementNameColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movements", "MovementName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movements", "MovementName");
        }
    }
}
