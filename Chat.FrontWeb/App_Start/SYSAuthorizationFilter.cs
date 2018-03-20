using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.App_Start
{
    public class SYSAuthorizationFilter : IAuthorizationFilter
    {
        public IAdminService adminUserService = DependencyResolver.Current.GetService<IAdminService>();
        public IPermissionService permissionService = DependencyResolver.Current.GetService<IPermissionService>();
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var v = filterContext.HttpContext.Request.Url;
            PermissionAttribute[] attributes = (PermissionAttribute[])filterContext.ActionDescriptor.GetCustomAttributes(typeof(PermissionAttribute), false);            
            
            long? adminUserId = (long?)filterContext.HttpContext.Session["AdminUserId"];
            //if (adminUserId == null)
            //{
            //    if(filterContext.ActionDescriptor.IsDefined(typeof(NoPermissionAttribute), true))
            //    {
            //        return;
            //    }
            //    if (filterContext.HttpContext.Request.IsAjaxRequest())//判断是否是ajax请求
            //    {
            //        filterContext.Result = new JsonNetResult { Data = new AjaxResult { Status = "redirect", Data = "/Home/Login" } };
            //    }
            //    else
            //    {
            //        filterContext.Result = new RedirectResult("/admin/home/login");
            //    }
            //    return;
            //}

            if (attributes.Length <= 0)
            {
                return; //如果没有权限检查的attribute就返回，不进行后面的判断
            }
                        
            foreach (var attr in attributes)
            {
                if (!adminUserService.HasPermission(adminUserId.Value, attr.Permission))
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new JsonNetResult { Data = new AjaxResult { Status = "0", Msg = "没有" + permissionService.GetByName(attr.Permission) + "这个权限" } };
                    }
                    else
                    {
                        //filterContext.Result = new ContentResult() { Content = "没有" + permissionService.GetByName(attr.Permission).Description + "这个权限" };
                        filterContext.Result = new RedirectResult("/admin/home/tips?message=" + "没有" + permissionService.GetByName(attr.Permission) + "这个权限");
                    }
                    return;
                }
            }
        }
    }
}