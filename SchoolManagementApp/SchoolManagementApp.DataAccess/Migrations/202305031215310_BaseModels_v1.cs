namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseModels_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsMotivated = c.Boolean(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTypes", t => t.CourseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseTypeId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        IsThesis = c.Boolean(nullable: false),
                        CourseTypeId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTypes", t => t.CourseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseTypeId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        Email = c.String(),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ClassMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CourseClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseTypeId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.CourseTypes", t => t.CourseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.CourseTypeId)
                .Index(t => t.ClassId)
                .Index(t => t.Teacher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassMasters", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "UserId", "dbo.Users");
            DropForeignKey("dbo.CourseClasses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.CourseClasses", "CourseTypeId", "dbo.CourseTypes");
            DropForeignKey("dbo.CourseClasses", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.ClassMasters", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Absences", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Grades", "CourseTypeId", "dbo.CourseTypes");
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Absences", "CourseTypeId", "dbo.CourseTypes");
            DropIndex("dbo.CourseClasses", new[] { "Teacher_Id" });
            DropIndex("dbo.CourseClasses", new[] { "ClassId" });
            DropIndex("dbo.CourseClasses", new[] { "CourseTypeId" });
            DropIndex("dbo.Teachers", new[] { "UserId" });
            DropIndex("dbo.ClassMasters", new[] { "ClassId" });
            DropIndex("dbo.ClassMasters", new[] { "TeacherId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropIndex("dbo.Grades", new[] { "CourseTypeId" });
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.Absences", new[] { "CourseTypeId" });
            DropIndex("dbo.Absences", new[] { "StudentId" });
            DropTable("dbo.CourseClasses");
            DropTable("dbo.Teachers");
            DropTable("dbo.ClassMasters");
            DropTable("dbo.Users");
            DropTable("dbo.Grades");
            DropTable("dbo.Classes");
            DropTable("dbo.Students");
            DropTable("dbo.Absences");
        }
    }
}
