namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassCourseUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseClasses", "HasCourse", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseClasses", "HasCourse");
        }
    }
}
