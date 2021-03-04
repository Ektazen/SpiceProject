using Food.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpiceProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        SpiceDbContext context = new SpiceDbContext();



        ////ISpiceService db;
        //public CategoryController(SpiceDbContext context)
        //{
        //    context = new SpiceDbContext();
        //    //db = mService;//with dependency injection using a package unity.mvc
        //}


        public ActionResult Index(string search = "")
        {

            //search with condition

            ViewBag.Search = search;
            var cat = context.Category.Where(e => e.Name.Contains(search)).ToList();
            return View(cat);
        }

    }
}