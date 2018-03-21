﻿using SDMS.Common;
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
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Add(string a)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 修改
        public ActionResult Edit(long id)
        {
            return View();
        }
        public ActionResult Edit(long id, string a)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 删除
        public ActionResult Del(long id)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion
    }
}