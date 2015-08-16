using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPetAdoption.Models
{
    public class ServiceUser
    {
        [ScaffoldColumn(false)]
        public int ServiceUserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public bool IsShelter { get; set; }
        public List<Pet> Pets { get; set; }
        //public List<Pet> Bookmarked { get; set; }
    }
}