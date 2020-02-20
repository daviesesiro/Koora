namespace Koora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class adjustmentToCastVote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CastVotes", "positionId", c => c.Int(nullable: true));
            CreateIndex("dbo.CastVotes", "positionId");
            AddForeignKey("dbo.CastVotes", "positionId", "dbo.Positions", "id", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.CastVotes", "positionId", "dbo.Positions");
            DropIndex("dbo.CastVotes", new[] { "positionId" });
            DropColumn("dbo.CastVotes", "positionId");
        }
    }
}
