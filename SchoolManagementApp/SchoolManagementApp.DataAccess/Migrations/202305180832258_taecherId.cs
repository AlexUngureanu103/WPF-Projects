namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taecherId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseClassTeachers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.CourseClassTeachers", new[] { "TeacherId" });
            AlterColumn("dbo.CourseClassTeachers", "TeacherId", c => c.Int());
            CreateIndex("dbo.CourseClassTeachers", "TeacherId");
            AddForeignKey("dbo.CourseClassTeachers", "TeacherId", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseClassTeachers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.CourseClassTeachers", new[] { "TeacherId" });
            AlterColumn("dbo.CourseClassTeachers", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseClassTeachers", "TeacherId");
            AddForeignKey("dbo.CourseClassTeachers", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
    }
}
