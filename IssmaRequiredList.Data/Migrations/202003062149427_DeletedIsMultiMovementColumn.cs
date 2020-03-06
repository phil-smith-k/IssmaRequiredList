namespace IssmaRequiredList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedIsMultiMovementColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pieces", "IsMultiMovement");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pieces", "IsMultiMovement", c => c.Boolean(nullable: false));
        }
    }
}
