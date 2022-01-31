using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoppingSystemWithStructure.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult productDetails()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult addresses()
        {
            return View();
        }

        public ActionResult AddNewAddress()
        {
            return View();
        }
    }
}