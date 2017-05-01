using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.web.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Aplication
      //[Autorize]
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}