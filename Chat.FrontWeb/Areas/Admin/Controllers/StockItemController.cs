using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.App_Start;
using SDMS.Web.Areas.Admin.Controllers.Base;
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
    public class StockItemController : AdminBaseController
    {
        #region 属性注入
        public IStockItemService stockItemService { get; set; }
        private static readonly string KeyName = "project";
        #endregion

        #region 列表
        [HttpGet]
        [Permission("项目管理")]
        public ActionResult SetUp()
        {
            var model= stockItemService.GetByKeyName(KeyName);
            return View(model);
        }
        [HttpPost]
        [Permission("项目管理")]
        [ActDescription("股票项目设置")]
        public ActionResult SetUp(StockItemModel model)
        {
            if(!stockItemService.Update(model.Id,model.Name,model.Description,model.TotalAmount,model.TotalCopies,model.IssueCopies))
            {
                return Json(new AjaxResult { Status = "0", Msg = "设置失败" });
            }
            return Json(new AjaxResult { Status = "1",Data="/admin/stockitem/setup" });
        }
        #endregion
    }
}