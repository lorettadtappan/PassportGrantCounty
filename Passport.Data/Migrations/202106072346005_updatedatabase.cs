namespace Passport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comment", name: "ExperienceId", newName: "Experience_ExperienceId");
            RenameColumn(table: "dbo.Comment", name: "RoadMapId", newName: "RoadMap_RoadMapId");
            RenameColumn(table: "dbo.Comment", name: "StampId", newName: "Stamp_StampId");
            RenameIndex(table: "dbo.Comment", name: "IX_ExperienceId", newName: "IX_Experience_ExperienceId");
            RenameIndex(table: "dbo.Comment", name: "IX_RoadMapId", newName: "IX_RoadMap_RoadMapId");
            RenameIndex(table: "dbo.Comment", name: "IX_StampId", newName: "IX_Stamp_StampId");
            AddColumn("dbo.Comment", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Comment", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Comment", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Comment", "DateCreated");
            DropColumn("dbo.Comment", "LastUpdated");
            DropColumn("dbo.Comment", "IsDeleted");
            DropColumn("dbo.Experience", "ChallengeScoreIncrease");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Experience", "ChallengeScoreIncrease", c => c.String(nullable: false));
            AddColumn("dbo.Comment", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comment", "LastUpdated", c => c.DateTime());
            AddColumn("dbo.Comment", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Comment", "ModifiedUtc");
            DropColumn("dbo.Comment", "CreatedUtc");
            DropColumn("dbo.Comment", "Title");
            RenameIndex(table: "dbo.Comment", name: "IX_Stamp_StampId", newName: "IX_StampId");
            RenameIndex(table: "dbo.Comment", name: "IX_RoadMap_RoadMapId", newName: "IX_RoadMapId");
            RenameIndex(table: "dbo.Comment", name: "IX_Experience_ExperienceId", newName: "IX_ExperienceId");
            RenameColumn(table: "dbo.Comment", name: "Stamp_StampId", newName: "StampId");
            RenameColumn(table: "dbo.Comment", name: "RoadMap_RoadMapId", newName: "RoadMapId");
            RenameColumn(table: "dbo.Comment", name: "Experience_ExperienceId", newName: "ExperienceId");
        }
    }
}
