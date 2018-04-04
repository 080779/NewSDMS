using SDMS.Common;
using SDMS.IService.Interface;
using SDMS.Web.Controllers.Base;
using SDMS.Web.Models.MyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDMS.Web.Controllers
{
    public class MyInfoController : FrontBaseController
    {
        //public IHolderService holderService { get; set; }
        public ISettingsService settingsService { get; set; }
        public ActionResult List()
        {
            ListViewModel model = new ListViewModel();
            model.Holder= holderService.GetById(UserId);
            model.Tel = settingsService.GetValueByKey("tel");
            return View(model);
        }
        [HttpGet]
        public ActionResult Info()
        {
            var dto = holderService.GetById(UserId);
            if(string.IsNullOrEmpty(dto.HeadImgUrl) && Session["HeadImgUrl"]!=null)
            {
                dto.HeadImgUrl = Session["HeadImgUrl"].ToString();
            }
            return View(dto);
        }
        [HttpPost]
        public ActionResult Info(InfoModel model)
        {
            if(!string.IsNullOrEmpty(model.BankAccount))
            {
                long num;
                if(!long.TryParse(model.BankAccount,out num))
                {
                    return Json(new AjaxResult { Status = "0", Msg = "银行卡账号必须是小于等于19位的数字" });
                }
            }
            if (!holderService.Update(model.Id, model.Address, model.Contact, model.BankAccount, model.UrgencyName, model.UrgencyContact))
            {
                return Json(new AjaxResult { Status = "0" ,Msg="修改失败" });
            }
            return Json(new AjaxResult { Status="1" ,Data="/myinfo/list"});
        }
        public ActionResult UnBind()
        {
            long result = holderService.UnBind(UserId);
            if (result<=0)
            {
                if(result==-2)
                {
                    return Json(new AjaxResult { Status = "0", Msg = "已解除绑定过了" });
                }
                return Json(new AjaxResult { Status = "0", Msg="解除绑定失败" });
            }
            return Json(new AjaxResult { Status = "1" });
        }
    }
}