using SDMS.Web.Controllers.Base;
using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CtrTemp.SDMS.Web.Controllers
{
    public class HomeController : FrontBaseController
    {
        public ICityService cityService { get; set; }
        public ILoginService loginService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
    }
}