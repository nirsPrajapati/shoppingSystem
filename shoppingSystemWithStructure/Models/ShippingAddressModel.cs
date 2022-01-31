using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingSystemWithStructure.Models
{
    public class ShippingAddressModel
    {
        public int ShippingAddressId { get; set; }

       
        public string fullName { get; set; }

        public string Address { get; set; }

        public string pincod { get; set; }
        public string city { get; set; }

        public int UserId { get; set; }
    }
}