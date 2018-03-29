using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.Areas.Admin.Models.TakeCash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 提现管理
    /// </summary>
    public class TakeCashController : Controller
    {
        #region 属性注入
        public ITakeCashService takeCashService { get; set; }
        #endregion

        #region 提现申请管理
        //申请列表
        public ActionResult Apply()
        {
            return View();
        }
        public PartialViewResult ApplyGetPage(string name,string mobile,DateTime? startTime,DateTime? endTime,int pageIndex = 1)
        {
            int pageSize = 3;
            TakeCashViewModel model = new TakeCashViewModel();
            TakeCashSearchResult result = takeCashService.GetPageList(name,mobile,startTime,endTime,pageIndex, pageSize);
            model.TakeCashes = result.TakeCashs;

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
            return PartialView("TakeCashApplyPaging", model);
        }

        //确认申请
        public ActionResult Confirm(long id)
        {
            return View(id);
        }
        public ActionResult Confirm(long id,string imgUrl)
        {
            takeCashService.Confirm(id, imgUrl);
            return Json(new AjaxResult { Status = "1" });
        }

        //驳回
        public ActionResult Reject(long id)
        {            
            return View(id);
        }
        public ActionResult Reject(long id,string message)
        {
            takeCashService.Reject(id, message);
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 提现统计
        public ActionResult Clac()
        {
            return View();
        }
        public ActionResult Clac(string s)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 提现设置
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