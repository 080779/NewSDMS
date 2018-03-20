using CaptchaGen;
using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CtrTemp.SDMS.Web.Controllers
{
    public class UserController : Controller
    {
        public IUserService userService { get; set; }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string usercode, string password,string verifyCode)
        {
            if (string.IsNullOrEmpty(usercode))
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
            if (verifyCode != (string)TempData["verifyCode"])
            {
                return Json(new AjaxResult { Status = "0", Msg = "验证码错误" });
            }
            long result = userService.CheckLogin(usercode, CommonHelper.GetMD5(password.Trim()));
            if (result <=0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "账户名或密码不正确" });
            }

            MVCHelper.LoginCookie(usercode, "A128076_user", false);
            HttpCookie UserCookie = new HttpCookie("A128076_user");
            UserCookie["ID"] = result.ToString();
            UserCookie["Name"] = usercode;
            Response.AppendCookie(UserCookie);

            return Json(new AjaxResult { Status = "1", Data = "/home/index" });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            if(Request.Cookies["A128076_user"]!=null)
            {
                Request.Cookies["A128076_user"].Expires = DateTime.Now.AddDays(-2);
                Response.Cookies.Set(Request.Cookies["A128076_user"]);
            }            
            return Redirect("/user/login");
        }

        public ActionResult CreateVerifyCode()
        {
            string verifyCode = CommonHelper.GetCaptcha(4);
            TempData["verifyCode"] = verifyCode;
            ImageFactory.BackgroundColor = Color.YellowGreen;
            MemoryStream ms = ImageFactory.GenerateImage(verifyCode,55,85,20,0);
            byte[] bytes = CommonHelper.CaptureImage(ms, 5, 17, 80, 38);
            return File(bytes, "image/jpeg");
        }
    }
}