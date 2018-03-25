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
    /// 公告管理
    /// </summary>
    public class NewsController : Controller
    {
        #region 属性注入
        public INewsService newService { get; set; }
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
            //return PartialView("NewsListPaging", model);
            return PartialView("NewsListPaging");
        }
        #endregion

        #region 添加
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string a)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 修改
        [HttpGet]
        public ActionResult Edit(long id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(long id, string a)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 删除
        [HttpPost]
        public ActionResult Del(long id)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion
    }
}