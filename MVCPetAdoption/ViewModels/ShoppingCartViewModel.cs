using MVCPetAdoption.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPetAdoption.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        //public decimal CartTotal { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}