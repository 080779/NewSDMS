using SDMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 项目管理
    /// </summary>
    public class StockItemController : Controller
    {
        #region 属性注入

        #endregion

        #region 列表
        public ActionResult SetUp()
        {
            return View();
        }
        public ActionResult SetUp(string s)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion
    }
}