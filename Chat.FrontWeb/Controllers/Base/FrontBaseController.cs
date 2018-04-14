using SDMS.DTO.DTO;
using SDMS.IService.Interface;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;
using System.Net;
using System.Net.Http;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;

namespace SDMS.Web.Controllers.Base
{
    /// <summary>
    /// 前台公共基类，验证是否登录
    /// </summary>
    public class FrontBaseController : Controller
    {
        public IHolderService holderService { get; set; }
        private string appId = "wx4bb5e170640ca437";
        //private string appId = "wx4bb5e170640ca437";
        private string secret = "52622a0a4078040b94d502a145a7b6a7";
        public long UserId;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserId"] == null)
            {
                if (Session["OpenId"] != null)
                {
                    if (!holderService.CheckOpenId(Session["OpenId"].ToString()))
                    {
                        if (filterContext.HttpContext.Request.IsAjaxRequest())//判断是否是ajax请求
                        {
                            filterContext.Result = new JsonNetResult { Data = new AjaxResult { Status = "0", Msg = "绑定信息不匹配", Data = "/user/login" } };
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult("/system/login");
                        }
                    }                    
                }
                else
                {
                    if (Request["code"] == null)
                    {
                        var state = "vz-" + DateTime.Now.Millisecond;//随机数，用于识别请求可靠性
                        Session["State"] = state;//储存随机数到Session
                        string url = OAuthApi.GetAuthorizeUrl(appId, "http://x4xbtj.natappfree.cc/home/index", state, OAuthScope.snsapi_userinfo);
                        filterContext.Result = new RedirectResult(url);
                    }
                    else
                    {
                        OAuthAccessTokenResult result = null;
                        result = OAuthApi.GetAccessToken(appId, secret, Request["code"].ToString());
                        Session["OpenId"] = result.openid;
                        var userInfo= OAuthApi.GetUserInfo(result.access_token, result.openid, Senparc.Weixin.Language.zh_CN);
                        Session["HeadImgUrl"] = userInfo.headimgurl;
                        if (holderService.GetHoderIdByOpenId(result.openid) <= 0)
                        {
                            if (filterContext.HttpContext.Request.IsAjaxRequest())//判断是否是ajax请求
                            {
                                filterContext.Result = new JsonNetResult { Data = new AjaxResult { Status = "0", Msg = "登录信息已经过期，请刷新重新登录！", Data = "/user/login" } };
                            }
                            else
                            {
                                filterContext.Result = new RedirectResult("/system/login");
                            }
                        }
                        else
                        {                           
                            Session["UserId"] = holderService.GetHoderIdByOpenId(result.openid);
                        }
                    }
                }
            }
            else
            {
                if(Session["UserId"]==null)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())//判断是否是ajax请求
                    {
                        filterContext.Result = new JsonNetResult { Data = new AjaxResult { Status = "0", Msg = "登录信息已经过期，请刷新重新登录！", Data = "/user/login" } };
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("/system/login");
                    }
                }
                UserId = Convert.ToInt64(Session["UserId"]);
            }            
            base.OnActionExecuting(filterContext);
        }
    }
}