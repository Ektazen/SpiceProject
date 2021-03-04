using Food.DataLayer;
using SpiceProject.Models;
using SpiceProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Food.DomainLayer;
using Microsoft.AspNet.Identity;

namespace SpiceProject.Controllers
{
    public class CartController : Controller
    {
       
        // GET: Cart
        ApplicationDbContext db = new ApplicationDbContext();

        SpiceDbContext context = new SpiceDbContext();
        OrderHeader or = new OrderHeader();
        public OrderDetailsCart detailCart { get; set; }
        

        public ActionResult Summary()
        {
            detailCart = new OrderDetailsCart()
            {
                OrderHeader = new Food.DomainLayer.OrderHeader()
            };

            OrderHeader or = new OrderHeader();
            detailCart.OrderHeader.OrderTotal = 0;

            var claimsidentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsidentity.FindFirst(ClaimTypes.Name);
            ViewBag.userId = User.Identity.GetUserId();
            string userId = ViewBag.userId;


            ApplicationUser applicationUser = db.Users.Where(c => c.Id == userId).FirstOrDefault();

            var cart = context.ShoppingCart.Where(c => c.AppUserId == userId);
            if (cart != null)
            {
                detailCart.ListCart = cart.ToList();
            }

            foreach (var list in detailCart.ListCart)
            {
                list.MenuItem = context.MenuItem.FirstOrDefault(m => m.Id == list.MenuItemId);
                detailCart.OrderHeader.OrderTotal = detailCart.OrderHeader.OrderTotal + (list.MenuItem.Price * list.Count);
            }

            detailCart.OrderHeader.OrderTotalOriginal = detailCart.OrderHeader.OrderTotal;
            detailCart.OrderHeader.PickupName = applicationUser.UserName;
            detailCart.OrderHeader.PhoneNumber = applicationUser.PhoneNumber;
            detailCart.OrderHeader.PickUpTime = DateTime.Now;
            

           
            return View(detailCart);
        }



        [HttpPost]
        
         public ActionResult Summary(OrderDetailsCart detailsCart)
        {
            var claimsidentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsidentity.FindFirst(ClaimTypes.Name);
            ViewBag.userId = User.Identity.GetUserId();
            string userId = ViewBag.userId;


            ApplicationUser applicationUser = db.Users.Where(c => c.Id == userId).FirstOrDefault();

            var cart = context.ShoppingCart.Where(c => c.AppUserId == userId).FirstOrDefault();


            var menu = context.MenuItem.FirstOrDefault(m => m.Id == cart.MenuItemId);


            //or.OrderTotal = detailCart.OrderHeader.OrderTotal + (menu.Price* cart.Count);
            

            or.UserId = detailsCart.OrderHeader.UserId;
            or.OrderDate = DateTime.Now;
           
            or.OrderTotalOriginal = detailsCart.OrderHeader.OrderTotalOriginal;
           
            or.PickUpTime = DateTime.Now;
            or.PickUpDate = DateTime.Now;
            or.PickupName = detailsCart.OrderHeader.PickupName;
            or.PhoneNumber = detailsCart.OrderHeader.PhoneNumber;
            or.Comments = detailsCart.OrderHeader.Comments;

            context.OrderHeader.Add(or);
            context.SaveChanges();


            return RedirectToAction("Transaction");
            
        }

        public ActionResult Transaction()
        {
            return View();
        }
        public ActionResult OrderPlaced()
        {
            return View();
        }





       



    }
}












