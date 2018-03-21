using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers.Base
{
    /// <summary>
    /// 前台公共基类，验证是否登录
    /// </summary>
    public class FrontBaseController : Controller
    {
        public int pageIndex = 1;
        public int pageSize = 5;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies["A128076_user"] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())//判断是否是ajax请求
                {
                    filterContext.Result = new JsonNetResult { Data = new AjaxResult { Status = "0", Msg = "登录信息已经过期，请刷新重新登录！", Data = "/user/login" } };
                }
                else
                {
                    filterContext.Result = new RedirectResult("/user/login");
                }
            }
            if (Request.Params["pageIndex"] != null)
            {
                pageIndex = Convert.ToInt32(Request.Params["pageIndex"]);
            }
            if (Request.Params["pageSize"] != null)
            {
                pageSize = Convert.ToInt32(Request.Params["pageSize"]);
            }
            base.OnActionExecuting(filterContext);
        }

        public long GetLoginID()
        {
            if (HttpContext.Request.Cookies["A128076_user"] != null)
            {
                return Convert.ToInt32(HttpContext.Request.Cookies["A128076_user"]["ID"]);
            }
            else
            {
                return 0;
            }
        }
    }
}