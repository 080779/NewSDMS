using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.Areas.Admin.Models;
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
        public IStockItemService stockItemService { get; set; }
        #endregion

        #region 列表
        [HttpGet]
        public ActionResult SetUp()
        {
            var model= stockItemService.GetById(1);
            return View(model);
        }
        [HttpPost]
        public ActionResult SetUp(StockItemModel model)
        {
            if(!stockItemService.Update(model.Id,model.Name,model.Description,model.TotalAmount,model.TotalCopies,model.IssueCopies))
            {
                return Json(new AjaxResult { Status = "0", Msg = "更新失败" });
            }
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion
    }
}