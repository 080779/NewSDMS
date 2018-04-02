using SDMS.Common;
using SDMS.DTO.Model;
using SDMS.IService.Interface;
using SDMS.Web.App_Start;
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
        private static readonly string KeyName = "project";
        #endregion

        #region 列表
        [Permission("股东管理")]
        [ActDescription("股东管理列表")]
        public ActionResult List()
        {
            //stockService.AddNew("股票", "gupn", 1000000, 10000, 5000);
            var model= holderService.CalcNumber();
            return View(model);
        }
        [Permission("股东管理")]
        public PartialViewResult ListGetPage(string name,string mobile,DateTime? startTime,DateTime? endTime,int pageIndex = 1)
        {
            int pageSize = 10;
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
        [Permission("股东管理")]
        [HttpGet]
        public ActionResult Add()
        {
            long num = stockService.GetByKeyName(KeyName).HaveCopies;
            return View(num);
        }
        [HttpPost]
        [ActDescription("股东添加")]
        [Permission("股东管理")]
        public ActionResult Add(HolderAddModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                return Json(new AjaxResult { Status = "0", Msg = "股东名不能为空" });
            }
            if(string.IsNullOrEmpty(model.Mobile))
            {
                return Json(new AjaxResult { Status = "0", Msg = "股东手机号不能为空" });
            }
            if(model.Mobile.Length!=11)
            {
                long num;
                if (!long.TryParse(model.Mobile, out num))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "股东手机号必须是数字" });
                }
                
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
            holder.StockItemId = stockService.GetIdByKeyName(KeyName);
            holder.Copies = model.Copies;
            long id= holderService.AddNew(holder);
            if(id<=0)
            {
                if(id==-2)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "手机号码已经存在" });
                }
                return Json(new AjaxResult { Status = "0", Msg = "添加股东失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/holder/list" });
        }
        #endregion

        #region 修改
        [HttpGet]
        [Permission("股东管理")]
        [ActDescription("股东编辑")]
        public ActionResult Edit(long id)
        {
            var model= holderService.GetById(id);
            return View(model);
        }
        [HttpPost]
        [Permission("股东管理")]
        public ActionResult Edit(HolderEditModel model)
        {
            if(!holderService.Update(model.Id, model.Name, model.Mobile, model.Gender, model.IdNumber, model.Contact))
            {
                return Json(new AjaxResult { Status = "0", Msg = "编辑股东失败" });
            }
            return Json(new AjaxResult { Status="1",Data="/admin/holder/list"});
        }
        #endregion

        #region 删除
        [HttpPost]
        [Permission("股东管理")]
        [ActDescription("股东删除")]
        public ActionResult Del(long id)
        {
            if(!holderService.Delete(id))
            {
                return Json(new AjaxResult { Status = "0", Msg = "删除失败" });
            }
            return Json(new AjaxResult { Status = "1", Data = "/admin/holder/list" });
        }
        #endregion
        #region 确认计算认购金额
        [Permission("股东管理")]
        public ActionResult ClacAmount(long copies)
        {
            decimal Copies= holderService.ClacAmount(stockService.GetIdByKeyName(KeyName), copies);
            return Json(new AjaxResult { Status = "1",Data= Copies });
        }
        #endregion
    }
}