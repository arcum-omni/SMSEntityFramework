namespace SMSEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AltStuDataTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FullName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "FullName", c => c.String(maxLength: 50));
        }
    }
}
