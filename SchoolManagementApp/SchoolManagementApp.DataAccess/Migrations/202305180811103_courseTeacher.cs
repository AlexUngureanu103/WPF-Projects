namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseTeacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseClassTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseClassTeachers", "CourseClassId", "dbo.CourseClasses");
            DropIndex("dbo.CourseClassTeachers", new[] { "CourseClassId" });
            DropIndex("dbo.CourseClassTeachers", new[] { "TeacherId" });
            AlterColumn("dbo.CourseClassTeachers", "CourseClassId", c => c.Int(nullable: false));
            AlterColumn("dbo.CourseClassTeachers", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseClassTeachers", "CourseClassId");
            CreateIndex("dbo.CourseClassTeachers", "TeacherId");
            AddForeignKey("dbo.CourseClassTeachers", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseClassTeachers", "CourseClassId", "dbo.CourseClasses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseClassTeachers", "CourseClassId", "dbo.CourseClasses");
            DropForeignKey("dbo.CourseClassTeachers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.CourseClassTeachers", new[] { "TeacherId" });
            DropIndex("dbo.CourseClassTeachers", new[] { "CourseClassId" });
            AlterColumn("dbo.CourseClassTeachers", "TeacherId", c => c.Int());
            AlterColumn("dbo.CourseClassTeachers", "CourseClassId", c => c.Int());
            CreateIndex("dbo.CourseClassTeachers", "TeacherId");
            CreateIndex("dbo.CourseClassTeachers", "CourseClassId");
            AddForeignKey("dbo.CourseClassTeachers", "CourseClassId", "dbo.CourseClasses", "Id");
            AddForeignKey("dbo.CourseClassTeachers", "TeacherId", "dbo.Teachers", "Id");
        }
    }
}
