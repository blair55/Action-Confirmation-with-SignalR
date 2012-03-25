using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatIsSignalR.Ui.Mvc.Actions;

namespace WhatIsSignalR.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Actions = ActionFactory.GetActions();

            return View();
        }
    }
}
