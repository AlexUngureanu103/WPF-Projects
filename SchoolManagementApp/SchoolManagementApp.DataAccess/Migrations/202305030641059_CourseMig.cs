namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseTypes");
        }
    }
}
