using Food.DataLayer;
using Food.DomainLayer;
using Spice.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.ServiceLayer
{
    public class SpiceService : ISpiceService
    {
        SpiceDbContext context = new SpiceDbContext();
        public void AddItemsToCart(ShoppingCart cart,int menuId, string userId)
        {
            var ItemsInCart = context.ShoppingCart.ToList().Where(e => e.AppUserId == userId && e.MenuItemId == menuId).FirstOrDefault();
            if (ItemsInCart == null)
            {
                context.ShoppingCart.Add(cart);
                context.SaveChanges();
            }
            else
            {
                ItemsInCart.Count = ItemsInCart.Count + 1;
                context.SaveChanges();
            }
        }

        public IEnumerable<ShoppingCart> GetCartItems(string userId)
        {
            var ItemInCart = context.ShoppingCart.Where(e => e.AppUserId == userId).ToList();
            return ItemInCart;
        }
    }
}
