using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingSystemWithStructure.Models
{
    public class thirdCatMasterModel
    {
        public int thirdCatId { get; set; }
        public string thirdCatName { get; set; }

        public int status { get; set; }

        public int catId { get; set; }
        public int subCatId { get; set; }
        public DateTime UpdateOn { get; set; }

     




    }
}