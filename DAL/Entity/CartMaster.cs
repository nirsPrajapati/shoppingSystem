using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class CartMaster
    {
        [Key]
        public int cartId { get; set; }
        public int productId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public int byNow { get; set; }
    }
}
