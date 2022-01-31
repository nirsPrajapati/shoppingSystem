using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
   public class thirdCatMasterVM
    {
        public int thirdCatId { get; set; }
        public string thirdCatName { get; set; }

        public int status { get; set; }

        public int catId { get; set; }
        public int subCatId { get; set; }
        public DateTime UpdateOn { get; set; }
        public string catName { get; set; }
        public string subCatName { get; set; }
    }
}
