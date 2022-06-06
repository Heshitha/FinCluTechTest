namespace FinCluTech.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Gender = c.String(),
                        StudentStatus = c.String(),
                        Major = c.String(),
                        Country = c.String(),
                        Age = c.String(),
                        SAT = c.String(),
                        Grade = c.String(),
                        Height = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        EditedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        UserRole = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        EditedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Customer");
        }
    }
}
