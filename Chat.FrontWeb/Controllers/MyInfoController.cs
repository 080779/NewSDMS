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
        public ActionResult List()
        {
            var dto=holderService.GetById(UserId);
            return View(dto);
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
            if(!holderService.Update(model.Id, model.Address, model.Contact, model.BankAccount, model.UrgencyName, model.UrgencyContact))
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