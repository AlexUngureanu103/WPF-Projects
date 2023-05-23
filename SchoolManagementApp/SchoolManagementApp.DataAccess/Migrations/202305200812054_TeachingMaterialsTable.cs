namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeachingMaterialsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeachingMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        CourseClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseClasses", t => t.CourseClassId, cascadeDelete: true)
                .Index(t => t.CourseClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeachingMaterials", "CourseClassId", "dbo.CourseClasses");
            DropIndex("dbo.TeachingMaterials", new[] { "CourseClassId" });
            DropTable("dbo.TeachingMaterials");
        }
    }
}
