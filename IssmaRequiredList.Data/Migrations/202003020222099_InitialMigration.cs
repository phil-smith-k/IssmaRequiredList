namespace IssmaRequiredList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Composers",
                c => new
                    {
                        ComposerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        Gender = c.Int(),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfDeath = c.DateTime(),
                        IsAlive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ComposerId);
            
            CreateTable(
                "dbo.Pieces",
                c => new
                    {
                        PieceId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        Requirement = c.String(),
                        Duration = c.Time(precision: 7),
                        IsMultiMovement = c.Boolean(nullable: false),
                        IsOutOfPrint = c.Boolean(nullable: false),
                        ComposerId = c.Int(nullable: false),
                        ArrangerId = c.Int(),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PieceId)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .ForeignKey("dbo.Composers", t => t.ArrangerId)
                .ForeignKey("dbo.Composers", t => t.ComposerId, cascadeDelete: true)
                .Index(t => t.ComposerId)
                .Index(t => t.ArrangerId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        MovementId = c.Int(nullable: false, identity: true),
                        MovementNumber = c.Int(nullable: false),
                        PieceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovementId)
                .ForeignKey("dbo.Pieces", t => t.PieceId, cascadeDelete: true)
                .Index(t => t.PieceId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pieces", "ComposerId", "dbo.Composers");
            DropForeignKey("dbo.Pieces", "ArrangerId", "dbo.Composers");
            DropForeignKey("dbo.Pieces", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Movements", "PieceId", "dbo.Pieces");
            DropIndex("dbo.Movements", new[] { "PieceId" });
            DropIndex("dbo.Pieces", new[] { "PublisherId" });
            DropIndex("dbo.Pieces", new[] { "ArrangerId" });
            DropIndex("dbo.Pieces", new[] { "ComposerId" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Movements");
            DropTable("dbo.Pieces");
            DropTable("dbo.Composers");
        }
    }
}
