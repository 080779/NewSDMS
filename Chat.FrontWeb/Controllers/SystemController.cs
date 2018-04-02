using SDMS.Common;
using SDMS.IService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers
{
    public class SystemController : Controller
    {
        public ISettingsService settingsService { get; set; }
        public IHolderService holderService { get; set; }
        [HttpGet]
        public ActionResult Login()
        {
            var tel= settingsService.GetValueByKey("tel");
            return View((object)tel);
        }
        [HttpPost]
        public ActionResult Login(string mobile,string password)
        {
            if(string.IsNullOrEmpty(mobile))
            {
                return Json(new AjaxResult { Status = "0", Msg = "手机号不能为空" });
            }
            long num;
            if(!long.TryParse(mobile,out num))
            {
                return Json(new AjaxResult { Status = "0", Msg = "手机号必须是数字" });
            }
            if(mobile.Length!=11)
            {
                return Json(new AjaxResult { Status = "0", Msg = "手机号必须是11位" });
            }
            if(string.IsNullOrEmpty(password))
            {
                return Json(new AjaxResult { Status = "0", Msg = "密码不能为空" });
            }
            if(Session["OpenId"]==null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "redirct", Data = "/home/index" });
            }
            long id = holderService.Login(mobile, password, Session["OpenId"].ToString());
            if (id <= 0)
            {
                if(id==-3)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "该手机号已被其他微信用户绑定" });
                }
                return Json(new AjaxResult { Status = "0", Msg = "手机号或密码错误" });
            }
            Session["UserId"] = id;
            return Json(new AjaxResult { Status = "1", Data = "/home/index" });
        }
        public ActionResult Logout()
        {
            Session["UserId"] = null;
            return Redirect("/home/index");
        }
    }
}