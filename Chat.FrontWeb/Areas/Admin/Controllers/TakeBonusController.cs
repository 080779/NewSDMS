using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.Areas.Admin.Models.TakeBonus;
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
        public ISetShareBonusService setShareBonusService { get; set; }
        public IJournalService journalService { get; set; }
        #endregion

        #region 分红设置
        [HttpGet]
        public ActionResult SetUp()
        {
            var model= setShareBonusService.GetSet();
            return View(model);
        }
        [HttpPost]
        public ActionResult SetUp(SetUpModel model)
        {
            if(!ModelState.IsValid)
            {
                return Json(MVCHelper.GetJsonValidMsg(ModelState));
            }
            if(model.Rate<=0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "比例不能小于零" });
            }
            if(!setShareBonusService.Update(model.Rate))
            {
                return Json(new AjaxResult { Status = "0" ,Msg="设置定向分红比例失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/takebonus/setup" });
        }
        [HttpPost]
        public ActionResult SetFlag(bool flag)
        {
            if (!setShareBonusService.Update(flag))
            {
                return Json(new AjaxResult { Status = "0", Msg = "设置分红模式失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/takebonus/setup" });
        }
        #endregion

        #region 分红发放
        [HttpGet]
        public ActionResult Issue()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Issue(IssueModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(MVCHelper.GetJsonValidMsg(ModelState));
            }
            if (model.Amount <= 0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "金额不能小于零" });
            }
            if (!shareBonusService.Average(model.Amount))
            {
                return Json(new AjaxResult { Status = "0", Msg = "分红发放失败" });
            }
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 分红流水统计
        public ActionResult BonusJournal()
        {
            return View();
        }
        public PartialViewResult BonusJournalGetPage(string name, string mobile,long? journalTypeId, DateTime? startTime, DateTime? endTime, int pageIndex = 1)
        {
            int pageSize = 3;
            BonusJournalViewModel model = new BonusJournalViewModel();
            JournalPageResult result = journalService.GetPageList(null,mobile,name,"分红",journalTypeId,startTime,endTime,pageIndex,pageSize);
            model.Journals = result.Journals;

            //分页
            Pagination pager = new Pagination();
            pager.PageIndex = pageIndex;
            pager.PageSize = pageSize;
            pager.TotalCount = result.TotalCount;

            if (result.TotalCount <= pageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return PartialView("HolderListPaging", model);
        }
        #endregion
    }
}