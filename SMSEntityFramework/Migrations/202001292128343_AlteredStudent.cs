namespace SMSEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FullName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "FullName", c => c.String());
        }
    }
}
