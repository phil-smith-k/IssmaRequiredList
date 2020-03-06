namespace IssmaRequiredList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedIsAliveColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Composers", "IsAlive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Composers", "IsAlive", c => c.Boolean(nullable: false));
        }
    }
}
