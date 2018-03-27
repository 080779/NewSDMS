using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChat.Controllers
{
    public class WeChatController : Controller
    {
        private static readonly string Token = "weixin";
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            //RequestUtility.SetHttpProxy("http://localhost", "52399", "username", "pwd");
            if (CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + signature + "," + Senparc.Weixin.MP.CheckSignature.GetSignature(timestamp, nonce, Token) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
        }
    }
}