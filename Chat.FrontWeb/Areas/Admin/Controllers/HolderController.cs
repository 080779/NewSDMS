using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.Areas.Admin.Controllers.Base;
using SDMS.Web.Areas.Admin.Models.Holder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 股东管理
    /// </summary>
    public class HolderController : AdminBaseController
    {
        #region 属性注入
        public IHolderService holderService { get; set; }
        #endregion

        #region 列表
        public ActionResult List()
        {
            return View();
        }
        public PartialViewResult ListGetPage(int pageIndex = 1)
        {
            int pageSize = 3;
            HolderListViewModel model = new HolderListViewModel();
            HolderSearchResult result = holderService.GetPageList(pageIndex, pageSize);
            model.Holders = result.Holders;

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
        public ActionResult Edit(long id,string a)
        {
            return Json(new AjaxResult { Status="1"});
        }
        #endregion

        #region 删除
        public ActionResult Del(long id)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 统计
        public ActionResult Clac()
        {
            return View();
        }
        public ActionResult Clac(string s)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion
    }
}