using Food.DomainLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.DataLayer
{
    public class SpiceDbContext:DbContext
    {
        public SpiceDbContext() : base("Conn")
        {

        }


        public DbSet<Category> Category { get; set; }
        public DbSet<Coupon> Coupon { get; set; }

        public DbSet<SubCategory> SubCategory { get; set; }

        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }


        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
