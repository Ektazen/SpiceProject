﻿using Food.DomainLayer;
using SpiceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpiceProject.ViewModels
{
    public class OrderDetailsViewModel
    {
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}