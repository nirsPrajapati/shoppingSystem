using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingSystemWithStructure.Models
{
    public class OrderMasterModel
    {
        public int orderId { get; set; }
        public int productId { get; set; }

        public int shippingId { get; set; }

        public int UserId { get; set; }

        public string OrdrDate { get; set; }
    }
}