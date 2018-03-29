using SDMS.Common;
using SDMS.IService.Interface;
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
        public IShareBonusService shareBonusService { get; set; }
        #endregion

        #region 分红设置
        [HttpGet]
        public ActionResult SetUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetUp(string s)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 分红发放
        [HttpGet]
        public ActionResult Issue()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Issue(decimal amount)
        {
            shareBonusService.Average(amount);
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