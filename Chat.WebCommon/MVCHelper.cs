using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SDMS.Common
{
    public static class MVCHelper
    {
        #region 属性验证
        /// <summary>
        /// mvc中model属性验证
        /// </summary>
        public static string GetValidMsg(ModelStateDictionary modelSatae)
        {
            StringBuilder builer = new StringBuilder();
            foreach (var propName in modelSatae.Keys)
            {
                if (modelSatae[propName].Errors.Count <= 0)
                {
                    continue;
                }
                builer.Append("数据验证失败：");
                foreach (ModelError modelError in modelSatae[propName].Errors)
                {
                    builer.Append(modelError.ErrorMessage+"......");
                }
            }
            return builer.ToString();
        }
        public static AjaxResult GetJsonValidMsg(ModelStateDictionary modelSatae)
        {
            AjaxResult result = new AjaxResult();
            result.Status = "0";
            foreach (var propName in modelSatae.Keys)
            {
                if (modelSatae[propName].Errors.Count <= 0)
                {
                    continue;
                }
                foreach (ModelError modelError in modelSatae[propName].Errors)
                {
                    result.Msg = modelError.ErrorMessage;
                    return result;
                }
            }
            return result;
        }
        #endregion

        #region 页面静态化
        public static string RenderViewToString(ControllerContext context,string viewPath,object model = null)
        {
            ViewEngineResult viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, null);
            if (viewEngineResult == null)
                throw new FileNotFoundException("View" + viewPath + "cannot be found.");

            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view,context.Controller.ViewData,context.Controller.TempData,sw);
                view.Render(ctx, sw);
                return sw.ToString();
            }
        }
        #endregion

        #region 获取客户端IP地址  

        public static string GetWebClientIp()
        {
            string userIP = "未获取用户IP";
            try
            {
                if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Request == null || System.Web.HttpContext.Current.Request.ServerVariables == null)
                {
                    return "";
                }
                string CustomerIP = "";
                //CDN加速后取到的IP simone 090805
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }
                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!String.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                    {
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (string.Compare(CustomerIP, "unknown", true) == 0 || String.IsNullOrEmpty(CustomerIP))
                {
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                }
                return CustomerIP;
            }
            catch { }
            return userIP;
        }

        #endregion

        #region Cookie
        /// <summary>
        /// 用户登陆cookie
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="roles">权限</param>
        /// <param name="isPersistent">输入true时，Cookies存在的时间是一个月！输入false时，Cookies存在时间是一小时</param>
        public static void LoginCookie(string username, string roles, bool isPersistent)
        {
            DateTime dt = isPersistent ? DateTime.Now.AddDays(30) : DateTime.Now.AddMinutes(60);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, // 票据版本号
                                                                                username, // 票据持有者
                                                                                DateTime.Now, //分配票据的时间
                                                                                dt, // 失效时间
                                                                                isPersistent, // 需要用户的 cookie 
                                                                                roles, // 用户数据，这里其实就是用户的角色
                                                                                FormsAuthentication.FormsCookiePath);//cookie有效路径

            //使用机器码machine key加密cookie，为了安全传送
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash); //加密之后的cookie
            //将cookie的失效时间设置为和票据tikets的失效时间一致 
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            //添加cookie到页面请求响应中
            HttpContext.Current.Response.Cookies.Add(cookie);
        }        
        #endregion
    }
}
