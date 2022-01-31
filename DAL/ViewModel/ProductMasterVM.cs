using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
   public class ProductMasterVM
    {
        public int productId { get; set; }
        public int CategoryId { get; set; }

        public int subCatId { get; set; }

        public int thirdCatId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string Color { get; set; }

        public string Discription { get; set; }
        public string ProductImage { get; set; }
        public DateTime EnteryDate { get; set; }

        public string catName { get; set; }

        public string subCatName { get; set; }

        public string thirdCatName { get; set; }


    }
}
