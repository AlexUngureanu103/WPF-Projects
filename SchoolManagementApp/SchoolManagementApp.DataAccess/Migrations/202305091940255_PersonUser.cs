namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "personId", "dbo.People");
            DropForeignKey("dbo.Teachers", "personId", "dbo.People");
            DropIndex("dbo.Students", new[] { "personId" });
            DropIndex("dbo.Teachers", new[] { "personId" });
            AddColumn("dbo.Users", "personId", c => c.Int());
            CreateIndex("dbo.Users", "personId");
            AddForeignKey("dbo.Users", "personId", "dbo.People", "Id");
            DropColumn("dbo.Students", "personId");
            DropColumn("dbo.Teachers", "personId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "personId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "personId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "personId", "dbo.People");
            DropIndex("dbo.Users", new[] { "personId" });
            DropColumn("dbo.Users", "personId");
            CreateIndex("dbo.Teachers", "personId");
            CreateIndex("dbo.Students", "personId");
            AddForeignKey("dbo.Teachers", "personId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "personId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
