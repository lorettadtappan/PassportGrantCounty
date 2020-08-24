namespace Passport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedStampExperienceRoadMap : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        RoadMapId = c.Int(),
                        ExperienceId = c.Int(),
                        StampId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Experience", t => t.ExperienceId)
                .ForeignKey("dbo.RoadMap", t => t.RoadMapId)
                .ForeignKey("dbo.Stamp", t => t.StampId)
                .Index(t => t.RoadMapId)
                .Index(t => t.ExperienceId)
                .Index(t => t.StampId);
            
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ChallengeScoreIncrease = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceId);
            
            CreateTable(
                "dbo.RoadMap",
                c => new
                    {
                        RoadMapId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Speed = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ChallengeScoreIncrease = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoadMapId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        CommentId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Stamp",
                c => new
                    {
                        StampId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        StampLevel = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StampId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.RoadMapExperience",
                c => new
                    {
                        RoadMap_RoadMapId = c.Int(nullable: false),
                        Experience_ExperienceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoadMap_RoadMapId, t.Experience_ExperienceId })
                .ForeignKey("dbo.RoadMap", t => t.RoadMap_RoadMapId, cascadeDelete: true)
                .ForeignKey("dbo.Experience", t => t.Experience_ExperienceId, cascadeDelete: true)
                .Index(t => t.RoadMap_RoadMapId)
                .Index(t => t.Experience_ExperienceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Comment", "StampId", "dbo.Stamp");
            DropForeignKey("dbo.Comment", "RoadMapId", "dbo.RoadMap");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "ExperienceId", "dbo.Experience");
            DropForeignKey("dbo.RoadMapExperience", "Experience_ExperienceId", "dbo.Experience");
            DropForeignKey("dbo.RoadMapExperience", "RoadMap_RoadMapId", "dbo.RoadMap");
            DropIndex("dbo.RoadMapExperience", new[] { "Experience_ExperienceId" });
            DropIndex("dbo.RoadMapExperience", new[] { "RoadMap_RoadMapId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "StampId" });
            DropIndex("dbo.Comment", new[] { "ExperienceId" });
            DropIndex("dbo.Comment", new[] { "RoadMapId" });
            DropTable("dbo.RoadMapExperience");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Stamp");
            DropTable("dbo.Reply");
            DropTable("dbo.RoadMap");
            DropTable("dbo.Experience");
            DropTable("dbo.Comment");
            DropTable("dbo.Background");
        }
    }
}
