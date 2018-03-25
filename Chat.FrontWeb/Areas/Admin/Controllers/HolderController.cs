using SDMS.Common;
using SDMS.DTO.Model;
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
        public IStockItemService stockService { get; set; }
        #endregion

        #region 列表
        public ActionResult List()
        {
            //stockService.AddNew("股票", "gupn", 1000000, 10000, 5000);
            return View();
        }
        public PartialViewResult ListGetPage(string name,string mobile,DateTime? startTime,DateTime? endTime,int pageIndex = 1)
        {
            int pageSize = 3;
            HolderListViewModel model = new HolderListViewModel();
            HolderSearchResult result = holderService.GetPageList(name,mobile,startTime,endTime,pageIndex, pageSize);
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
        [HttpGet]
        public ActionResult Add()
        {
            long num = stockService.GetById(1).HaveCopies;
            return View(num);
        }
        [HttpPost]
        public ActionResult Add(HolderAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(MVCHelper.GetJsonValidMsg(ModelState));
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "姓名不能为空");
            }
            
            if (model.Amount<=0)
            {
                return Json(new AjaxResult { Status = "0",Msg="认购金额不能为空" });
            }
            HolderSvcModel holder = new HolderSvcModel();
            holder.Amount = model.Amount;
            holder.Gender = model.Gender;
            holder.IdNumber = model.IdNumber;
            holder.Mobile = model.Mobile;
            holder.Name = model.Name;
            holder.Password = model.Password;
            holder.StockItemId = 1;
            holder.Copies = model.Copies;
            long id= holderService.AddNew(holder);
            return Json(new AjaxResult { Status = "1", Data = id });
        }
        #endregion

        #region 修改
        [HttpGet]
        public ActionResult Edit(long id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(long id,string a)
        {
            return Json(new AjaxResult { Status="1"});
        }
        #endregion

        #region 删除
        [HttpPost]
        public ActionResult Del(long id)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion

        #region 统计
        [HttpGet]
        public ActionResult Clac()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Clac(string s)
        {
            return Json(new AjaxResult { Status = "1" });
        }
        #endregion
        #region 确认计算认购金额
        public ActionResult ClacAmount(long copies)
        {
            decimal Copies= holderService.ClacAmount(1, copies);
            return Json(new AjaxResult { Status = "1",Data= Copies });
        }
        #endregion
    }
}