namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeachingMaterialsTable_v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeachingMaterials", "Semester", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeachingMaterials", "Semester");
        }
    }
}
