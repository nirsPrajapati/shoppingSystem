using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingSystemWithStructure.Models
{
    public class productMasterModel
    {
        public int productId { get; set; }
        public int CategoryId { get; set; }

        public int subCatId { get; set; }

        public int thirdCatId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string Color { get; set; }

        public string Discription { get; set; }
        public HttpPostedFileBase ProductImage { get; set; }
        public DateTime EnteryDate { get; set; }
        public string showImg { get; set; }
    }
}