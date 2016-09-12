namespace ACME.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baseentityadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Created", c => c.DateTime());
            AddColumn("dbo.Tickets", "Modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Modified");
            DropColumn("dbo.Tickets", "Created");
        }
    }
}
