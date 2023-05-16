namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personIdCascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "personId", "dbo.People");
            DropIndex("dbo.Users", new[] { "personId" });
            AlterColumn("dbo.Users", "personId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "personId");
            AddForeignKey("dbo.Users", "personId", "dbo.People", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "personId", "dbo.People");
            DropIndex("dbo.Users", new[] { "personId" });
            AlterColumn("dbo.Users", "personId", c => c.Int());
            CreateIndex("dbo.Users", "personId");
            AddForeignKey("dbo.Users", "personId", "dbo.People", "Id");
        }
    }
}
