namespace R61M6C2_w01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
