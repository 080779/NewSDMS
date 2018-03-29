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
            if(Session["OpenId"]==null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "redirct", Data = "/home/index" });
            }
            long id = holderService.Login(mobile, password, Session["OpenId"].ToString());
            if (id <= 0)
            {
                if(id==-3)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "已绑定微信用户" });
                }
                return Json(new AjaxResult { Status = "0", Msg = "手机号或密码错误" });
            }
            Session["UserId"] = id;
            return Json(new AjaxResult { Status = "1", Data = "/home/index" });
        }
        [HttpGet]
        public ActionResult SetPwd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetPwd(long id,string oldTradePwd,string tradePwd)
        {
            return Json(new AjaxResult { Status = "1", Data = "/home/index" });
        }
    }
}