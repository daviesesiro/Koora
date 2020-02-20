namespace Koora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [firstName], [lastName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Gender]) VALUES (N'49038a7e-737b-43cb-9f2d-ddfafbf1cde3', N'Ojurereoluwa', N'Davies', N'ojurere@gmail.com', 0, N'AOSo0lOt9uCv5JRtZ4vflWAn3gQEAXLxcWYNL8CZBm2PnQ8UfVLI/8RtVZO/bnBXpQ==', N'8000f725-282c-403e-a9fb-0dc90498b7e9aaaaqqwe12121212', NULL, 0, 0, NULL, 1, 0, N'ojurere@gmail.com', NULL)
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'49038a7e-737b-43cb-9f2d-ddfafbf1cde3', N'1')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
