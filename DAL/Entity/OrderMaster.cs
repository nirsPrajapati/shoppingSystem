using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class OrderMaster
    {
        [Key]
        public int orderId { get; set; }
        public int productId { get; set; }

        public int shippingId { get; set; }

        public int UserId { get; set; }

        public string OrdrDate { get; set; }

    }
}
