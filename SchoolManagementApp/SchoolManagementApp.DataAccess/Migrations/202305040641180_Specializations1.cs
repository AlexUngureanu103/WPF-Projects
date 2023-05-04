namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Specializations1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecializationCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecializationId = c.Int(nullable: false),
                        CourseTypeId = c.Int(nullable: false),
                        HasThesis = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTypes", t => t.CourseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId)
                .Index(t => t.CourseTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecializationCourses", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.SpecializationCourses", "CourseTypeId", "dbo.CourseTypes");
            DropIndex("dbo.SpecializationCourses", new[] { "CourseTypeId" });
            DropIndex("dbo.SpecializationCourses", new[] { "SpecializationId" });
            DropTable("dbo.SpecializationCourses");
        }
    }
}
