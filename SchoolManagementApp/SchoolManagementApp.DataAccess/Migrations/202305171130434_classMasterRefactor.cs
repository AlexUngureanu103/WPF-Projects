namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classMasterRefactor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassMasters", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.ClassMasters", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.ClassMasters", new[] { "TeacherId" });
            DropIndex("dbo.ClassMasters", new[] { "ClassId" });
            AddColumn("dbo.Classes", "TeacherId", c => c.Int());
            CreateIndex("dbo.Classes", "TeacherId");
            AddForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers", "Id");
            DropTable("dbo.ClassMasters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClassMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropColumn("dbo.Classes", "TeacherId");
            CreateIndex("dbo.ClassMasters", "ClassId");
            CreateIndex("dbo.ClassMasters", "TeacherId");
            AddForeignKey("dbo.ClassMasters", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClassMasters", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
        }
    }
}
