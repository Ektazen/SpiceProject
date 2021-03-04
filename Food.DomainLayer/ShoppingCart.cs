using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.DomainLayer
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }

        [Key]
        public int CartId { get; set; }
        
        public string AppUserId { get; set; }
        
        
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }
        [Required]
        public int? MenuItemId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter value greater than or equal to {1}")]
        public int Count { get; set; }
    }
}
