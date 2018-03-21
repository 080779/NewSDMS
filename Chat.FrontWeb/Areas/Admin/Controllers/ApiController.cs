using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    public class ApiController : Controller
    {
        //todo:JournalType增删改查接口
        public ActionResult JTList()
        {
            return Json(new AjaxResult { Status = "1" });
        }
        public ActionResult JTAdd(string name, string description)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        public ActionResult JTUpdate(long id,string name,string description)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        public ActionResult JTDel(long id)
        {
            return Json(new AjaxResult { Status = "1" });
        }
    }
}