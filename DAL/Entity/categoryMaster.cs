using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class categoryMaster
    {
        [Key]
        public int catId { get; set; }
        public string catName { get; set; }
        public int status { get; set; }
    
      public  List<subCategoryMaster> subcatList { get; set; }
    }
}
