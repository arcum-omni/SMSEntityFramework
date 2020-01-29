namespace SMSEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AltStuFullNameReq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FullName", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "FullName", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
