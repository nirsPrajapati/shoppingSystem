using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingSystemWithStructure.Models
{
    public class subCategoryMasterModel
    {
        public int subCatId { get; set; }
        public string subCatName { get; set; }
        public int status { get; set; }
        public DateTime updateOn { get; set; }
        public int catId { get; set; }
    }
}