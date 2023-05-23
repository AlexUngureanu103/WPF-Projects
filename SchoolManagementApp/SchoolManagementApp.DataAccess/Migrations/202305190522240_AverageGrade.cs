namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AverageGrade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AverageGrades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseClasstId = c.Int(nullable: false),
                        Average = c.Double(nullable: false),
                        Semester = c.Int(nullable: false),
                        ClassCourse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseClasses", t => t.ClassCourse_Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ClassCourse_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AverageGrades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.AverageGrades", "ClassCourse_Id", "dbo.CourseClasses");
            DropIndex("dbo.AverageGrades", new[] { "ClassCourse_Id" });
            DropIndex("dbo.AverageGrades", new[] { "StudentId" });
            DropTable("dbo.AverageGrades");
        }
    }
}
