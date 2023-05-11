namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseClassTeacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseClasses", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.CourseClasses", new[] { "Teacher_Id" });
            CreateTable(
                "dbo.CourseClassTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseClassId = c.Int(),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseClasses", t => t.CourseClassId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.CourseClassId)
                .Index(t => t.TeacherId);
            
            DropColumn("dbo.CourseClasses", "Teacher_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseClasses", "Teacher_Id", c => c.Int());
            DropForeignKey("dbo.CourseClassTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseClassTeachers", "CourseClassId", "dbo.CourseClasses");
            DropIndex("dbo.CourseClassTeachers", new[] { "TeacherId" });
            DropIndex("dbo.CourseClassTeachers", new[] { "CourseClassId" });
            DropTable("dbo.CourseClassTeachers");
            CreateIndex("dbo.CourseClasses", "Teacher_Id");
            AddForeignKey("dbo.CourseClasses", "Teacher_Id", "dbo.Teachers", "Id");
        }
    }
}
