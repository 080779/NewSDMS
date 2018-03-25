using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public INewsService newsService { get; set; }
        public ActionResult Index()
        {
            var model = newsService.GetPageList(null, null, null, 1, 3);
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Message()
        {
            return View();
        }
        public ActionResult Share()
        {
            return View();
        }
    }
}