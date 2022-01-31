using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shoppingSystemWithStructure.Models
{
    public class categoryMasterModel
    {
   
        public int catId { get; set; }
        [Required (ErrorMessage ="Enter Category")]
        public string catName { get; set; }
        [Required(ErrorMessage = "Select Category")]
        public int status { get; set; }
    }
}