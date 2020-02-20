namespace Koora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nominees", "votes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nominees", "votes");
        }
    }
}
