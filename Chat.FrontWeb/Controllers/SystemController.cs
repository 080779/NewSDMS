using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers
{
    public class SystemController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SetPwd()
        {
            return View();
        }
    }
}