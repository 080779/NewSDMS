using SDMS.Common;
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

        #endregion

        #region 提现申请管理
        //申请列表
        public ActionResult Apply()
        {
            return View();
        }
        public PartialViewResult ApplyGetPage(int pageIndex = 1)
        {
            //int pageSize = 3;
            //AdminListViewModel model = new AdminListViewModel();
            //AdminSearchResult result = adminService.GetPageList(pageIndex, pageSize);
            //model.AdminList = result.AdminList;

            ////分页
            //Pagination pager = new Pagination();
            //pager.PageIndex = pageIndex;
            //pager.PageSize = pageSize;
            //pager.TotalCount = result.TotalCount;

            //if (result.TotalCount <= pageSize)
            //{
            //    model.Page = "";
            //}
            //else
            //{
            //    model.Page = pager.GetPagerHtml();
            //}
            //return PartialView("TakeCashApplyPaging", model);
            return PartialView("TakeCashApplyPaging");
        }

        //确认申请
        public ActionResult Confirm()
        {
            return View();
        }
        public ActionResult Confirm(string s)
        {
            return Json(new AjaxResult { Status = "1" });
        }

        //驳回
        public ActionResult Reject()
        {
            return View();
        }
        public ActionResult Reject(string s)
        {
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