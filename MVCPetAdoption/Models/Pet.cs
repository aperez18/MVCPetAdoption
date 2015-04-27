using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPetAdoption.Models
{
    public class Pet
    {
        [ScaffoldColumn(false)]
        public int PetId { get; set; }
        [ScaffoldColumn(false)]
        public int SpeciesId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string Diet { get; set; }
        public int UserId { get; set; }
        public virtual Species Species { get; set; }
        public virtual User User { get; set; }
    }
}