using BAL.Service;
using DAL.Entity;
using shoppingSystemWithStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoppingSystemWithStructure.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult SubCategory()
        {
            return View();
        }
        public ActionResult thirdCategory()
        {
            return View();
        }
        public ActionResult product()
        {
            return View();
        }

        public ActionResult productList()
        {
            return View();
        }

    }
}