using SDMS.Common;
using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    public class ManagerController : Controller
    {
        public IAdminService adminService { get; set; }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name,string password)
        {
            if(string .IsNullOrEmpty(name))
            {
                return Json(new AjaxResult { Status = "0", Msg = "用户名不能为空" });
            }
            if (string.IsNullOrEmpty(password))
            {
                return Json(new AjaxResult { Status = "0", Msg = "用户密码不能为空" });
            }
            long id= adminService.CheckLogin(name, password);
            if(id<=0)
            {
                return Json(new AjaxResult { Status = "0",Msg="用户名或密码错误" });
            }
            Session["AdminId"] = id;
            return Json(new AjaxResult { Status="1",Data="/admin/home/index"});
        }

        public ActionResult Logout()
        {
            Session["AdminId"] = null;
            return Redirect("/admin/manager/login");
        }

        public ActionResult Tips(string message)
        {
            return View((object)message);
        }
    }
}