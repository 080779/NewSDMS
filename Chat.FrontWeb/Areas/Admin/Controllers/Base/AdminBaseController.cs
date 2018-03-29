using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDMS.Web.App_Start;

namespace SDMS.Web.Areas.Admin.Controllers.Base
{
    /// <summary>
    /// 后台公共基类，验证是否登录
    /// </summary>
    public class AdminBaseController : Controller
    {
        public IAdminService adminService { get; set; }
        public IPermissionService permissionService { get; set; }
        public IAdminLogService logService { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["AdminId"] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())//判断是否是ajax请求
                {
                    filterContext.Result = new JsonNetResult { Data = new AjaxResult { Status = "0", Msg = "登录信息已经过期，请刷新重新登录！", Data = "/admin/manager/login" } };
                }
                else
                {
                    filterContext.Result = new RedirectResult("/admin/manager/login");
                }
            }
            else
            {
                PermissionAttribute[] attributes = (PermissionAttribute[])filterContext.ActionDescriptor.GetCustomAttributes(typeof(PermissionAttribute), false);
                long id = Convert.ToInt64(Session["AdminId"]);
                if (attributes.Length > 0)                {
                    
                    foreach (var attr in attributes)
                    {
                        if (!adminService.HasPermission(id, attr.Permission))
                        {
                            if (filterContext.HttpContext.Request.IsAjaxRequest())
                            {
                                filterContext.Result = new JsonNetResult { Data = new AjaxResult { Status = "0", Msg = "没有" + permissionService.GetByName(attr.Permission) + "这个权限" } };
                            }
                            else
                            {
                                filterContext.Result = new RedirectResult("/admin/manager/tips?message=" + "没有" + permissionService.GetByName(attr.Permission) + "这个权限");
                            }
                        }
                    }
                }
                object[] attrs = filterContext.ActionDescriptor.GetCustomAttributes(typeof(ActDescriptionAttribute), false);
                if (attrs.Length > 0)
                {
                    string ipAddress = MVCHelper.GetWebClientIp();
                    string funDescribe = ((ActDescriptionAttribute)attrs[0]).ActDescription;
                    logService.AddNew(id, ipAddress, "访问执行了" + funDescribe);
                }
            }            
            
            base.OnActionExecuting(filterContext);
        }
        
    }
}