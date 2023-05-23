namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Specializations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Absences", "Semester", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "SpecializationId", c => c.Int(nullable: false));
            AddColumn("dbo.Grades", "Semester", c => c.Int(nullable: false));
            CreateIndex("dbo.Classes", "SpecializationId");
            AddForeignKey("dbo.Classes", "SpecializationId", "dbo.Specializations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "SpecializationId", "dbo.Specializations");
            DropIndex("dbo.Classes", new[] { "SpecializationId" });
            DropColumn("dbo.Grades", "Semester");
            DropColumn("dbo.Classes", "SpecializationId");
            DropColumn("dbo.Absences", "Semester");
            DropTable("dbo.Specializations");
        }
    }
}
