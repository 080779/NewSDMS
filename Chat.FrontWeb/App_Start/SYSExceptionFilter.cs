using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.App_Start
{
    public class SYSExceptionFilter : IExceptionFilter
    {
        private static ILog log = LogManager.GetLogger(typeof(SYSExceptionFilter));
        public void OnException(ExceptionContext filterContext)
        {
            log.ErrorFormat("出现未处理异常：{0}",filterContext.Exception);
        }
    }
}