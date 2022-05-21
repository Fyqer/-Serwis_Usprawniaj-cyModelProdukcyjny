namespace Serwis_UsprawniającyModelProdukcyjny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pierwszamigracja : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TransportCost = c.Double(nullable: false),
                        CostOfWorkingPerHour = c.Double(nullable: false),
                        SearchHistory_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.SearchHistories", t => t.SearchHistory_id)
                .Index(t => t.SearchHistory_id);
            
            CreateTable(
                "dbo.SearchHistories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        ModuleName1 = c.String(),
                        ModuleName2 = c.String(),
                        ModuleName3 = c.String(),
                        ModuleName4 = c.String(),
                        PrductionCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        AssemblyTime = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Description = c.String(),
                        SearchHistory_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.SearchHistories", t => t.SearchHistory_id)
                .Index(t => t.SearchHistory_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "SearchHistory_id", "dbo.SearchHistories");
            DropForeignKey("dbo.Cities", "SearchHistory_id", "dbo.SearchHistories");
            DropIndex("dbo.Modules", new[] { "SearchHistory_id" });
            DropIndex("dbo.Cities", new[] { "SearchHistory_id" });
            DropTable("dbo.Modules");
            DropTable("dbo.SearchHistories");
            DropTable("dbo.Cities");
        }
    }
}
