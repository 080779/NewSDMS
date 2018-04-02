using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.Controllers.Base;
using SDMS.Web.Models.TakeCash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers
{
    public class TakeCashController : FrontBaseController
    {
        public ITakeCashService takeCashService { get; set; }
        //public IHolderService holderService { get; set; }
        public ActionResult List()
        {
            TakeCashListViewModel model = new TakeCashListViewModel();
            model.TakeCashes= takeCashService.GetByHolderId(UserId);
            model.Holder = holderService.GetById(UserId);
            return View(model);
        }
        [HttpGet]
        public ActionResult Apply()
        {
            var model= holderService.GetById(UserId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Apply(decimal amount)
        {
            if(amount<=0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "提现金额必须大于零" });
            }
            var holder = holderService.GetById(UserId);
            if (amount > holder.TakeBonus)
            {
                return Json(new AjaxResult { Status = "0", Msg = "金额不能大于可提现金额" });
            }
            if (string.IsNullOrEmpty(holder.BankAccount))
            {
                return Json(new AjaxResult { Status = "0",Msg="提现银行卡账号为空，不能提现,请到个人中心完善资料再申请" });
            }            
            takeCashService.Apply(UserId, amount);
            return Json(new AjaxResult { Status = "1" });
        }
    }
}