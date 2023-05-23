namespace SchoolManagementApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "personId", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "personId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "personId");
            CreateIndex("dbo.Teachers", "personId");
            AddForeignKey("dbo.Students", "personId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Teachers", "personId", "dbo.People", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "FirstName");
            DropColumn("dbo.Students", "LastName");
            DropColumn("dbo.Students", "DateOfBirth");
            DropColumn("dbo.Students", "Address");
            DropColumn("dbo.Teachers", "FirstName");
            DropColumn("dbo.Teachers", "LastName");
            DropColumn("dbo.Teachers", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teachers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Teachers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Students", "Address", c => c.String());
            AddColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Teachers", "personId", "dbo.People");
            DropForeignKey("dbo.Students", "personId", "dbo.People");
            DropIndex("dbo.Teachers", new[] { "personId" });
            DropIndex("dbo.Students", new[] { "personId" });
            DropColumn("dbo.Teachers", "personId");
            DropColumn("dbo.Students", "personId");
            DropTable("dbo.People");
        }
    }
}
