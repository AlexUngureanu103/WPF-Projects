namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsConstraints : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            AlterColumn("dbo.CourseTypes", "Course", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Classes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Roles", "AssignedRole", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Teachers", "LastName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Teachers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Email", c => c.String());
            AlterColumn("dbo.Teachers", "LastName", c => c.String());
            AlterColumn("dbo.Teachers", "FirstName", c => c.String());
            AlterColumn("dbo.Roles", "AssignedRole", c => c.String());
            AlterColumn("dbo.Classes", "Name", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.CourseTypes", "Course", c => c.String());
            CreateIndex("dbo.Users", "Email", unique: true);
        }
    }
}
