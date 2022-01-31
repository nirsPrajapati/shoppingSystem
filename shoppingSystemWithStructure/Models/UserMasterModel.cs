using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shoppingSystemWithStructure.Models
{
    public class UserMasterModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}