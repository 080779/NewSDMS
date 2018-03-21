using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 分红管理
    /// </summary>
    public class TakeBonusController : Controller
    {
        #region 属性注入

        #endregion

        #region 分红设置
        public ActionResult SetUp()
        {
            return View();
        }
        public ActionResult SetUp(string s)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 分红发放
        public ActionResult Issue()
        {
            return View();
        }
        public ActionResult Issue(string s)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 分红统计
        public ActionResult Clac()
        {
            return View();
        }
        public ActionResult Clac(string s)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion
    }
}