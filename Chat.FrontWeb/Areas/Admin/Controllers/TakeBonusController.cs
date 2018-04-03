using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.App_Start;
using SDMS.Web.Areas.Admin.Controllers.Base;
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
    public class TakeBonusController : AdminBaseController
    {
        #region 属性注入
        public IShareBonusService shareBonusService { get; set; }
        public ISetShareBonusService setShareBonusService { get; set; }
        public IJournalService journalService { get; set; }
        public IJournalTypeService journalTypeService { get; set; }
        #endregion

        #region 分红设置
        [HttpGet]
        [Permission("分红管理")]        
        public ActionResult SetUp()
        {
            var model= setShareBonusService.GetSet();
            return View(model);
        }
        [HttpPost]
        [Permission("分红管理")]
        [ActDescription("定向分红比例设置")]
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
        [Permission("分红管理")]
        [ActDescription("分红模式设置")]
        public ActionResult SetFlag(bool flag)
        {
            if (!setShareBonusService.Update(flag))
            {
                return Json(new AjaxResult { Status = "0", Msg = "设置定向分红启动暂停失败" });
            }
            if(flag)
            {
                return Json(new AjaxResult { Status = "1", Msg = "启动定向分红成功", Data = "/admin/takebonus/issue" });
            }
            else
            {
                return Json(new AjaxResult { Status = "1", Msg = "暂停定向分红成功", Data = "/admin/takebonus/issue" });
            }
        }
        #endregion

        #region 分红发放
        [HttpGet]
        [Permission("分红管理")]
        public ActionResult Issue()
        {
            var model = setShareBonusService.GetSet();
            return View(model);
        }
        [HttpPost]
        [Permission("分红管理")]
        [ActDescription("平均分红发放")]
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
        [Permission("分红管理")]
        [ActDescription("分红流水列表")]
        public ActionResult BonusJournal()
        {
            var model = journalTypeService.GetByDecription("分红");
            return View(model);
        }
        [Permission("分红管理")]
        public PartialViewResult BonusJournalGetPage(string name, string mobile,long? journalTypeId, DateTime? startTime, DateTime? endTime, int pageIndex = 1)
        {
            if(journalTypeId==0)
            {
                journalTypeId = null;
            }
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
            return PartialView("BonusJournalPaging", model);
        }
        public ActionResult Search(string name, string mobile, long? bonusTypeId, DateTime? year, DateTime? month)
        {
            if(bonusTypeId!=null && bonusTypeId.Value<=0)
            {
                bonusTypeId = null;
            }
            decimal result= journalService.CalcTakeBonus(name, mobile,bonusTypeId, year, month);
            return Json(new AjaxResult { Status = "1", Data = result });
        }
        #endregion
    }
}