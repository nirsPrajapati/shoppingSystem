using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class thirdcategoryMaster
    {
        [Key]
        public int thirdCatId { get; set; }
        public string thirdCatName { get; set; }

        public int status { get; set; }

        public int catId { get; set; }
        public int subCatId { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
