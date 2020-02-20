namespace Koora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class byteToIntAspUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "department_id", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "department_id" });
            DropColumn("dbo.AspNetUsers", "departmentId");
            RenameColumn(table: "dbo.AspNetUsers", name: "department_id", newName: "departmentId");
            AlterColumn("dbo.AspNetUsers", "departmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "departmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "departmentId");
            AddForeignKey("dbo.AspNetUsers", "departmentId", "dbo.Departments", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "departmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "departmentId" });
            AlterColumn("dbo.AspNetUsers", "departmentId", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "departmentId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.AspNetUsers", name: "departmentId", newName: "department_id");
            AddColumn("dbo.AspNetUsers", "departmentId", c => c.Byte(nullable: false));
            CreateIndex("dbo.AspNetUsers", "department_id");
            AddForeignKey("dbo.AspNetUsers", "department_id", "dbo.Departments", "id");
        }
    }
}
