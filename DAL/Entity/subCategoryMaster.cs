using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class subCategoryMaster
    {
        [Key]
        public int subCatId { get; set; }
        public string subCatName { get; set; }
        public int status { get; set; }
        public DateTime updateOn { get; set; }

        public int catId { get; set; }

       public List<thirdcategoryMaster> ThirdCatList { get; set; }
    }
}
