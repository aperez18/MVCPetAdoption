using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPetAdoption.Models
{
    public class Species
    {
        [ScaffoldColumn(false)]
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public List<Pet> Pets { get; set; }
    }
}