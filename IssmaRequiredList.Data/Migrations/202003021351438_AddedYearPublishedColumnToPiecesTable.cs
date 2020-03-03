namespace IssmaRequiredList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedYearPublishedColumnToPiecesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pieces", "YearPublished", c => c.Int(nullable: false));
        }
        public override void Down()
        {
            DropColumn("dbo.Pieces", "YearPublished");
        }
    }
}
