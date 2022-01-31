using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingSystemWithStructure.Models
{
    public class cartMasterModel
    {
        public int cartId { get; set; }
        public int productId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public int byNow { get; set; }
    }
}