using MVCPetAdoption.DataContexts;
using MVCPetAdoption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPetAdoption.Controllers
{
    public class CheckoutController : Controller
    {

        PetDb storeDB = new PetDb();
        //	GET:	/Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            var order = new Order();
            TryUpdateModel(order);
            try
            {
                order.Username = User.Identity.IsAuthenticated ?
                User.Identity.Name : "Guest";
                order.OrderDate = DateTime.Now;
                //Save	Order
                storeDB.Orders.Add(order);
                storeDB.SaveChanges();
                //Process	the	order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);
                return RedirectToAction("Complete", new { id = order.OrderId });
            }
            catch
            {
                //Invalid	-	redisplay	with	errors
                return View(order);
            }	
        }
        public ActionResult Complete()
        {
            return View();
        }
    }
}