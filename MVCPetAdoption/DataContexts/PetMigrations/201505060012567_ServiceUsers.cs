namespace MVCPetAdoption.DataContexts.PetMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "UserId", "dbo.Users");
            DropIndex("dbo.Pets", new[] { "UserId" });
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
            
            AddColumn("dbo.Pets", "User_ServiceUserId", c => c.Int());
            CreateIndex("dbo.Pets", "User_ServiceUserId");
            AddForeignKey("dbo.Pets", "User_ServiceUserId", "dbo.ServiceUsers", "ServiceUserId");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.Pets", "User_ServiceUserId", "dbo.ServiceUsers");
            DropIndex("dbo.Pets", new[] { "User_ServiceUserId" });
            DropColumn("dbo.Pets", "User_ServiceUserId");
            DropTable("dbo.ServiceUsers");
            CreateIndex("dbo.Pets", "UserId");
            AddForeignKey("dbo.Pets", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
