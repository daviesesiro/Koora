namespace Koora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CastVotes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId = c.String(nullable: false, maxLength: 128),
                        nomineeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Nominees", t => t.nomineeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.nomineeId);
            
            CreateTable(
                "dbo.Nominees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        imageDirectory = c.String(nullable: false),
                        name = c.String(nullable: false),
                        positionId = c.Int(nullable: false),
                        voteCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Positions", t => t.positionId, cascadeDelete: true)
                .Index(t => t.positionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        eventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Events", t => t.eventId, cascadeDelete: true)
                .Index(t => t.eventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        createdTime = c.DateTime(nullable: false),
                        endedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        firstName = c.String(nullable: false, maxLength: 15),
                        lastName = c.String(nullable: false, maxLength: 15),
                        departmentId = c.Byte(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        department_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.department_id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.department_id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        facultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Faculties", t => t.facultyId, cascadeDelete: true)
                .Index(t => t.facultyId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PostionResults",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        positionId = c.Int(nullable: false),
                        resultId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Positions", t => t.positionId, cascadeDelete: true)
                .ForeignKey("dbo.Results", t => t.resultId, cascadeDelete: true)
                .Index(t => t.positionId)
                .Index(t => t.resultId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        totalVotes = c.Int(nullable: false),
                        nomineeWinnerId = c.Int(nullable: false),
                        nominee_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Nominees", t => t.nominee_id)
                .Index(t => t.nominee_id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        star = c.Int(nullable: false),
                        comment = c.String(maxLength: 100),
                        userId = c.String(maxLength: 128),
                        placeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Places", t => t.placeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.placeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rates", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rates", "placeId", "dbo.Places");
            DropForeignKey("dbo.PostionResults", "resultId", "dbo.Results");
            DropForeignKey("dbo.Results", "nominee_id", "dbo.Nominees");
            DropForeignKey("dbo.PostionResults", "positionId", "dbo.Positions");
            DropForeignKey("dbo.CastVotes", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "department_id", "dbo.Departments");
            DropForeignKey("dbo.Departments", "facultyId", "dbo.Faculties");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CastVotes", "nomineeId", "dbo.Nominees");
            DropForeignKey("dbo.Nominees", "positionId", "dbo.Positions");
            DropForeignKey("dbo.Positions", "eventId", "dbo.Events");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Rates", new[] { "placeId" });
            DropIndex("dbo.Rates", new[] { "userId" });
            DropIndex("dbo.Results", new[] { "nominee_id" });
            DropIndex("dbo.PostionResults", new[] { "resultId" });
            DropIndex("dbo.PostionResults", new[] { "positionId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Departments", new[] { "facultyId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "department_id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Positions", new[] { "eventId" });
            DropIndex("dbo.Nominees", new[] { "positionId" });
            DropIndex("dbo.CastVotes", new[] { "nomineeId" });
            DropIndex("dbo.CastVotes", new[] { "userId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rates");
            DropTable("dbo.Results");
            DropTable("dbo.PostionResults");
            DropTable("dbo.Places");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Faculties");
            DropTable("dbo.Departments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Events");
            DropTable("dbo.Positions");
            DropTable("dbo.Nominees");
            DropTable("dbo.CastVotes");
        }
    }
}
