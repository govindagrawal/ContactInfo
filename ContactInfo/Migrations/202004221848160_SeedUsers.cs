namespace ContactInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5247ba86-2faa-44d5-9ad5-e28301079c4d', N'guest@contactinfo.com', 0, N'AEiddeRLrkNJiQufnmhr/tJa8mgiO8oHorObUBKFswD0X8MRqK55wDjO+y9m2Ay8pQ==', N'b441c511-c2fa-44ca-8b54-f2b5f4d8490e', NULL, 0, 0, NULL, 1, 0, N'guest@contactinfo.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7f331703-df1e-4a50-9f42-b3b745b8c66d', N'admin@contactinfo.com', 0, N'AFKn43vywCFUpNIWDenFIplP0zQxQglRZ0WrlUnjwNsg3/5widGAs3uQOA0ptLnH4Q==', N'353c38fa-d646-488f-9a38-e3b619acd239', NULL, 0, 0, NULL, 1, 0, N'admin@contactinfo.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'85ffa068-56c4-4029-b25f-9483dd55f8fc', N'CanManageContacts')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7f331703-df1e-4a50-9f42-b3b745b8c66d', N'85ffa068-56c4-4029-b25f-9483dd55f8fc')
            ");
        }

        public override void Down()
        {
        }
    }
}
