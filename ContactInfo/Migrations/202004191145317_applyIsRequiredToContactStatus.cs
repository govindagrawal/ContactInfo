namespace ContactInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyIsRequiredToContactStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Status", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Status", c => c.String(maxLength: 10));
        }
    }
}
