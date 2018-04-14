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
        public ISettingsService settingsService { get; set; }
        //public IHolderService holderService { get; set; }
        public ActionResult List()
        {
            double takeCashDay = Convert.ToDouble(settingsService.GetValueByKey("takecashtime"));
            TakeCashListViewModel model = new TakeCashListViewModel();
            model.TakeCashes= takeCashService.GetByHolderId(UserId);
            model.Holder = holderService.GetById(UserId);
            if (model.Holder == null)
            {
                Session["UserId"] = null;
                Session["OpenId"] = null;
                Session["HeadImgUrl"] = null;
                return Redirect("/home/index");
            }
            if (model.Holder.TakeCashTime != model.Holder.CreateTime.AddDays(takeCashDay))
            {
                model.Holder.TakeCashTime = model.Holder.CreateTime.AddDays(takeCashDay);
                holderService.Update(UserId, model.Holder.TakeCashTime);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Apply()
        {
            TakeCashApplyViewModel model = new TakeCashApplyViewModel();
            model.Holder= holderService.GetById(UserId);
            if (model.Holder == null)
            {
                Session["UserId"] = null;
                Session["OpenId"] = null;
                Session["HeadImgUrl"] = null;
                return Redirect("/home/index");
            }
            model.MinTakeCash= Convert.ToDecimal(settingsService.GetValueByKey("mintakecash"));
            return View(model);
        }
        [HttpPost]
        public ActionResult Apply(decimal? amount)
        {
            decimal minTakeCash = Convert.ToDecimal(settingsService.GetValueByKey("mintakecash"));            
            if (amount==null)
            {
                return Json(new AjaxResult { Status = "0", Msg = "提现金额必须填写" });
            }
            if (amount.Value <=0)
            {
                return Json(new AjaxResult { Status = "0", Msg = "提现金额必须大于零" });
            }
            var holder = holderService.GetById(UserId);
            if(amount.Value<minTakeCash)
            {
                return Json(new AjaxResult { Status = "0", Msg = "金额不能小于最低可提现金额" });
            }
            if (amount.Value > holder.TakeBonus)
            {
                return Json(new AjaxResult { Status = "0", Msg = "金额不能大于可提现金额" });
            }
            if(string.IsNullOrEmpty(holder.TradePassword))
            {
                return Json(new AjaxResult { Status = "0", Msg = "提现交易密码为空，不能提现,请到个人中心完善资料再申请" });
            }
            if (string.IsNullOrEmpty(holder.BankAccount))
            {
                return Json(new AjaxResult { Status = "0",Msg="提现银行卡账号为空，不能提现,请到个人中心完善资料再申请" });
            }            
            if(holder.TakeCashTime>DateTime.Now)
            {
                return Json(new AjaxResult { Status = "0", Msg = "请到可提现时间后再提现" });
            }
            takeCashService.Apply(UserId, amount.Value);
            return Json(new AjaxResult { Status = "1" ,Data="/takecash/list"});
        }

        public ActionResult Detail(long id)
        {
            var model= takeCashService.GetById(id);
            return View(model);
        }
    }
}