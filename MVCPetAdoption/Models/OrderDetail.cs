using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPetAdoption.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual Order Order { get; set; }
    }
}