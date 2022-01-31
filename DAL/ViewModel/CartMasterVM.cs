using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
   public class CartMasterVM
    {
        public int cartId { get; set; }
        public int productId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public int byNow { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
    }
}
