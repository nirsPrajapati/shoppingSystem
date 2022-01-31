using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class subCategoryVM
    {
        public int subCatId { get; set; }
        public string subCatName { get; set; }
        public int status { get; set; }
        public DateTime updateOn { get; set; }

        public int catId { get; set; }

        public string catName { get; set; }

    }
}
