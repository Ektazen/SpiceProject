using Food.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using System.Web.UI.WebControls;
using Food.DomainLayer;
using Microsoft.AspNet.Identity;
using Spice.ServiceContract;
using SpiceProject.ViewModels;

namespace SpiceProject.Controllers
{
    public class SpiceController : Controller
    {
        // GET: Spice
        SpiceDbContext context= new SpiceDbContext();
        ISpiceService spiceService;
        public OrderDetailsCart detailCart { get; set; }
        public SpiceController()
        {

        }
        public SpiceController(ISpiceService mService)
        {
            
            spiceService = mService;

        }


        //ISpiceService spiceService;
        //public SpiceController()
        //{

        //}
        //public SpiceController(ISpiceService mService)
        //{
        //    context = new SpiceDbContext();
        //    spiceService = mService;//with dependency injection using a package unity.mvc
        //}

        public ActionResult Index()
        {
            //create a new index view model for the landing page


            var MT = context.MenuItem.Include(m => m.Category).Include(s => s.SubCategory).ToList();

            ViewBag.coup = context.Coupon.ToList();
            


            return View(MT);


        }

        public ActionResult Create()
        {


            ViewBag.cat = context.Category.ToList();
            ViewBag.subcat = context.SubCategory.ToList();
            return View();
           
        }
       

        public ActionResult Details(int id)
        {
            ViewBag.userId = User.Identity.GetUserId();
            
          

            if (User.Identity.IsAuthenticated)
            {
                var oneMenu = context.MenuItem.Include(e => e.Category).Include(s => s.SubCategory).Where(e => e.Id == id).SingleOrDefault();
                return View(oneMenu);
            }
           

            else
            {
                return RedirectToAction("Login", "Account");
            }


            
        }




        public ActionResult Apetizer()
        {
            

            var MT = context.MenuItem.Include(m => m.Category).Include(s => s.SubCategory).ToList();
            //var t = context.Coupon.ToList();
            ViewBag.coup = context.Coupon.ToList();
            return View(MT);

        }
        public ActionResult MainCourse()
        {
            

            var MT = context.MenuItem.Include(m => m.Category).Include(s => s.SubCategory).ToList();
            ViewBag.coup = context.Coupon.ToList();
            return View(MT);

        }
        public ActionResult Desert()
        {
            

            var MT = context.MenuItem.Include(m => m.Category).Include(s => s.SubCategory).ToList();
            ViewBag.coup = context.Coupon.ToList();

            return View(MT);

        }
        public ActionResult Beverages()
        {
            

            var MT = context.MenuItem.Include(m => m.Category).Include(s => s.SubCategory).ToList();
            ViewBag.coup = context.Coupon.ToList();
            return View(MT);

        }
        public ActionResult Spicy()
        {
           

            var MT = context.MenuItem.Include(m => m.Category).Include(s => s.SubCategory).ToList();
            ViewBag.coup = context.Coupon.ToList();
            return View(MT);

        }
        public ActionResult Spicy_Not()
        {
            


            var MT = context.MenuItem.Include(m => m.Category).Include(s => s.SubCategory).ToList();
            ViewBag.coup = context.Coupon.ToList();
            return View(MT);

        }

        public ActionResult Very_Spicy()
        {

            var MT = context.MenuItem.Include(m => m.Category).Include(s => s.SubCategory).ToList();
            ViewBag.coup = context.Coupon.ToList();
            return View(MT);

        }


        public ActionResult AddToCart(ShoppingCart cart,int menuId)
        {
          
           

            ViewBag.userId = User.Identity.GetUserId();
             string userId = ViewBag.userId;

            var ItemsInCart = context.ShoppingCart.ToList().Where(e => e.AppUserId == userId && e.MenuItemId == menuId).FirstOrDefault();
            if (ItemsInCart == null)
            {               
                context.ShoppingCart.Add(cart);
                
                context.SaveChanges();
            }
            else
            {
             ItemsInCart.Count = ItemsInCart.Count + 1;
                
            }
            return RedirectToAction("GetShoppingCart", "Spice");


        }


        [Authorize]
        public ActionResult GetShoppingCart()
        {
           
            
            ViewBag.userId = User.Identity.GetUserId();
            string userId = ViewBag.userId;
            var ItemInCart = context.ShoppingCart.Where(e => e.AppUserId == userId).ToList();
            
            Session["cart"] = ItemInCart.Count;
            return View(ItemInCart);

        }



        public ActionResult Plus(int id)
        {
          
            var cart = context.ShoppingCart.ToList().Where(e => e.CartId == id).FirstOrDefault();

           


            cart.Count = cart.Count + 1;
            context.SaveChanges();
           

            return RedirectToAction("GetShoppingCart");
        }

        public ActionResult Minus(int id)
        {
            var cart = context.ShoppingCart.ToList().Where(e => e.CartId == id).FirstOrDefault();
            if (cart.Count == 1)
            {
               
                context.ShoppingCart.Remove(cart);
                context.SaveChangesAsync();

                var count = context.ShoppingCart.Where(u => u.AppUserId == cart.AppUserId).ToList().Count;
               
            }
            else
            {
                cart.Count -= 1;
               
                context.SaveChanges();
            }

            return RedirectToAction("GetShoppingCart");
        }

        public ActionResult Remove(int id)
        {
            var cart = context.ShoppingCart.ToList().Where(e => e.CartId == id).FirstOrDefault();

        
            context.ShoppingCart.Remove(cart);
           
            context.SaveChanges();

            var count = context.ShoppingCart.Where(u => u.AppUserId == cart.AppUserId).ToList().Count;
            

            context.SaveChanges();
            return RedirectToAction("GetShoppingCart");
        }







    }
}
   