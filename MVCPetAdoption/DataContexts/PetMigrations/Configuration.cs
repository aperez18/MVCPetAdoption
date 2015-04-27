namespace MVCPetAdoption.DataContexts.PetMigrations
{
    using MVCPetAdoption.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCPetAdoption.DataContexts.PetDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\PetMigrations";
        }

        protected override void Seed(MVCPetAdoption.DataContexts.PetDb context){
          var species = new List<Species>
            {
                new Species { SpeciesName = "Dog" },
                new Species { SpeciesName = "Cat" },
                new Species { SpeciesName = "Rabbit" },
                new Species { SpeciesName = "Lizard" },
                new Species { SpeciesName = "Turtle" },
                new Species { SpeciesName = "Fish" }
               
            };

            var users = new List<User>
            {
                new User { Name = "Aaron Copland,", Email="acopland@gmail.com", Location="adsd", IsShelter=false },
                new User { Name = "Aaron Goldberg", Email="agoldberg@gmail.com", Location="adsd", IsShelter=false },
                new User { Name = "Ryan Corbin", Email="rcorbin@gmail.com", Location="adsd", IsShelter=false },
                new User { Name = "Aidan Mayes", Email="amayes@gmail.com", Location="adsd", IsShelter=false },
                new User { Name = "Adrian Smith", Email="asmith@gmail.com", Location="adsd", IsShelter=false },
                new User { Name = "Alex Woodward", Email="awoodward@gmail.com", Location="adsd", IsShelter=false },
                new User { Name = "Aisha Tyler", Email="atyler@gmail.com", Location="adsd", IsShelter=false },
                new User { Name = "Alanis Morissette", Email="amorissette@gmail.com", Location="adsd", IsShelter=false }
                
            };

            context.Pets.AddOrUpdate(
                p => p.PetId,
                //new Pet { Name = "Suzzie", Breed = "Chihuahua", Age = 2, Description = "Very playful and lovable, loves to cuddle. Has all vaccinations.", Diet = "2 Cups dry dog food throughout the day", Species = species.Single(s => s.SpeciesName == "Dog"), User = users.Single(u => u.Name == "Aaron Copland"), PetPictureUrl = "/Content/Images/placeholder.gif" },
                //new Pet { Name = "Jamie", Breed = "Maine Coon", Age = 1, Description = "Still has much of her kitten playfulness, but also makes a great lap cat.", Diet = "3 small tins of wet cat food throughout the day", Species = species.Single(s => s.SpeciesName == "Cat"), User = users.Single(u => u.Name == "Aaron Goldberg"), PetPictureUrl = "/Content/Images/placeholder.gif" },
                //new Pet { Name = "Jose", Breed = "Box Turtle", Age = 56, Description = "Very aggressive, will protect your home from intruders and friends.  No one gets by this Turtle.", Diet = "Freshly chopped vegetable and raw beef", Species = species.Single(s => s.SpeciesName == "Turtle"), User = users.Single(u => u.Name == "Ryan Corbin"), PetPictureUrl = "/Content/Images/placeholder.gif" },
                //new Pet { Name = "Whitey", Breed = "Chameleon", Age = 5, Description = "Blends into society.", Diet = "A spoonful of flies twice a day", Species = species.Single(s => s.SpeciesName == "Lizard"), User = users.Single(u => u.Name == "Aidan Mayes"), PetPictureUrl = "/Content/Images/placeholder.gif" },
                //new Pet { Name = "Tom", Breed = "White", Age = 6, Description = "Hops more than any rabbit.", Diet = "2 Cups dry rabbit food throughout the day", Species = species.Single(s => s.SpeciesName == "Rabbit"), User = users.Single(u => u.Name == "Adrian Smith"), PetPictureUrl = "/Content/Images/placeholder.gif" },
                new Pet { Name = "Sam", Breed = "Puffer", Age = 3, Description = "Follows you through his tank.", Diet = "Fish food 3 times a day", Species = species.Single(s => s.SpeciesName == "Fish"), User = users.Single(u => u.Name == "Aisha Tyler")}
            );
        context.SaveChanges();
        }
    }
}
