namespace MVCPetAdoption.DataContexts.PetMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.Species", t => t.SpeciesId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SpeciesId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        SpeciesName = c.String(),
                    })
                .PrimaryKey(t => t.SpeciesId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Location = c.String(),
                        IsShelter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Pets", "SpeciesId", "dbo.Species");
            DropIndex("dbo.Pets", new[] { "UserId" });
            DropIndex("dbo.Pets", new[] { "SpeciesId" });
            DropTable("dbo.Users");
            DropTable("dbo.Species");
            DropTable("dbo.Pets");
        }
    }
}
