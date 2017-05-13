using SocialNetwork.web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.web.Controllers
{
    [Authentication]
    public class ApplicationController : Controller
    {
        // GET: Aplication
        
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}