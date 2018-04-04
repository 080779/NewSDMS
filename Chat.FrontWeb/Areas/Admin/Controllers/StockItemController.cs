using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.App_Start;
using SDMS.Web.Areas.Admin.Controllers.Base;
using SDMS.Web.Areas.Admin.Models;
using System.Web.Mvc;
using Model.IsValid;

namespace SDMS.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 项目管理
    /// </summary>
    public class StockItemController : AdminBaseController
    //public class StockItemController : Controller
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
            if(string.IsNullOrEmpty(model.Name))
            {
                return Json(new AjaxResult { Status = "0", Msg = "项目名不能为空" });
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                return Json(new AjaxResult { Status = "0", Msg = "项目描述不能为空" });
            }
            decimal totalAmount;
            if (!decimal.TryParse(model.TotalAmount,out totalAmount))
            {
                return Json(new AjaxResult { Status = "0", Msg = "项目总金额必须是数字" });
            }
            if(totalAmount<=0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "项目总金额必须是大于零" });
            }
            long totalCopies;
            if(!long.TryParse(model.TotalCopies,out totalCopies))
            {
                return Json(new AjaxResult { Status = "0", Msg = "项目总份数必须是正数" });
            }
            if(totalCopies<=0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "项目总份数必须大于零" });
            }
            long issueCopies;
            if (!long.TryParse(model.IssueCopies,out issueCopies))
            {
                return Json(new AjaxResult { Status = "0", Msg = "发行总份数必须是正数" });
            }
            if (issueCopies <= 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "发行总份数必须大于零" });
            }
            if(issueCopies>totalCopies)
            {
                return Json(new AjaxResult { Status = "0", Msg = "发行份数不能大于项目总份数" });
            }
            if (!stockItemService.Update(model.Id,model.Name,model.Description,totalAmount, totalCopies, issueCopies))
            {
                return Json(new AjaxResult { Status = "0", Msg = "设置失败" });
            }
            return Json(new AjaxResult { Status = "1",Data="/admin/stockitem/setup" });
        }
        #endregion
    }
}