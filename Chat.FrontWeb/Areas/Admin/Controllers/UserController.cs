using CaptchaGen;
using SDMS.Web.Areas.Admin.Models;
using SDMS.Web.Areas.Admin.Models.User;
using SDMS.IService.Interface;
using SDMS.Service.Service;
using SDMS.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SDMS.Web.Areas.Admin.Controllers
{
   
    public class UserController: Controller
    {
        public IAdminService AdminService { get; set; }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password,string verifyCode)
        {
            if(string.IsNullOrEmpty(username))
            {
                return Json(new AjaxResult { Status = "0", Msg = "账户名不能为空" });
            }
            if (string.IsNullOrEmpty(password))
            {
                return Json(new AjaxResult { Status = "0", Msg = "密码不能为空" });
            }
            if (string.IsNullOrEmpty(verifyCode))
            {
                return Json(new AjaxResult { Status = "0", Msg = "验证码不能为空" });
            }
            if (verifyCode != (string)TempData["AdminVerifyCode"])
            {
                return Json(new AjaxResult { Status = "0", Msg = "验证码错误" });
            }
            long result = AdminService.CheckLogin(username, password);
            if (result <= 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "账户名或密码不正确" });
            }

            long id = AdminService.GetIdByName(username);
            MVCHelper.LoginCookie(username, "A128076_admin", false);
            HttpCookie UserCookie = new HttpCookie("A128076_admin");
            UserCookie["ID"] = id.ToString();
            UserCookie["Name"] = username;
            Response.AppendCookie(UserCookie);

            return Json(new AjaxResult { Status = "1", Data = "/admin/home/index" });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            if(Request.Cookies["A128076_admin"]!=null)
            {
                Request.Cookies["A128076_admin"].Expires = DateTime.Now.AddDays(-2);
                Response.Cookies.Set(Request.Cookies["A128076_admin"]);
            }            
            return Redirect("/admin/user/login");
        }

        public ActionResult CreateVerifyCode()
        {
            string verifyCode = CommonHelper.GetCaptcha(4);
            TempData["AdminVerifyCode"] = verifyCode;
            ImageFactory.BackgroundColor = Color.White;
            MemoryStream ms = ImageFactory.GenerateImage(verifyCode, 55, 78, 18, 0);
            byte[] bytes= CommonHelper.CaptureImage(ms, 10, 17, 65, 38);
            return File(bytes, "image/jpeg");
        }
    }
}