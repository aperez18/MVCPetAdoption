using MVCPetAdoption.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCPetAdoption.DataContexts
{
    public class PetDb : DbContext
    {
        public PetDb() : base("DefaultConnection") { }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<ServiceUser> Users { get; set; }
        public DbSet<Species> Species { get; set; }
    }
}