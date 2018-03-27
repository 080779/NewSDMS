using log4net;
using SDMS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Security;

namespace SDMS.Web
{
    public class WeChatController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        private static ILog log = LogManager.GetLogger(typeof(WeChatController));
        // GET api/<controller>/5
        public string Get(string signature, string timestamp, string nonce, string echostr)
        {            
            string token = "ovIaF08df020dsePwPyblyG9G52PiIdre";
            string[] strArr = { token, timestamp, nonce };
            Array.Sort(strArr);
            string tmpStr = string.Join("", strArr);
            //string sign = CommonHelper.SHA1(tmpStr, Encoding.UTF8);
            string sign= FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            //if (sign.ToLower() != signature)
            //{
            //    //HttpContext.Current.Response.Write(echoStr);
            //    return "error";
            //}
            return signature+"/"+ timestamp +"/"+ nonce +"/"+ echostr;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}