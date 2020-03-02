namespace IssmaRequiredList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublisherConfig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "Name", c => c.String());
        }
    }
}
