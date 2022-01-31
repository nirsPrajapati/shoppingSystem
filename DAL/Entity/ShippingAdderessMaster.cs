using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class ShippingAdderessMaster
    {
        [Key]
        public int ShippingAddressId { get; set; }

      
        public string fullName { get; set; }

        public string Address { get; set; }

        public string pincod { get; set; }
        public string city { get; set; }

        public int UserId { get; set; }


    }
}
