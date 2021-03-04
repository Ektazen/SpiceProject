using Food.DataLayer;
using Food.DomainLayer;
using Microsoft.AspNet.Identity;
using SpiceProject.Models;
using SpiceProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SpiceProject.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order


        private readonly ApplicationDbContext _db;

        SpiceDbContext context = new SpiceDbContext();
        OrderHeader v = new Food.DomainLayer.OrderHeader();

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
           
        }

        [Authorize]
        public ActionResult Confirm(int id)
        {
            var claimsidentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);
          

            OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel()
            {
            
            OrderHeader = context.OrderHeader.FirstOrDefault(o => o.Id == id && o.UserId == claim.Value),
               
            OrderDetails = context.OrderDetails.Where(o => o.OrderId == id).ToList()
            };

            return View("Summary");


        }




    

            public ActionResult PlaceOrder(int id)
            {
           
                return View("PlaceOrder");

        }


           
            

























           
        
    }
}