using Food.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.ServiceContract
{
    public interface ISpiceService
    {
        void AddItemsToCart(ShoppingCart cart,int id, string userId);
        IEnumerable<ShoppingCart> GetCartItems(string userId);
    }
}
