namespace Vidly_authenticate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.String());
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
