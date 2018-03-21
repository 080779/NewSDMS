using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        #region 属性注入

        #endregion

        #region 列表
        public ActionResult List()
        {
            return View();
        }
        public PartialViewResult ListGetPage(int pageIndex = 1)
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
            //return PartialView("HolderListPaging", model);
            return PartialView("HolderListPaging");
        }
        #endregion
    }
}