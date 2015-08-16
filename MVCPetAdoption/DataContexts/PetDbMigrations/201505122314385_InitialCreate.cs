namespace MVCPetAdoption.DataContexts.PetDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        PetId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetId = c.Int(nullable: false, identity: true),
                        SpeciesId = c.Int(nullable: false),
                        Name = c.String(),
                        Breed = c.String(),
                        Age = c.Int(nullable: false),
                        Description = c.String(),
                        Diet = c.String(),
                        PetPictureUrl = c.String(),
                        ServiceUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.Species", t => t.SpeciesId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceUsers", t => t.ServiceUserId, cascadeDelete: true)
                .Index(t => t.SpeciesId)
                .Index(t => t.ServiceUserId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        SpeciesName = c.String(),
                    })
                .PrimaryKey(t => t.SpeciesId);
            
            CreateTable(
                "dbo.ServiceUsers",
                c => new
                    {
                        ServiceUserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Location = c.String(),
                        IsShelter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceUserId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        PetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.PetId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "PetId", "dbo.Pets");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Carts", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "ServiceUserId", "dbo.ServiceUsers");
            DropForeignKey("dbo.Pets", "SpeciesId", "dbo.Species");
            DropIndex("dbo.OrderDetails", new[] { "PetId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Pets", new[] { "ServiceUserId" });
            DropIndex("dbo.Pets", new[] { "SpeciesId" });
            DropIndex("dbo.Carts", new[] { "PetId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.ServiceUsers");
            DropTable("dbo.Species");
            DropTable("dbo.Pets");
            DropTable("dbo.Carts");
        }
    }
}
