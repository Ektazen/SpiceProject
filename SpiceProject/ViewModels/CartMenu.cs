using Food.DomainLayer;
using SpiceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpiceProject.ViewModels
{
    public class CartMenu
    {
        public List<ShoppingCart> ShoppingCart { get; set; }
        public List<MenuItem> MenuItem { get; set; }
    }
}