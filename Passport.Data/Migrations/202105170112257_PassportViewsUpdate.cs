namespace Passport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassportViewsUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RoadMap", "ChallengeScoreIncrease");
            DropTable("dbo.Background");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Background",
                c => new
                    {
                        BackgroundId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AdventureLog = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BackgroundId);
            
            AddColumn("dbo.RoadMap", "ChallengeScoreIncrease", c => c.String(nullable: false));
        }
    }
}
