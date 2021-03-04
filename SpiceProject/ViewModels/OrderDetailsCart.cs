using Food.DomainLayer;
using SpiceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpiceProject.ViewModels
{
    public class OrderDetailsCart
    {
        public List<ShoppingCart> ListCart { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public MenuItem MenuItem { get; set; }



    }
}