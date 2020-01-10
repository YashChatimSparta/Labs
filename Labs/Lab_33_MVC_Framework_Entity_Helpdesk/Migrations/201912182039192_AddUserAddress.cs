namespace Lab_33_MVC_Framework_Entity_Helpdesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserAddress", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserAddress");
        }
    }
}
